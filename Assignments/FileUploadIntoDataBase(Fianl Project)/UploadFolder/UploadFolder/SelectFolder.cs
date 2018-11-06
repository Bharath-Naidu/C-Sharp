
using System;
using System.IO;
using System.Linq;
using DAL.Model;
using DAL.Repository;

namespace UploadFolder
{
    class SelectFolder
    {
        Permissions permission = new Permissions();
        public void GetSubDirectories(String RootFolderPath, int RootFolderId) //Retriving the sub folders and files 
        {
            FileInformation Dbcall = new FileInformation();
            string[] SubdirectoryEntries = Directory.GetDirectories(RootFolderPath); //Identifying and retriving the all sub folders 
            string[] AllFilesinDirectory = Directory.GetFiles(RootFolderPath);//Identifying and retriving the all sub files 
            if (AllFilesinDirectory.Length > 0) //checking the root folders is contains the files or not
            {
                SubFolder FolderDetails = GetFolderdetails(RootFolderPath); //Retriving the folder information 
                int PresentFolderID = Dbcall.UploadSubFolder(FolderDetails, RootFolderId); //upload into the database
                foreach (String FilePath in AllFilesinDirectory)
                {           
                    DAL.Model.FileInfo FileInfo = GetFileInfo(FilePath);//Retriving the file information 
                    int FileID=Dbcall.UploadFile(FileInfo, PresentFolderID);//upload into the database
                }
            }
            foreach (string subdirectory in SubdirectoryEntries)
            {  
                SubFolder FolderDetails = GetFolderdetails(subdirectory);
                int FolderID = Dbcall.UploadSubFolder(FolderDetails, RootFolderId);//upload into the database
                LoadSubDirs(subdirectory, FolderID, RootFolderId);  //getting information of the sub folders 
            }
        }
        private void LoadSubDirs(string directory, int PresentFolderid, int Rootid)
        {
            FileInformation Sub = new FileInformation();
           
            string[] SubdirectoryEntries = Directory.GetDirectories(directory);//Identifying and retriving the all sub folders 
            string[] AllFilesinDirectory = Directory.GetFiles(directory);//Identifying and retriving the all sub files 
            foreach (String FilePath in AllFilesinDirectory) // we have all file. now getting file info and upload it into database
            {
                
                DAL.Model.FileInfo fileInfo = GetFileInfo(FilePath); //getting File info
                int FileID=Sub.UploadFile(fileInfo, PresentFolderid);//upload the file into database
                permission.GetFilePermmssion(FileID, FilePath);
            }
            foreach (string subdirectory in SubdirectoryEntries) //all subfolders
            {
                
                SubFolder FolderDetails = GetFolderdetails(subdirectory); //getting sub folder details 
                int FolderID = Sub.UploadSubFolder(FolderDetails, Rootid); //upload the sub folder into datatbase and that return id after insert 
                LoadSubDirs(subdirectory, FolderID, Rootid); //the id is used for uploading file
            }
        }
        private SubFolder GetFolderdetails(string directoryPath) // getting sub Folder details 
        {
            SubFolder Folder = new SubFolder();
            DirectoryInfo DirectoryInfo = new DirectoryInfo(directoryPath);   
            Folder.Name = DirectoryInfo.Name;
            Folder.Path = directoryPath;
            string OwnerOfFolder = System.IO.File.GetAccessControl(directoryPath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
            Folder.CreatedOn = DirectoryInfo.CreationTime;
            Folder.ModifiedOn = DirectoryInfo.LastAccessTime;
            Folder.ModifiedBy = OwnerOfFolder;
            Folder.CreatedBy = OwnerOfFolder;
            return Folder;
        }
        
        public DAL.Model.FileInfo GetFileInfo(string FilePath) //getting file details 
        {
            DAL.Model.FileInfo Filedetails = new DAL.Model.FileInfo();
            System.IO.FileInfo File = new System.IO.FileInfo(FilePath);
            char[] GetInvalidCharacters = Path.GetInvalidFileNameChars();
            if (File.Name.Length - File.Name.Replace(".", "").Length <= 1 || File.Name.Length > 128)
            {
                foreach (char Charactor in GetInvalidCharacters)
                {
                    if (File.Name.Contains(Charactor))
                    {
                        Filedetails.IsFilesupported = false;
                        break;
                    } else
                    {
                        Filedetails.IsFilesupported = true ;
                    }
                }
            }
            else
            {
                Filedetails.IsFilesupported = false;
            }
            if (File.DirectoryName.Length > 260)
            {
                Filedetails.IsFilePathOK = false;
                Filedetails.IsFilesupported = false;
            }
            else
            {
                Filedetails.IsFilePathOK = true;
            }
            string Owner = System.IO.File.GetAccessControl(FilePath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
            Filedetails.Name = File.Name;
            Filedetails.Path = FilePath;
            Filedetails.Type = File.Extension;
            double length = Math.Round(((File.Length / 1024f) / 1024f), 4, MidpointRounding.AwayFromZero);
            Filedetails.Size = Convert.ToSingle(length);
            //Filedetails.Size = (Convert.ToInt32(File.Length)/1024)/1024;            
            Filedetails.CreatedOn = File.CreationTime;
            Filedetails.FileAccessed = File.LastAccessTime;
            Filedetails.ModifiedOn = File.LastWriteTime;
            Filedetails.CreatedBy = Owner;
            Filedetails.ModifiedBy = Owner;
            return Filedetails;
        }
        public RootFolder GetRootFolderdetails(string directoryPath)  // getting root Folder details
        {
            RootFolder Folder = new RootFolder();
            DirectoryInfo DirectoryInfo = new DirectoryInfo(directoryPath);
            Folder.Name = DirectoryInfo.Name;
            Folder.Path = directoryPath;
            string user = System.IO.File.GetAccessControl(directoryPath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();//Used to retriving the owner 
            Folder.CreatedOn = DirectoryInfo.CreationTime;
            Folder.ModifiedOn = DirectoryInfo.LastAccessTime;
            Folder.ModifiedBy = user;
            Folder.CreatedBy = user;
            return Folder;
        }
    }
}

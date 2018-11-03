using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DAL.Model;
using DAL.Repository;

namespace WindowsFormsApp1
{
   
    public partial class Form1 : Form
    { 
        IList<string> RootFoldersPath = new List<string>();  // list for RootFoldersPath
        IList<string> SubFoldersPath = new List<string>();   // list for SubFoldersPath
       
        public Form1()
        {
          InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
  
        private void folderBrowserDialog1_HelpRequest_1(object sender, EventArgs e)
        {
           
        }

              // ---------------------------------------Browsing the Folders--------------------------------------//

        private void Browse_Click(object sender, EventArgs e)
        {
            Errorlabel1.Text = "";
            Errorlabel2.Text = "";
            using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    SelectedPathFolder.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

         // ------------------------------Adding the browsed Folders to the list and listbox -------------------------//

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                Errorlabel2.Text = "";
                Errorlabel1.Text = "";
                string folderpath;
                if (SelectedPathFolder.Text == "" || SelectedPathFolder.Text == null)  //throwing error when listbox is empty
                {
                    throw new Exception("Please Browse the folder");
                }
                else
                {
                    Errorlabel1.Text = "";
                    folderpath = SelectedPathFolder.Text;  //assigning browsed folderpath to variable 
                    RootFoldersPath.Add(folderpath);      // adding the selected folderpath to list
                    Boolean IfItemIsExists = false;
                    foreach (string PresentFilePath in RootFoldersPath)  // getting each folderpath in list
                    {
                        if (folderpath.Equals(PresentFilePath))   // comparing with folderpath in list with present folderpath
                        {
                            IfItemIsExists = true;
                        }
                    }
                    if (IfItemIsExists)  // if exists removing the folderpath in list
                    {
                        RootFoldersPath.Remove(folderpath); 
                        int ExistedFilePlace = folderpath.LastIndexOf("\\");  
                        String ExistedfileName = folderpath.Substring(ExistedFilePlace + 1);
                        SelectedFolders.Items.Remove(ExistedfileName);
                    }
                    RootFoldersPath.Add(folderpath);  // adding folderpath to list
                    int LastIndexOf = folderpath.LastIndexOf("\\");   // getting foldername instead of taking the folderpath
                    String fileName = folderpath.Substring(LastIndexOf + 1);  
                    SelectedFolders.Items.Add(fileName);  // adding foldername to listbox
                    SelectedPathFolder.Text = "";   // empty the browsing textbox
                }
            }
            catch(Exception Ex)
            {
                Errorlabel1.Text = Ex.Message;   // error message if not browsed 
                ErrrorLog.ErrorlogWrite(Ex);     // error message to log file
            }
            
        }

        // ------------------------------Removing the selected Folders from the list and listbox -------------------------//

        private void Remove_Click(object sender, EventArgs e)
        {
            try
            {                               
                string folderpath = "";
                foreach (string path in RootFoldersPath)  // getting each folderpath in list
                {
                    folderpath = path;
                }
                if ((folderpath == "" || folderpath == null) && (SelectedFolders.Text == "" || SelectedFolders.Text == null))  // if browsing textbox is empty
                {
                    throw new Exception("Please Browse the folder");
                }
                else if (SelectedFolders.Text == "" || SelectedFolders.Text == null || SelectedFolders.SelectedItem.ToString() == null) // if not selected the foldername to remove
                {
                    throw new Exception("Please Select Folder");
                }

                else
                {
                    Errorlabel2.Text = "";
                    Errorlabel1.Text = "";

                    string foldername = SelectedFolders.SelectedItem.ToString(); // selecting the foldername to remove
                   
                    SelectedFolders.Items.Remove(foldername);   // removing the selected folders in listbox
                    String RemovingItem = "";

                    foreach (String path in RootFoldersPath)   // getting each folderpath in list
                    {
                        int LastIndexOf = path.LastIndexOf("\\");    
                        String folderName = path.Substring(LastIndexOf + 1); // getting foldername in list
                        if (folderName.Equals(foldername))  // if selected foldername equals to list foldername
                        {
                            RemovingItem = path;   
                        }
                    }
                    RootFoldersPath.Remove(RemovingItem);   // removing the selected path from list
                }
            }
            catch(Exception Ex)
            {
                Errorlabel1.Text = Ex.Message;   // exception message 
                ErrrorLog.ErrorlogWrite(Ex);
            }
        }

                // ------------------------------Sending the data to database-------------------------//

        private void Run_Click(object sender, EventArgs e) 
        {
            try
            {
                string folderpath = "";
                foreach (string path in RootFoldersPath)  // getting each folderpath in list
                {
                    folderpath = path;
                }
                if (folderpath == "" || folderpath == null)   // if folderpath is empty
                {
                    throw new Exception("Please Browse the folder");  //throw exception
                } 
                else
                {
                    Errorlabel2.Text = "";
                    Errorlabel1.Text = "";
                    string[] subfolders = Directory.GetDirectories(folderpath, "*", SearchOption.AllDirectories); // getting all subfolders into variable
                    string[] files = Directory.GetFiles(folderpath, "*", SearchOption.AllDirectories);   // getting all files into variable
                    foreach (String Rootfolder in RootFoldersPath) //Getting each rootfolder from list
                    {
                        try
                        {
                            FileInformation dbcall = new FileInformation();
                            RootFolder RootFolderDetails = GetRootFolderdetails(Rootfolder); //Getting rootfolder details
                            int ID = dbcall.UploadRootFolder(RootFolderDetails);//Upload into the database and method is return the inserted id. ID is usefully for files
                            GetSubDirectories(Rootfolder, ID); //Getting all sub folders and files
                        }
                        catch (Exception Ex)
                        {
                           
                            ErrrorLog.ErrorlogWrite(Ex);
                        }
                    }
                }
            }
            catch(Exception Ex)
            {
                Errorlabel1.Text = Ex.Message;
                ErrrorLog.ErrorlogWrite(Ex);
            }
            SelectedFolders.Items.Clear();
        }
        public void GetSubDirectories(String RootFolderPath, int RootFolderId) //It contains the sub folders and files 
        {
            FileInformation dbcall = new FileInformation();
            string[] subdirectoryEntries = Directory.GetDirectories(RootFolderPath); //Identifying and retriving the all sub folders 
            string[] AllFilesinDirectory = Directory.GetFiles(RootFolderPath);//Identifying and retriving the all sub files 
            if (AllFilesinDirectory.Length>0) //checking the root folders is contains the files or not
            {
                SubFoldersPath.Add(RootFolderPath);
                SubFolder FolderDetails = GetFolderdetails(RootFolderPath); //Retriving the folder information 
                int PresentFolderID = dbcall.UploadSubFolder(FolderDetails, RootFolderId); //upload into the database
                foreach (String FilePath in AllFilesinDirectory)
                {
                    try
                    {
                        DAL.Model.FileInfo fileInfo = GetFileInfo(FilePath);//Retriving the file information 
                        dbcall.UploadFile(fileInfo, PresentFolderID);//upload into the database
                    }
                    catch(Exception Ex)
                    {
                    }
                }
            }
            foreach (string subdirectory in subdirectoryEntries)    
            {
                try
                {
                    SubFolder FolderDetails = GetFolderdetails(subdirectory);
                    int FolderID = dbcall.UploadSubFolder(FolderDetails, RootFolderId);//upload into the database
                    LoadSubDirs(subdirectory, FolderID, RootFolderId);  //the sub folder is contains sub folder so call sub directory
                }
                catch (Exception Ex)
                {
                    ErrrorLog.ErrorlogWrite(Ex);
                }
            }
            
        }
        private void LoadSubDirs(string directory, int PresentFolderid, int Rootid)
        {
            FileInformation sub = new FileInformation();
            SubFoldersPath.Add(directory);
            string[] subdirectoryEntries = Directory.GetDirectories(directory);//Identifying and retriving the all sub folders 
            string[] AllFilesinDirectory = Directory.GetFiles(directory);//Identifying and retriving the all sub files 
            foreach (String FilePath in AllFilesinDirectory) // we have all file now getting file info and upload it into database
            {
                try
                {
                    DAL.Model.FileInfo fileInfo = GetFileInfo(FilePath); //getting File info
                    sub.UploadFile(fileInfo, PresentFolderid);//upload into database
                }
                catch(Exception Ex)
                {
                    ErrrorLog.ErrorlogWrite(Ex);
                }
            }
            foreach (string subdirectory in subdirectoryEntries) //all subfolders
            {
                try
                {
                    SubFolder FolderDetails = GetFolderdetails(subdirectory); //getting sub folder details 
                    int FolderID = sub.UploadSubFolder(FolderDetails, Rootid); //upload the sub folder into datatbase and that return id after insert 
                    LoadSubDirs(subdirectory, FolderID, Rootid); //the id is used for uploading file
                }
                catch (Exception Ex)
                {
                    ErrrorLog.ErrorlogWrite(Ex);
                }
            }
        }
        private SubFolder GetFolderdetails(string directoryPath) // getting sub Folder details 
        {
            SubFolder folder = new SubFolder();
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                int LastIndexOf = directoryPath.LastIndexOf("\\");
                String FolderName = directoryPath.Substring(LastIndexOf + 1);


                if (FolderName.Length > 128) //here checking the folder name length
                {
                    throw new Exception(string.Format("Folder name is above 128 characters"));
                }
                else
                {
                    char[] GetInvalidCharacters = Path.GetInvalidFileNameChars(); //getting all invalid characters 
                    if (FolderName.Length - FolderName.Replace(".", "").Length <= 1) //checking the file has more than two dots
                    {
                        foreach (char OneCharacter in GetInvalidCharacters) //checking the each character in file name
                        {
                            if (FolderName.Contains(OneCharacter))
                            {
                                throw new Exception(string.Format("Folder name can't contains \"*:<>?//\\|. "));
                            }
                        }
                        folder.Name = FolderName;
                    }
                    else
                    {
                        throw new Exception(string.Format("Folder name can't contains \"*:<>?//\\|. "));
                    }
                }
                if (directoryPath.Length > 260) //checking the file path length
                {
                    throw new Exception(string.Format("Folder path can't more than 260 characters"));
                }
                else
                    folder.Path = directoryPath;
                string OwnerOfFolder = System.IO.File.GetAccessControl(directoryPath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
                
                folder.Path = directoryPath;
                folder.CreatedOn = directoryInfo.CreationTime;
                folder.ModifiedOn = directoryInfo.LastAccessTime;
                folder.ModifiedBy = OwnerOfFolder;
                folder.CreatedBy = OwnerOfFolder;
            }
            catch(Exception Ex)
            {
                ErrrorLog.ErrorlogWrite(Ex);
            }
            return folder;
        }
        public RootFolder GetRootFolderdetails(string directoryPath)  // getting root Folder details

        {
            RootFolder folder = new RootFolder();
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
                int LastIndexOf = directoryPath.LastIndexOf("\\");
                String FolderName = directoryPath.Substring(LastIndexOf + 1);
                
                
                if (FolderName.Length > 128)//here checking the folder name length
                {
                    throw new Exception(string.Format("Folder name is above 128 characters"));
                }
                else
                {
                    char[] GetInvalidCharacters = Path.GetInvalidFileNameChars();//getting all invalid characters
                    if (FolderName.Length - FolderName.Replace(".", "").Length <= 1) //checking the file has more than two dots
                    {
                        
                        foreach (char OneCharacter in GetInvalidCharacters)//checking the each character in file name
                        {
                            if (FolderName.Contains(OneCharacter))
                            {
                                throw new Exception(string.Format("Folder name can't contains \"*:<>?//\\|. "));
                            }
                        }
                        folder.Name = FolderName;
                    }
                    else
                    {
                        throw new Exception(string.Format("Folder name can't contains \"*:<>?//\\|. "));
                    }
                }
                if (directoryPath.Length > 260)//checking the file path length
                {
                    throw new Exception(string.Format("Folder path can't more than 260 characters"));
                }
                else
                    folder.Path = directoryPath;
                string user = System.IO.File.GetAccessControl(directoryPath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();//Used to retriving the owner 
                folder.CreatedOn = directoryInfo.CreationTime;
                folder.ModifiedOn = directoryInfo.LastAccessTime;
                folder.ModifiedBy = user;
                folder.CreatedBy = user;
            }
            catch(Exception Ex)
            {
                ErrrorLog.ErrorlogWrite(Ex);
            }
            return folder;
        }
        public DAL.Model.FileInfo GetFileInfo(string FilePath) //getting file details 
        {
            DAL.Model.FileInfo Filedetails = new DAL.Model.FileInfo();
            try
            {
               
                System.IO.FileInfo file = new System.IO.FileInfo(FilePath);
                if (file.Name.Length > 128)
                {
                    throw new Exception(string.Format("File name is above 128 characters"));
                }
                else
                {
                    char[] GetInvalidCharacters = Path.GetInvalidFileNameChars();
                    if (file.Name.Length - file.Name.Replace(".", "").Length <= 1)
                    {
                        Filedetails.Name = file.Name;
                        foreach (char ch in GetInvalidCharacters)
                        {
                            if (file.Name.Contains(ch))
                            {
                                throw new Exception(string.Format("File name can't contains \"*:<>?//\\|. "));
                            }
                        }
                    }
                    else
                    {
                        throw new Exception(string.Format("File name can't contains \"*:<>?//\\|. "));
                    }
                }                    
                if(file.DirectoryName.Length>260)
                {
                    throw new Exception(string.Format("File path can't more than 260 characters"));
                }
                else
                    Filedetails.Path = file.DirectoryName;
                Filedetails.Type = file.Extension;
                float lengthbytes = (file.Length / 1024f) / 1024f;
                double length = Math.Round(((file.Length / 1024f) / 1024f), 4, MidpointRounding.AwayFromZero);
                Filedetails.Size = Convert.ToString(length);
                Filedetails.Size = Filedetails.Size + " MB";
                Filedetails.CreatedOn = file.CreationTime;
                Filedetails.FileAccessed = file.LastAccessTime;
                Filedetails.IsFilePathOK = true;
                Filedetails.IsFilesupported = true;
                Filedetails.ModifiedOn = file.LastWriteTime;
                Filedetails.CreatedBy = System.IO.File.GetAccessControl(FilePath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
                Filedetails.ModifiedBy = System.IO.File.GetAccessControl(FilePath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
            }
            catch (Exception Ex)
            {
                ErrrorLog.ErrorlogWrite(Ex);
            }
            return Filedetails;
        }
        

    }
}

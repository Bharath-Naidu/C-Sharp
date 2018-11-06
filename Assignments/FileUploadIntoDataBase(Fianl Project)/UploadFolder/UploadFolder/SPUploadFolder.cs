using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using DAL;
using DAL.Repository;

namespace UploadFolder
{
    class SPUploadFolder
    {
       public  string FolderPAthForPermission="";
        Permissions SpPermissions = new Permissions();
        //***********************************Upload Doccument From the directory******************************// 

        public  void UploadDocument(ClientContext clientContext, string sourceFilePath, string serverRelativeDestinationPath)
        {
            
            string UploadStatus;
            UploadLog UploadTimeLog = new UploadLog();
            DateTime StartTime = DateTime.Now;
            try
            {
                using (var FileStream = new FileStream(sourceFilePath, FileMode.Open))
                {
                    var fileInfo = new FileInfo(sourceFilePath);
                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, serverRelativeDestinationPath, FileStream, true);
                    UploadStatus = "Success";
                }
            }
            catch (Exception ex)
            {
                UploadStatus = "Failure";
                ErrrorLog.ErrorlogWrite(ex);
            }
            DateTime EndTime = DateTime.Now;

            UploadTimeLog.UploadTimeWrite(sourceFilePath.Split('/').Last(), sourceFilePath, UploadStatus, StartTime, EndTime);
        }

        //*********************************** add subfolder in doccument library and create SubFolder From the directory******************************// 

        public  void UploadFolder(ClientContext clientContext, System.IO.DirectoryInfo folderInfo, Folder folder)
        {
            System.IO.FileInfo[] Files = null;
            System.IO.DirectoryInfo[] SubDirs = null;

            try
            {
                Files = folderInfo.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
            }
            if (Files != null)
            {
                foreach (System.IO.FileInfo Fi in Files)
                {
                    Console.WriteLine(Fi.FullName);
                    clientContext.Load(folder);
                    clientContext.ExecuteQuery();
                    UploadDocument(clientContext, Fi.FullName, folder.ServerRelativeUrl + "/" + Fi.Name);
                }
                SubDirs = folderInfo.GetDirectories();
                foreach (System.IO.DirectoryInfo DirectoriInfo in SubDirs)
                {
                    Folder subFolder = folder.Folders.Add(DirectoriInfo.Name);
                    clientContext.ExecuteQuery();
                    try
                    {
                     //_______________Add Permissions for the folder______________________//
                        SpPermissions.GetPermmssion(clientContext, subFolder, DirectoriInfo.FullName);
                    }
                    catch (Exception ex)
                    {
                        ErrrorLog.ErrorlogWrite(ex);
                    }
                    UploadFolder(clientContext, DirectoriInfo, subFolder);
                }
            }
        }

     //***********************************add  folder in doccument library if rootfolder path  have one folder ******************************// 

        public void UploadFoldersRecursively(ClientContext clientContext, string sourceFolder, string destinationLigraryTitle)
        {
            try
            {
                Web Webobj = clientContext.Web;
                var query = clientContext.LoadQuery(Webobj.Lists.Where(p => p.Title == destinationLigraryTitle));
                clientContext.ExecuteQuery();
                List DocumentsLibrary = query.FirstOrDefault();
                var Folder = DocumentsLibrary.RootFolder;
                string[] Splitpath = sourceFolder.Split(Convert.ToChar(92));
                clientContext.Load(DocumentsLibrary.RootFolder);
                clientContext.ExecuteQuery();
                Folder = DocumentsLibrary.RootFolder.Folders.Add(Splitpath[1]);
                clientContext.ExecuteQuery();
                FolderPAthForPermission += Splitpath[0]+"\\"+ Splitpath[1];
                try
                {
                    //_______________Add Permissions for the folder______________________//
                    SpPermissions.GetPermmssion(clientContext, Folder, FolderPAthForPermission);
                }
                catch (Exception ex)
                {
                    ErrrorLog.ErrorlogWrite(ex);
  
                }
                if (Splitpath.Length >2)
                {
                    CreateSubFolder(clientContext, sourceFolder, 2, Splitpath, Folder);
                }
                else
                {
                    System.IO.DirectoryInfo DirectoriInfo = new System.IO.DirectoryInfo(sourceFolder);
                    UploadFolder(clientContext, DirectoriInfo, Folder);
                }
                
            }
            catch (Exception ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
            }
        }

  
        //***********************************add Subfolders in document library if rootfolder path has more than more than one folder******************************// 

        public  void CreateSubFolder(ClientContext clientContext, string path, int folderLocationCount, string[] SubFolder, Folder folder)
        {
            
            int FolderLocationcnt = folderLocationCount;
            FolderLocationcnt++;
            try
            {
                Folder subFolder = folder.Folders.Add(SubFolder[folderLocationCount]);
                clientContext.ExecuteQuery();
                FolderPAthForPermission += "\\" + SubFolder[folderLocationCount];
                try
                {
                    //_______________Add Permissions for the folder______________________//
                    SpPermissions.GetPermmssion(clientContext, folder, FolderPAthForPermission);
                }
                catch (Exception ex)
                {
                    ErrrorLog.ErrorlogWrite(ex);
                }
                if (FolderLocationcnt < SubFolder.Length)
                {
                    CreateSubFolder(clientContext, path, FolderLocationcnt, SubFolder, subFolder);
                }
                else
                {
                    System.IO.DirectoryInfo DirectoriInfo = new System.IO.DirectoryInfo(path);
                    UploadFolder(clientContext, DirectoriInfo, subFolder);
                }
            }
            catch (Exception ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
            }
        }

    }
}


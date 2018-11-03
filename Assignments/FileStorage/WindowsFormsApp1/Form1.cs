using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Model;
using DAL.Repository;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        IList<string> strList = new List<string>();
        IList<string> RootFoldersPath = new List<string>();
        IList<string> SubFoldersPath = new List<string>();
        IList<string> FilesPath = new List<string>();
        bool RootFolderHasFiles = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog())
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string filepath = textBox1.Text;
            Boolean IfItemIsExists = false;
            foreach(string PresentFilePath in strList)
            {
                if(filepath.Equals(PresentFilePath))
                {
                    IfItemIsExists = true;
                }
            }
            if (IfItemIsExists)
            {
                strList.Remove(filepath);
                int ExistedFilePlace = filepath.LastIndexOf("\\");
                String ExistedfileName = filepath.Substring(ExistedFilePlace + 1);
                listBox1.Items.Remove(ExistedfileName);
            }
            strList.Add(filepath);
            int LastIndexOf = filepath.LastIndexOf("\\");
            String fileName = filepath.Substring(LastIndexOf+1);
            listBox1.Items.Add(fileName);
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            string filepath = listBox1.SelectedItem.ToString();
            listBox1.Items.Remove(filepath);
            String RemovingItem="";
            foreach (String file in strList)
            {
                int LastIndexOf = file.LastIndexOf("\\");
                String fileName = file.Substring(LastIndexOf + 1);
                if (fileName.Equals(filepath))
                {
                    RemovingItem = file;
                }
            }
            strList.Remove(RemovingItem);   
        }
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (String path in strList)
            {
                DataBaseLinking data = new DataBaseLinking();
                RootFoldersPath.Add(path);
                RootFolder rootfolder=GetRootFolderdetails(path);
                int RootFolderID=data.UploadRootFolder(rootfolder);
                #region commented
                //listBox2.Items.Add("-----RootFolder-----");
                //listBox2.Items.Add("Name="+rootfolder.Name);
                //listBox2.Items.Add("Path="+rootfolder.Path);
                //listBox2.Items.Add("Modified on="+rootfolder.ModifiedOn);
                //listBox2.Items.Add("Created on="+rootfolder.CreatedOn);
                //listBox2.Items.Add("Modified by="+rootfolder.ModifiedBy);
                //listBox2.Items.Add("created by="+rootfolder.CreatedBy);
                //listBox2.Items.Add("--------------------");
                #endregion
                GetSubDirectories(path,RootFolderID);
            }
        }
        public void GetSubDirectories(String root,int Rootid)
        {
            // Get all subdirectories
            DataBaseLinking sub = new DataBaseLinking();
            string[] subdirectoryEntries = Directory.GetDirectories(root);
            string[] AllFilesinDirectory = Directory.GetFiles(root);
            foreach (String FilePath in AllFilesinDirectory)
            {
                RootFolderHasFiles = true;
                FilesPath.Add(FilePath);
                DAL.Model.FileInfo file = GetFileInfo(FilePath, Rootid);
                sub.UploadFile(file, Rootid);
            }
            if(RootFolderHasFiles)
                SubFoldersPath.Add(root);
            // Loop through them to see if they have any other subdirectories
            foreach (string subdirectory in subdirectoryEntries)
            {
                
                SubFolder RT = GetFolderdetails(subdirectory);
                int FolderID=sub.UploadSubFolder(RT,Rootid);
                #region commented
                //listBox2.Items.Add("Name=" + RT.Name);
                //listBox2.Items.Add("Path=" + RT.Path);
                //listBox2.Items.Add("Modified on=" + RT.ModifiedOn);
                //listBox2.Items.Add("Created on=" + RT.CreatedOn);
                //listBox2.Items.Add("Modified by=" + RT.ModifiedBy);
                //listBox2.Items.Add("created by=" + RT.CreatedBy);
                //listBox2.Items.Add("--------------------");
                #endregion
                LoadSubDirs(subdirectory,FolderID,Rootid);
            }
        }
        private void LoadSubDirs(string dir,int Presentid,int Rootid)
        {
            DataBaseLinking sub = new DataBaseLinking();
            SubFoldersPath.Add(dir);
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            string[] AllFilesinDirectory = Directory.GetFiles(dir);
            foreach (String FilePath in AllFilesinDirectory)
            {
                FilesPath.Add(FilePath);
                DAL.Model.FileInfo file =GetFileInfo(FilePath,Presentid);
                sub.UploadFile(file,Presentid);
            }
            foreach (string subdirectory in subdirectoryEntries)
            {
                SubFolder RT=GetFolderdetails(subdirectory);
                int FolderID=sub.UploadSubFolder(RT,Rootid);
                #region commented 
                //listBox2.Items.Add("Name=" + RT.Name);
                //listBox2.Items.Add("Path=" + RT.Path);
                //listBox2.Items.Add("Modified on=" + RT.ModifiedOn);
                //listBox2.Items.Add("Created on=" + RT.CreatedOn);
                //listBox2.Items.Add("Modified by=" + RT.ModifiedBy);
                //listBox2.Items.Add("created by=" + RT.CreatedBy);
                //listBox2.Items.Add("--------------------");
                #endregion
                LoadSubDirs(subdirectory,FolderID,Rootid);
            }
        }
        private SubFolder GetFolderdetails(string path)
        {
            SubFolder folder = new SubFolder();
            // List<RootFolder> 
            DirectoryInfo DR = new DirectoryInfo(path);
            string user = System.IO.File.GetAccessControl(path).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
            int LastIndexOf = path.LastIndexOf("\\");
            String FolderName = path.Substring(LastIndexOf + 1);
            { 
            //DirectorySecurity ds = DR.GetAccessControl();
            ////FileSystemAccessRule abc = ds.GetAccessRules(true, true, typeof(NTAccount));
            //foreach (FileSystemAccessRule rule in ds.GetAccessRules(true, true, typeof(NTAccount)))
            //{
            //    //listBox2.Items.Add(string.Format("{0} || Identity = {1}; Access = {2} \r\n", DR.ToString(),
            //    //rule.IdentityReference.Value, rule.AccessControlType));
            //    GetRuleAsString(rule);
            //}
            //FileSystemAccessRule rule = new FileSystemAccessRule(user,);
            ////bool hasChangePermission = rule.FileSystemRights.HasFlag(FileSystemRights.ChangePermissions);
            }
            folder.Name = FolderName;
            folder.Path = path;
            folder.CreatedOn = DR.CreationTime;
            folder.ModifiedOn = DR.LastAccessTime;
            folder.ModifiedBy = user;
            folder.CreatedBy = user;
            return folder;
            {
                //foreach(var item in root)
                //{

                //}
                //listBox2.Items.Add(DR.CreationTime);
                //listBox2.Items.Add(DR.LastAccessTime);
                //listBox2.Items.Add(System.IO.File.GetAccessControl("D:\\File").GetOwner(typeof(System.Security.Principal.NTAccount)).ToString());
            }
        }
        public RootFolder GetRootFolderdetails(string path)
        {
            RootFolder folder = new RootFolder();
            DirectoryInfo DR = new DirectoryInfo(path);
            string user = System.IO.File.GetAccessControl(path).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
            int LastIndexOf = path.LastIndexOf("\\");
            String FolderName = path.Substring(LastIndexOf + 1);
            folder.Name = FolderName;
            folder.Path = path;
            folder.CreatedOn = DR.CreationTime;
            folder.ModifiedOn = DR.LastAccessTime;
            folder.ModifiedBy = user;
            folder.CreatedBy = user;
            return folder;
        }
        public DAL.Model.FileInfo GetFileInfo(string FilePath,int id)
        {
            DAL.Model.FileInfo Filedetails = new DAL.Model.FileInfo();
            System.IO.FileInfo file = new System.IO.FileInfo(FilePath);
            Filedetails.Name = file.Name;
            Filedetails.Path = file.DirectoryName;
            Filedetails.Type = file.Extension;
            Filedetails.Size = file.Length;
            Filedetails.CreatedOn = file.CreationTime;
            Filedetails.FileAccessed = file.LastAccessTime;
            Filedetails.ModifiedOn = file.LastWriteTime;
            Filedetails.CreatedBy = System.IO.File.GetAccessControl(FilePath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
            Filedetails.ModifiedBy=System.IO.File.GetAccessControl(FilePath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
            return Filedetails;
            #region commented
            listBox2.Items.Add("---------------------------");
            listBox2.Items.Add("File name="+file.Name);
            listBox2.Items.Add("File path="+file.DirectoryName);
            listBox2.Items.Add("file type="+file.Extension);
            listBox2.Items.Add("File size="+file.Length);
            listBox2.Items.Add("File created On="+file.CreationTime);
            listBox2.Items.Add("file accesssed on="+file.LastAccessTime);
            listBox2.Items.Add("file modified on="+file.LastWriteTime);
            listBox2.Items.Add("Created by="+System.IO.File.GetAccessControl(FilePath).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString());
            #endregion
        }
        //public void GetRuleAsString(FileSystemAccessRule rule)
        //{
        //    string userName = rule.IdentityReference.Value;
        //    listBox2.Items.Add(userName);
        //    listBox2.Items.Add(Environment.UserName);
        //    listBox2.Items.Add(Environment.UserDomainName);

        //    //Example: Change    
        //    bool hasChangePermission = rule.FileSystemRights.HasFlag(FileSystemRights.FullControl);
        //    // listBox2.Items.Add(hasChangePermission);

        //    //Example: Write
        //    bool hasWritePermission = rule.FileSystemRights.HasFlag(FileSystemRights.Write);

        //    //listBox2.Items.Add(String.Format("{0}\n FullControl: {1}\n Write: {2}", userName, hasChangePermission, hasWritePermission));
        //}
    }
}

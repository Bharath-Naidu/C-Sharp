using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using Microsoft.SharePoint.Client;
using System.IO;
using DAL.Repository;
using DAL;
using DAL.Model;
using System.Data.SqlClient;
using System.Transactions;

namespace UploadFolder
{
    public partial class Main : System.Windows.Forms.Form
    {
        public static string UserName;
        public static SecureString Password;
        public static string Url;
        public static ClientContext Clientcontext;
        List<string> RootFoldersPath = new List<string>();  // list for RootFoldersPath
        

        GetReportsRepository RepObj = new GetReportsRepository();
        public Main()
        {

            InitializeComponent();
            /*----------------- Assigning the Data to FolderComboBox-------------------------*/

            //GetRootFolderRepository getRootFolder = new GetRootFolderRepository();
            //CBfoldername.DataSource = getRootFolder.BindingFolders();
            //CBfoldername.DisplayMember = "Name";
            //CBfoldername.ValueMember = "Path";

            ///*----------------- Assigning the Data to TypeOfInformation ComboBox-------------------------*/

            //Dictionary<string, string> ComboBoxItems = new Dictionary<string, string>();
            //ComboBoxItems.Add("CreatedOn", "Created");
            //ComboBoxItems.Add("ModifiedOn", "Modified");
            //ComboBoxItems.Add("FileAccessed", "Accesed");
            //InformationBox.DataSource = new BindingSource(ComboBoxItems, null);
            //InformationBox.DisplayMember = "Value";
            //InformationBox.ValueMember = "Key";
            //MonthsBox.SelectedItem = "1";


            //CBfoldername.DropDownStyle = ComboBoxStyle.DropDownList;
            //CbDocumentlibrary.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        /*----------------- For Connectng To Sharepoint After Given Credentials-------------------------*/

        private void Btnconnect_Click(object sender, EventArgs e)
        {
            UserName = Tbusername.Text;
            Password = new SecureString();
            foreach (char c in Tbpassword.Text)
            {
                Password.AppendChar(c);
            }

            Url = Tbsiteurl.Text;
            Lberror.Text = "Please wait connecting to sharepoint";

            try
            {
                Clientcontext = new ClientContext(Url);
                Clientcontext.Credentials = new SharePointOnlineCredentials(UserName, Password);
            }
            catch (Microsoft.SharePoint.Client.IdcrlException ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
                Lberror.Text = "The sign-in name or password does not match one in the Microsoft account system";
            }
            catch (Microsoft.SharePoint.Client.ClientRequestException ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
                Lberror.Text = "Cannot contact site ysou are specified";
            }
            catch (Exception ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
                Lberror.Text = "Please check the data what you provided";
            }
            try
            {
                /*----------------- Retriving All Document Library's from Sharepoint Assigning To Combobox-------------------------*/

                Web Webobject = Clientcontext.Web;
                var DocumentLibrary = Clientcontext.LoadQuery(Webobject.Lists.Where(l => l.BaseTemplate == 101));
                Clientcontext.ExecuteQuery();
                List<string> DocLibraryList = new List<string>();

                foreach (var List in DocumentLibrary)
                {
                    DocLibraryList.Add(List.Title);
                }

                Lberror.Text = "";
                CbDocumentlibrary.DataSource = DocLibraryList;
                CbDocumentlibrary.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
                Lberror.Text = "Please check the data what you provided";
            }

        }

        /*----------------- For Uploading Selected Folder into Sharepoint-------------------------*/

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if (CbDocumentlibrary.SelectedItem.ToString() == "" || CbDocumentlibrary.SelectedItem == null)
            {

                LbUploadStatus.Text = "Please Connect to sharepoint site";
            }
            else
            {

               
                LbUploadStatus.Text = "Uploading Started Please Wait";
                SPUploadFolder SPUpload = new SPUploadFolder();
                string Path = CBfoldername.SelectedValue.ToString();

                //Create Folders in document library if rootfolder path have only 1 Folder

                SPUpload.UploadFoldersRecursively(Clientcontext, Path, CbDocumentlibrary.SelectedItem.ToString());
                LbUploadStatus.Text = "Completed";
            }
        }

        /*----------------- getting the text from (InformationBox)Combobox to the SelectedInfoLabel-------------------------*/

        private void DisplayCountButton_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedInfoLabel.Text = InformationBox.SelectedItem.ToString();
                SelectedInfoLabel.Text = InformationBox.SelectedValue.ToString();
                SelectedInfoLabel.Visible = true;
                DisplayGridButton.Visible = true;

                //this line of code loads the InformationBox data and MonthsBox data and displays it in the DisplayGridButton

                DisplayGridButton.Text = RepObj.Getdata(InformationBox.SelectedValue.ToString(), MonthsBox.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
            }
        }

        /*-----------------retreiving the data from the database and Fill the data to Gridview-------------------------*/

        private void DisplayGridButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.DataGridView.Visible = true;
                DataSet dataSet = RepObj.DataGrid(InformationBox.SelectedValue.ToString(), MonthsBox.SelectedItem.ToString());
                DataGridView.DataSource = dataSet.Tables["FileInfo"];
            }
            catch (Exception ex)
            {
                ErrrorLog.ErrorlogWrite(ex);
            }
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
                    Errorlabel1.Text ="Please Browse the folder";
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
            catch (Exception Ex)
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
                string Folderpath = "";
                foreach (string path in RootFoldersPath)  // getting each folderpath in list
                {
                    Folderpath = path;
                }
                if ((Folderpath == "" || Folderpath == null) && (SelectedFolders.Text == "" || SelectedFolders.Text == null))  // if browsing textbox is empty
                {
                    Errorlabel1.Text ="Please Browse the folder";
                }
                else if (SelectedFolders.Text == "" || SelectedFolders.Text == null || SelectedFolders.SelectedItem.ToString() == null) // if not selected the foldername to remove
                {
                    Errorlabel2.Text ="Please Select Folder";
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
            catch (Exception Ex)
            {
                
                ErrrorLog.ErrorlogWrite(Ex);
            }
        }

        // ------------------------------Sending the data to database-------------------------//
        private void Run_Click(object sender, EventArgs e)
        {
            
                LbSelectFolderStatus.Text = "Please Wait Run Started";
                SelectFolder selectFolder = new SelectFolder();
                try
                {
                    string folderpath = "";
                    foreach (string path in RootFoldersPath)  // getting each folderpath in list
                    {
                        folderpath = path;
                    }
                    if (folderpath == "" || folderpath == null)   // if folderpath is empty
                    {
                        Errorlabel1.Text = "Please Browse the folder";
                    }
                    else
                    {
                        Errorlabel2.Text = "";
                        Errorlabel1.Text = "";
                        string[] subfolders = Directory.GetDirectories(folderpath, "*", SearchOption.AllDirectories); // getting all subfolders into variable
                        string[] files = Directory.GetFiles(folderpath, "*", SearchOption.AllDirectories);   // getting all files into variable
                        foreach (String Rootfolder in RootFoldersPath) //Getting each rootfolder from list
                        {
                            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                            {
                                try
                                {
                                    DAL.Repository.FileInformation dbcall = new DAL.Repository.FileInformation();
                                    RootFolder RootFolderDetails = selectFolder.GetRootFolderdetails(Rootfolder); //Getting rootfolder details
                                    int ID = dbcall.UploadRootFolder(RootFolderDetails);//Upload into the database and method is return the inserted id. ID is usefully for files
                                    selectFolder.GetSubDirectories(Rootfolder, ID); //Getting all sub folders and files
                                    scope.Complete();
                                }
                                catch (Exception Ex)
                                {
                                    scope.Dispose();
                                    ErrrorLog.ErrorlogWrite(Ex);
                                }
                            }
                        }

                    }
                    /*----------------- Assigning the Data to FolderComboBox Again-------------------------*/

                    GetRootFolderRepository getRootFolder = new GetRootFolderRepository();
                    CBfoldername.DataSource = getRootFolder.BindingFolders();
                    CBfoldername.DisplayMember = "Name";
                    CBfoldername.ValueMember = "Path";
                    MessageBox.Show("Run Completed");
                    }
                catch (Exception Ex)
                {
                    Errorlabel1.Text = Ex.Message;
                    ErrrorLog.ErrorlogWrite(Ex);
                }
            SelectedFolders.Items.Clear();
                LbSelectFolderStatus.Text = "Run Compleated";

           
            

        }

        private void CBfoldername_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void SelectFolderTab_Click(object sender, EventArgs e)
        {

        }

        private void UploadFolderTab_Click(object sender, EventArgs e)
        {

        }
    }
}


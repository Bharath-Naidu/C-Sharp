namespace UploadFolder
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.SelectFolderTab = new System.Windows.Forms.TabPage();
            this.LbSelectFolderStatus = new System.Windows.Forms.Label();
            this.Errorlabel1 = new System.Windows.Forms.Label();
            this.Errorlabel2 = new System.Windows.Forms.Label();
            this.Run = new System.Windows.Forms.Button();
            this.SelectedFolderLabel = new System.Windows.Forms.Label();
            this.SelectFolderLabel = new System.Windows.Forms.Label();
            this.Remove = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.SelectedFolders = new System.Windows.Forms.ListBox();
            this.Browse = new System.Windows.Forms.Button();
            this.SelectedPathFolder = new System.Windows.Forms.TextBox();
            this.UploadFolderTab = new System.Windows.Forms.TabPage();
            this.LbUploadStatus = new System.Windows.Forms.Label();
            this.BtnUpload = new System.Windows.Forms.Button();
            this.SPConnectionGroupBox = new System.Windows.Forms.GroupBox();
            this.Lberror = new System.Windows.Forms.Label();
            this.Tbusername = new System.Windows.Forms.TextBox();
            this.Lbsitedetails = new System.Windows.Forms.Label();
            this.Btnconnect = new System.Windows.Forms.Button();
            this.Lbsiteurl = new System.Windows.Forms.Label();
            this.Tbpassword = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.Label();
            this.Tbsiteurl = new System.Windows.Forms.TextBox();
            this.Lbpassword = new System.Windows.Forms.Label();
            this.Lbdocumentlibrary = new System.Windows.Forms.Label();
            this.Lbfoldername = new System.Windows.Forms.Label();
            this.CbDocumentlibrary = new System.Windows.Forms.ComboBox();
            this.CBfoldername = new System.Windows.Forms.ComboBox();
            this.ReportTab = new System.Windows.Forms.TabPage();
            this.DisplayGridButton = new System.Windows.Forms.Button();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.SelectedInfoLabel = new System.Windows.Forms.Label();
            this.DisplayCountButton = new System.Windows.Forms.Button();
            this.MonthsBox = new System.Windows.Forms.ComboBox();
            this.InformationBox = new System.Windows.Forms.ComboBox();
            this.MonthsLabel = new System.Windows.Forms.Label();
            this.InformationLabel = new System.Windows.Forms.Label();
            this.MainTabControl.SuspendLayout();
            this.SelectFolderTab.SuspendLayout();
            this.UploadFolderTab.SuspendLayout();
            this.SPConnectionGroupBox.SuspendLayout();
            this.ReportTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.SelectFolderTab);
            this.MainTabControl.Controls.Add(this.UploadFolderTab);
            this.MainTabControl.Controls.Add(this.ReportTab);
            this.MainTabControl.Location = new System.Drawing.Point(-11, 3);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1186, 750);
            this.MainTabControl.TabIndex = 0;
            // 
            // SelectFolderTab
            // 
            this.SelectFolderTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SelectFolderTab.BackgroundImage")));
            this.SelectFolderTab.Controls.Add(this.LbSelectFolderStatus);
            this.SelectFolderTab.Controls.Add(this.Errorlabel1);
            this.SelectFolderTab.Controls.Add(this.Errorlabel2);
            this.SelectFolderTab.Controls.Add(this.Run);
            this.SelectFolderTab.Controls.Add(this.SelectedFolderLabel);
            this.SelectFolderTab.Controls.Add(this.SelectFolderLabel);
            this.SelectFolderTab.Controls.Add(this.Remove);
            this.SelectFolderTab.Controls.Add(this.Add);
            this.SelectFolderTab.Controls.Add(this.SelectedFolders);
            this.SelectFolderTab.Controls.Add(this.Browse);
            this.SelectFolderTab.Controls.Add(this.SelectedPathFolder);
            this.SelectFolderTab.Location = new System.Drawing.Point(4, 22);
            this.SelectFolderTab.Name = "SelectFolderTab";
            this.SelectFolderTab.Padding = new System.Windows.Forms.Padding(3);
            this.SelectFolderTab.Size = new System.Drawing.Size(1178, 724);
            this.SelectFolderTab.TabIndex = 0;
            this.SelectFolderTab.Text = "SelectFolder";
            this.SelectFolderTab.UseVisualStyleBackColor = true;
            this.SelectFolderTab.Click += new System.EventHandler(this.SelectFolderTab_Click);
            // 
            // LbSelectFolderStatus
            // 
            this.LbSelectFolderStatus.AutoSize = true;
            this.LbSelectFolderStatus.BackColor = System.Drawing.Color.Gray;
            this.LbSelectFolderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbSelectFolderStatus.ForeColor = System.Drawing.Color.Transparent;
            this.LbSelectFolderStatus.Location = new System.Drawing.Point(535, 325);
            this.LbSelectFolderStatus.Name = "LbSelectFolderStatus";
            this.LbSelectFolderStatus.Size = new System.Drawing.Size(0, 16);
            this.LbSelectFolderStatus.TabIndex = 42;
            // 
            // Errorlabel1
            // 
            this.Errorlabel1.AutoSize = true;
            this.Errorlabel1.Location = new System.Drawing.Point(323, 106);
            this.Errorlabel1.Name = "Errorlabel1";
            this.Errorlabel1.Size = new System.Drawing.Size(0, 13);
            this.Errorlabel1.TabIndex = 41;
            // 
            // Errorlabel2
            // 
            this.Errorlabel2.AutoSize = true;
            this.Errorlabel2.Location = new System.Drawing.Point(510, 202);
            this.Errorlabel2.Name = "Errorlabel2";
            this.Errorlabel2.Size = new System.Drawing.Size(0, 13);
            this.Errorlabel2.TabIndex = 40;
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(297, 318);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 39;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // SelectedFolderLabel
            // 
            this.SelectedFolderLabel.AutoSize = true;
            this.SelectedFolderLabel.Location = new System.Drawing.Point(102, 159);
            this.SelectedFolderLabel.Name = "SelectedFolderLabel";
            this.SelectedFolderLabel.Size = new System.Drawing.Size(78, 13);
            this.SelectedFolderLabel.TabIndex = 38;
            this.SelectedFolderLabel.Text = "Selected folder";
            // 
            // SelectFolderLabel
            // 
            this.SelectFolderLabel.AutoSize = true;
            this.SelectFolderLabel.Location = new System.Drawing.Point(102, 65);
            this.SelectFolderLabel.Name = "SelectFolderLabel";
            this.SelectFolderLabel.Size = new System.Drawing.Size(69, 13);
            this.SelectFolderLabel.TabIndex = 37;
            this.SelectFolderLabel.Text = "Select Folder";
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(585, 159);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(75, 23);
            this.Remove.TabIndex = 36;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(585, 64);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 35;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // SelectedFolders
            // 
            this.SelectedFolders.FormattingEnabled = true;
            this.SelectedFolders.Location = new System.Drawing.Point(212, 159);
            this.SelectedFolders.Name = "SelectedFolders";
            this.SelectedFolders.Size = new System.Drawing.Size(253, 134);
            this.SelectedFolders.TabIndex = 34;
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(460, 65);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 33;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // SelectedPathFolder
            // 
            this.SelectedPathFolder.Location = new System.Drawing.Point(212, 67);
            this.SelectedPathFolder.Name = "SelectedPathFolder";
            this.SelectedPathFolder.Size = new System.Drawing.Size(253, 20);
            this.SelectedPathFolder.TabIndex = 32;
            // 
            // UploadFolderTab
            // 
            this.UploadFolderTab.BackColor = System.Drawing.Color.IndianRed;
            this.UploadFolderTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UploadFolderTab.BackgroundImage")));
            this.UploadFolderTab.Controls.Add(this.LbUploadStatus);
            this.UploadFolderTab.Controls.Add(this.BtnUpload);
            this.UploadFolderTab.Controls.Add(this.SPConnectionGroupBox);
            this.UploadFolderTab.Controls.Add(this.Lbdocumentlibrary);
            this.UploadFolderTab.Controls.Add(this.Lbfoldername);
            this.UploadFolderTab.Controls.Add(this.CbDocumentlibrary);
            this.UploadFolderTab.Controls.Add(this.CBfoldername);
            this.UploadFolderTab.Location = new System.Drawing.Point(4, 22);
            this.UploadFolderTab.Name = "UploadFolderTab";
            this.UploadFolderTab.Padding = new System.Windows.Forms.Padding(3);
            this.UploadFolderTab.Size = new System.Drawing.Size(1178, 724);
            this.UploadFolderTab.TabIndex = 1;
            this.UploadFolderTab.Text = "UploadFolder";
            this.UploadFolderTab.Click += new System.EventHandler(this.UploadFolderTab_Click);
            // 
            // LbUploadStatus
            // 
            this.LbUploadStatus.AutoSize = true;
            this.LbUploadStatus.BackColor = System.Drawing.Color.Gray;
            this.LbUploadStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbUploadStatus.ForeColor = System.Drawing.Color.Transparent;
            this.LbUploadStatus.Location = new System.Drawing.Point(491, 377);
            this.LbUploadStatus.Name = "LbUploadStatus";
            this.LbUploadStatus.Size = new System.Drawing.Size(0, 16);
            this.LbUploadStatus.TabIndex = 7;
            // 
            // BtnUpload
            // 
            this.BtnUpload.Location = new System.Drawing.Point(326, 372);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(79, 26);
            this.BtnUpload.TabIndex = 6;
            this.BtnUpload.Text = "Upload";
            this.BtnUpload.UseVisualStyleBackColor = true;
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // SPConnectionGroupBox
            // 
            this.SPConnectionGroupBox.BackColor = System.Drawing.Color.Gray;
            this.SPConnectionGroupBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SPConnectionGroupBox.BackgroundImage")));
            this.SPConnectionGroupBox.Controls.Add(this.Lberror);
            this.SPConnectionGroupBox.Controls.Add(this.Tbusername);
            this.SPConnectionGroupBox.Controls.Add(this.Lbsitedetails);
            this.SPConnectionGroupBox.Controls.Add(this.Btnconnect);
            this.SPConnectionGroupBox.Controls.Add(this.Lbsiteurl);
            this.SPConnectionGroupBox.Controls.Add(this.Tbpassword);
            this.SPConnectionGroupBox.Controls.Add(this.Username);
            this.SPConnectionGroupBox.Controls.Add(this.Tbsiteurl);
            this.SPConnectionGroupBox.Controls.Add(this.Lbpassword);
            this.SPConnectionGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SPConnectionGroupBox.Location = new System.Drawing.Point(97, 90);
            this.SPConnectionGroupBox.Name = "SPConnectionGroupBox";
            this.SPConnectionGroupBox.Size = new System.Drawing.Size(562, 222);
            this.SPConnectionGroupBox.TabIndex = 4;
            this.SPConnectionGroupBox.TabStop = false;
            // 
            // Lberror
            // 
            this.Lberror.AutoSize = true;
            this.Lberror.BackColor = System.Drawing.Color.Gray;
            this.Lberror.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lberror.ForeColor = System.Drawing.Color.Transparent;
            this.Lberror.Location = new System.Drawing.Point(284, 185);
            this.Lberror.Name = "Lberror";
            this.Lberror.Size = new System.Drawing.Size(0, 16);
            this.Lberror.TabIndex = 4;
            // 
            // Tbusername
            // 
            this.Tbusername.Location = new System.Drawing.Point(159, 105);
            this.Tbusername.Name = "Tbusername";
            this.Tbusername.Size = new System.Drawing.Size(154, 20);
            this.Tbusername.TabIndex = 2;
            // 
            // Lbsitedetails
            // 
            this.Lbsitedetails.AutoSize = true;
            this.Lbsitedetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbsitedetails.Location = new System.Drawing.Point(18, 26);
            this.Lbsitedetails.Name = "Lbsitedetails";
            this.Lbsitedetails.Size = new System.Drawing.Size(121, 25);
            this.Lbsitedetails.TabIndex = 1;
            this.Lbsitedetails.Text = "Site Details";
            // 
            // Btnconnect
            // 
            this.Btnconnect.Location = new System.Drawing.Point(168, 183);
            this.Btnconnect.Name = "Btnconnect";
            this.Btnconnect.Size = new System.Drawing.Size(79, 26);
            this.Btnconnect.TabIndex = 3;
            this.Btnconnect.Text = "Connect";
            this.Btnconnect.UseVisualStyleBackColor = true;
            this.Btnconnect.Click += new System.EventHandler(this.Btnconnect_Click);
            // 
            // Lbsiteurl
            // 
            this.Lbsiteurl.AutoSize = true;
            this.Lbsiteurl.Location = new System.Drawing.Point(89, 77);
            this.Lbsiteurl.Name = "Lbsiteurl";
            this.Lbsiteurl.Size = new System.Drawing.Size(41, 13);
            this.Lbsiteurl.TabIndex = 1;
            this.Lbsiteurl.Text = "Site Url";
            // 
            // Tbpassword
            // 
            this.Tbpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbpassword.Location = new System.Drawing.Point(159, 132);
            this.Tbpassword.Name = "Tbpassword";
            this.Tbpassword.PasswordChar = '*';
            this.Tbpassword.Size = new System.Drawing.Size(154, 26);
            this.Tbpassword.TabIndex = 2;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(78, 108);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(60, 13);
            this.Username.TabIndex = 1;
            this.Username.Text = "User Name";
            // 
            // Tbsiteurl
            // 
            this.Tbsiteurl.Location = new System.Drawing.Point(159, 75);
            this.Tbsiteurl.Name = "Tbsiteurl";
            this.Tbsiteurl.Size = new System.Drawing.Size(274, 20);
            this.Tbsiteurl.TabIndex = 2;
            // 
            // Lbpassword
            // 
            this.Lbpassword.AutoSize = true;
            this.Lbpassword.Location = new System.Drawing.Point(80, 144);
            this.Lbpassword.Name = "Lbpassword";
            this.Lbpassword.Size = new System.Drawing.Size(53, 13);
            this.Lbpassword.TabIndex = 1;
            this.Lbpassword.Text = "Password";
            // 
            // Lbdocumentlibrary
            // 
            this.Lbdocumentlibrary.AutoSize = true;
            this.Lbdocumentlibrary.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Lbdocumentlibrary.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbdocumentlibrary.Location = new System.Drawing.Point(220, 333);
            this.Lbdocumentlibrary.Name = "Lbdocumentlibrary";
            this.Lbdocumentlibrary.Size = new System.Drawing.Size(146, 17);
            this.Lbdocumentlibrary.TabIndex = 1;
            this.Lbdocumentlibrary.Text = "Document Library";
            // 
            // Lbfoldername
            // 
            this.Lbfoldername.AutoSize = true;
            this.Lbfoldername.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Lbfoldername.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbfoldername.Location = new System.Drawing.Point(242, 53);
            this.Lbfoldername.Name = "Lbfoldername";
            this.Lbfoldername.Size = new System.Drawing.Size(102, 17);
            this.Lbfoldername.TabIndex = 1;
            this.Lbfoldername.Text = "Folder Name";
            // 
            // CbDocumentlibrary
            // 
            this.CbDocumentlibrary.BackColor = System.Drawing.Color.AliceBlue;
            this.CbDocumentlibrary.FormattingEnabled = true;
            this.CbDocumentlibrary.Location = new System.Drawing.Point(378, 332);
            this.CbDocumentlibrary.Name = "CbDocumentlibrary";
            this.CbDocumentlibrary.Size = new System.Drawing.Size(121, 21);
            this.CbDocumentlibrary.TabIndex = 0;
            // 
            // CBfoldername
            // 
            this.CBfoldername.BackColor = System.Drawing.Color.Linen;
            this.CBfoldername.FormattingEnabled = true;
            this.CBfoldername.Location = new System.Drawing.Point(384, 51);
            this.CBfoldername.Name = "CBfoldername";
            this.CBfoldername.Size = new System.Drawing.Size(121, 21);
            this.CBfoldername.TabIndex = 0;
            this.CBfoldername.SelectedIndexChanged += new System.EventHandler(this.CBfoldername_SelectedIndexChanged);
            // 
            // ReportTab
            // 
            this.ReportTab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ReportTab.BackgroundImage")));
            this.ReportTab.Controls.Add(this.DisplayGridButton);
            this.ReportTab.Controls.Add(this.DataGridView);
            this.ReportTab.Controls.Add(this.SelectedInfoLabel);
            this.ReportTab.Controls.Add(this.DisplayCountButton);
            this.ReportTab.Controls.Add(this.MonthsBox);
            this.ReportTab.Controls.Add(this.InformationBox);
            this.ReportTab.Controls.Add(this.MonthsLabel);
            this.ReportTab.Controls.Add(this.InformationLabel);
            this.ReportTab.Location = new System.Drawing.Point(4, 22);
            this.ReportTab.Name = "ReportTab";
            this.ReportTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReportTab.Size = new System.Drawing.Size(1178, 724);
            this.ReportTab.TabIndex = 0;
            this.ReportTab.Text = "Reports";
            this.ReportTab.UseVisualStyleBackColor = true;
            // 
            // DisplayGridButton
            // 
            this.DisplayGridButton.Location = new System.Drawing.Point(344, 193);
            this.DisplayGridButton.Name = "DisplayGridButton";
            this.DisplayGridButton.Size = new System.Drawing.Size(79, 33);
            this.DisplayGridButton.TabIndex = 16;
            this.DisplayGridButton.UseVisualStyleBackColor = true;
            this.DisplayGridButton.Visible = false;
            this.DisplayGridButton.Click += new System.EventHandler(this.DisplayGridButton_Click);
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(27, 241);
            this.DataGridView.Name = "DataGridView";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView.Size = new System.Drawing.Size(688, 148);
            this.DataGridView.TabIndex = 15;
            this.DataGridView.Visible = false;
            // 
            // SelectedInfoLabel
            // 
            this.SelectedInfoLabel.AutoSize = true;
            this.SelectedInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedInfoLabel.Location = new System.Drawing.Point(229, 198);
            this.SelectedInfoLabel.Name = "SelectedInfoLabel";
            this.SelectedInfoLabel.Size = new System.Drawing.Size(100, 20);
            this.SelectedInfoLabel.TabIndex = 14;
            this.SelectedInfoLabel.Text = "SelectedInfo";
            this.SelectedInfoLabel.Visible = false;
            // 
            // DisplayCountButton
            // 
            this.DisplayCountButton.Location = new System.Drawing.Point(344, 141);
            this.DisplayCountButton.Name = "DisplayCountButton";
            this.DisplayCountButton.Size = new System.Drawing.Size(89, 26);
            this.DisplayCountButton.TabIndex = 13;
            this.DisplayCountButton.Text = "Display ";
            this.DisplayCountButton.UseVisualStyleBackColor = true;
            this.DisplayCountButton.Click += new System.EventHandler(this.DisplayCountButton_Click);
            // 
            // MonthsBox
            // 
            this.MonthsBox.FormattingEnabled = true;
            this.MonthsBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "6",
            "12"});
            this.MonthsBox.Location = new System.Drawing.Point(344, 80);
            this.MonthsBox.Name = "MonthsBox";
            this.MonthsBox.Size = new System.Drawing.Size(183, 21);
            this.MonthsBox.TabIndex = 12;
            // 
            // InformationBox
            // 
            this.InformationBox.BackColor = System.Drawing.SystemColors.Info;
            this.InformationBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InformationBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.InformationBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.InformationBox.FormattingEnabled = true;
            this.InformationBox.Location = new System.Drawing.Point(344, 26);
            this.InformationBox.Name = "InformationBox";
            this.InformationBox.Size = new System.Drawing.Size(183, 21);
            this.InformationBox.TabIndex = 11;
            // 
            // MonthsLabel
            // 
            this.MonthsLabel.AutoSize = true;
            this.MonthsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthsLabel.Location = new System.Drawing.Point(230, 78);
            this.MonthsLabel.Name = "MonthsLabel";
            this.MonthsLabel.Size = new System.Drawing.Size(99, 20);
            this.MonthsLabel.TabIndex = 10;
            this.MonthsLabel.Text = "SelectMonth";
            // 
            // InformationLabel
            // 
            this.InformationLabel.AutoSize = true;
            this.InformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InformationLabel.Location = new System.Drawing.Point(183, 27);
            this.InformationLabel.Name = "InformationLabel";
            this.InformationLabel.Size = new System.Drawing.Size(146, 20);
            this.InformationLabel.TabIndex = 9;
            this.InformationLabel.Text = "Type of Information";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.MainTabControl);
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(974, 542);
            this.Name = "Main";
            this.Text = "UploadFolder";
            this.Load += new System.EventHandler(this.Main_Load);
            this.MainTabControl.ResumeLayout(false);
            this.SelectFolderTab.ResumeLayout(false);
            this.SelectFolderTab.PerformLayout();
            this.UploadFolderTab.ResumeLayout(false);
            this.UploadFolderTab.PerformLayout();
            this.SPConnectionGroupBox.ResumeLayout(false);
            this.SPConnectionGroupBox.PerformLayout();
            this.ReportTab.ResumeLayout(false);
            this.ReportTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage SelectFolderTab;

        private System.Windows.Forms.TabPage UploadFolderTab;
        private System.Windows.Forms.TabPage ReportTab;
        private System.Windows.Forms.Label Lbfoldername;
        private System.Windows.Forms.ComboBox CBfoldername;
        private System.Windows.Forms.Label Lbsitedetails;
        private System.Windows.Forms.Button Btnconnect;
        private System.Windows.Forms.TextBox Tbpassword;
        private System.Windows.Forms.TextBox Tbusername;
        private System.Windows.Forms.Label Lbpassword;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label Lbsiteurl;
        private System.Windows.Forms.Label Lbdocumentlibrary;
        private System.Windows.Forms.ComboBox CbDocumentlibrary;
        private System.Windows.Forms.GroupBox SPConnectionGroupBox;
        private System.Windows.Forms.TextBox Tbsiteurl;
        private System.Windows.Forms.Label Lberror;
        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.Button DisplayGridButton;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Label SelectedInfoLabel;
        private System.Windows.Forms.Button DisplayCountButton;
        private System.Windows.Forms.ComboBox MonthsBox;
        private System.Windows.Forms.ComboBox InformationBox;
        private System.Windows.Forms.Label MonthsLabel;
        private System.Windows.Forms.Label InformationLabel;
        private System.Windows.Forms.Label Errorlabel1;
        private System.Windows.Forms.Label Errorlabel2;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Label SelectedFolderLabel;
        private System.Windows.Forms.Label SelectFolderLabel;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.ListBox SelectedFolders;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.TextBox SelectedPathFolder;
        private System.Windows.Forms.Label LbSelectFolderStatus;
        private System.Windows.Forms.Label LbUploadStatus;
    }
}


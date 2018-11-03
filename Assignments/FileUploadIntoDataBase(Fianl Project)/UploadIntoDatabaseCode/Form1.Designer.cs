namespace WindowsFormsApp1
{
    partial class Form1
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
            this.SelectedPathFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SelectedFolders = new System.Windows.Forms.ListBox();
            this.Add = new System.Windows.Forms.Button();
            this.Remove = new System.Windows.Forms.Button();
            this.SelectFolderLabel = new System.Windows.Forms.Label();
            this.SelectedFolderLabel = new System.Windows.Forms.Label();
            this.Run = new System.Windows.Forms.Button();
            this.Errorlabel2 = new System.Windows.Forms.Label();
            this.Errorlabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectedPathFolder
            // 
            this.SelectedPathFolder.Location = new System.Drawing.Point(157, 90);
            this.SelectedPathFolder.Name = "SelectedPathFolder";
            this.SelectedPathFolder.Size = new System.Drawing.Size(253, 20);
            this.SelectedPathFolder.TabIndex = 0;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest_1);
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(405, 88);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 1;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // SelectedFolders
            // 
            this.SelectedFolders.FormattingEnabled = true;
            this.SelectedFolders.Location = new System.Drawing.Point(157, 182);
            this.SelectedFolders.Name = "SelectedFolders";
            this.SelectedFolders.Size = new System.Drawing.Size(253, 134);
            this.SelectedFolders.TabIndex = 2;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(530, 87);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 3;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(530, 182);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(75, 23);
            this.Remove.TabIndex = 4;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // SelectFolderLabel
            // 
            this.SelectFolderLabel.AutoSize = true;
            this.SelectFolderLabel.Location = new System.Drawing.Point(47, 88);
            this.SelectFolderLabel.Name = "SelectFolderLabel";
            this.SelectFolderLabel.Size = new System.Drawing.Size(69, 13);
            this.SelectFolderLabel.TabIndex = 5;
            this.SelectFolderLabel.Text = "Select Folder";
            // 
            // SelectedFolderLabel
            // 
            this.SelectedFolderLabel.AutoSize = true;
            this.SelectedFolderLabel.Location = new System.Drawing.Point(47, 182);
            this.SelectedFolderLabel.Name = "SelectedFolderLabel";
            this.SelectedFolderLabel.Size = new System.Drawing.Size(78, 13);
            this.SelectedFolderLabel.TabIndex = 6;
            this.SelectedFolderLabel.Text = "Selected folder";
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(335, 345);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 7;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Errorlabel2
            // 
            this.Errorlabel2.AutoSize = true;
            this.Errorlabel2.Location = new System.Drawing.Point(455, 225);
            this.Errorlabel2.Name = "Errorlabel2";
            this.Errorlabel2.Size = new System.Drawing.Size(0, 13);
            this.Errorlabel2.TabIndex = 10;
            // 
            // Errorlabel1
            // 
            this.Errorlabel1.AutoSize = true;
            this.Errorlabel1.Location = new System.Drawing.Point(268, 129);
            this.Errorlabel1.Name = "Errorlabel1";
            this.Errorlabel1.Size = new System.Drawing.Size(0, 13);
            this.Errorlabel1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Errorlabel1);
            this.Controls.Add(this.Errorlabel2);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.SelectedFolderLabel);
            this.Controls.Add(this.SelectFolderLabel);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.SelectedFolders);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.SelectedPathFolder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SelectedPathFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox SelectedFolders;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Label SelectFolderLabel;
        private System.Windows.Forms.Label SelectedFolderLabel;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Label Errorlabel2;
        private System.Windows.Forms.Label Errorlabel1;
    }
}


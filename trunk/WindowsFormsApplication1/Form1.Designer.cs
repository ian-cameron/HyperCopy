namespace WindowsFormsApplication1
{
    partial class HyperCopy
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
            this.labelDir1 = new System.Windows.Forms.Label();
            this.textBoxDir1 = new System.Windows.Forms.TextBox();
            this.buttonDir1 = new System.Windows.Forms.Button();
            this.labelDir2 = new System.Windows.Forms.Label();
            this.textBoxDir2 = new System.Windows.Forms.TextBox();
            this.buttonDir2 = new System.Windows.Forms.Button();
            this.checkBoxOverwrite = new System.Windows.Forms.CheckBox();
            this.checkBoxSubFolders = new System.Windows.Forms.CheckBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.textBoxExts = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Directory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastMod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NewPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSimulate = new System.Windows.Forms.Button();
            this.labelParentFolderFilter = new System.Windows.Forms.Label();
            this.textBoxParentFolderFilter = new System.Windows.Forms.TextBox();
            this.comboBoxOptions = new System.Windows.Forms.ComboBox();
            this.labelOptions = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonCSV = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBoxOverwriteNewer = new System.Windows.Forms.CheckBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBoxExclude2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelDir1
            // 
            this.labelDir1.AutoSize = true;
            this.labelDir1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDir1.Location = new System.Drawing.Point(14, 33);
            this.labelDir1.Name = "labelDir1";
            this.labelDir1.Size = new System.Drawing.Size(116, 17);
            this.labelDir1.TabIndex = 0;
            this.labelDir1.Text = "Source directory:";
            // 
            // textBoxDir1
            // 
            this.textBoxDir1.Location = new System.Drawing.Point(16, 53);
            this.textBoxDir1.Name = "textBoxDir1";
            this.textBoxDir1.Size = new System.Drawing.Size(301, 22);
            this.textBoxDir1.TabIndex = 1;
            this.textBoxDir1.Text = "C:\\temp";
            // 
            // buttonDir1
            // 
            this.buttonDir1.Location = new System.Drawing.Point(323, 52);
            this.buttonDir1.Name = "buttonDir1";
            this.buttonDir1.Size = new System.Drawing.Size(75, 23);
            this.buttonDir1.TabIndex = 2;
            this.buttonDir1.Text = "Browse...";
            this.buttonDir1.UseVisualStyleBackColor = true;
            this.buttonDir1.Click += new System.EventHandler(this.buttonDir1_Click);
            // 
            // labelDir2
            // 
            this.labelDir2.AutoSize = true;
            this.labelDir2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDir2.Location = new System.Drawing.Point(15, 105);
            this.labelDir2.Name = "labelDir2";
            this.labelDir2.Size = new System.Drawing.Size(142, 17);
            this.labelDir2.TabIndex = 3;
            this.labelDir2.Text = "Destination directory:";
            // 
            // textBoxDir2
            // 
            this.textBoxDir2.Location = new System.Drawing.Point(16, 125);
            this.textBoxDir2.Name = "textBoxDir2";
            this.textBoxDir2.Size = new System.Drawing.Size(301, 22);
            this.textBoxDir2.TabIndex = 5;
            this.textBoxDir2.Text = "C:\\test";
            this.textBoxDir2.TextChanged += new System.EventHandler(this.textBoxDir2_TextChanged);
            // 
            // buttonDir2
            // 
            this.buttonDir2.Location = new System.Drawing.Point(323, 125);
            this.buttonDir2.Name = "buttonDir2";
            this.buttonDir2.Size = new System.Drawing.Size(75, 23);
            this.buttonDir2.TabIndex = 6;
            this.buttonDir2.Text = "Browse...";
            this.buttonDir2.UseVisualStyleBackColor = true;
            this.buttonDir2.Click += new System.EventHandler(this.buttonDir2_Click);
            // 
            // checkBoxOverwrite
            // 
            this.checkBoxOverwrite.AutoSize = true;
            this.checkBoxOverwrite.Checked = true;
            this.checkBoxOverwrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOverwrite.Location = new System.Drawing.Point(17, 400);
            this.checkBoxOverwrite.Name = "checkBoxOverwrite";
            this.checkBoxOverwrite.Size = new System.Drawing.Size(178, 21);
            this.checkBoxOverwrite.TabIndex = 7;
            this.checkBoxOverwrite.Text = "Overwrite existing files?";
            this.checkBoxOverwrite.UseVisualStyleBackColor = true;
            this.checkBoxOverwrite.CheckedChanged += new System.EventHandler(this.checkBoxOverwrite_CheckedChanged);
            // 
            // checkBoxSubFolders
            // 
            this.checkBoxSubFolders.AutoSize = true;
            this.checkBoxSubFolders.Checked = true;
            this.checkBoxSubFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSubFolders.Location = new System.Drawing.Point(17, 81);
            this.checkBoxSubFolders.Name = "checkBoxSubFolders";
            this.checkBoxSubFolders.Size = new System.Drawing.Size(300, 21);
            this.checkBoxSubFolders.TabIndex = 3;
            this.checkBoxSubFolders.Text = "Include sub-subfolders and files in search?";
            this.checkBoxSubFolders.UseVisualStyleBackColor = true;
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilter.Location = new System.Drawing.Point(14, 197);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(306, 17);
            this.labelFilter.TabIndex = 8;
            this.labelFilter.Text = "Files with these extensions (comma separated):";
            // 
            // textBoxExts
            // 
            this.textBoxExts.Location = new System.Drawing.Point(16, 221);
            this.textBoxExts.Name = "textBoxExts";
            this.textBoxExts.Size = new System.Drawing.Size(382, 22);
            this.textBoxExts.TabIndex = 8;
            this.textBoxExts.Text = "test, tmp";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Filename,
            this.Directory,
            this.ItemSize,
            this.LastMod,
            this.NewPath});
            this.listView1.Location = new System.Drawing.Point(448, 32);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(756, 398);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Filename
            // 
            this.Filename.Text = "File Name";
            this.Filename.Width = -2;
            // 
            // Directory
            // 
            this.Directory.Text = "Found in folder";
            this.Directory.Width = -2;
            // 
            // ItemSize
            // 
            this.ItemSize.Text = "Size in KB";
            this.ItemSize.Width = -2;
            // 
            // LastMod
            // 
            this.LastMod.Text = "Last Modification";
            this.LastMod.Width = -1;
            // 
            // NewPath
            // 
            this.NewPath.Text = "New Location";
            this.NewPath.Width = -2;
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.Location = new System.Drawing.Point(17, 296);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(75, 23);
            this.buttonSimulate.TabIndex = 11;
            this.buttonSimulate.Text = "Search";
            this.buttonSimulate.UseVisualStyleBackColor = true;
            this.buttonSimulate.Click += new System.EventHandler(this.buttonSimulate_Click);
            // 
            // labelParentFolderFilter
            // 
            this.labelParentFolderFilter.AutoSize = true;
            this.labelParentFolderFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParentFolderFilter.Location = new System.Drawing.Point(14, 248);
            this.labelParentFolderFilter.Name = "labelParentFolderFilter";
            this.labelParentFolderFilter.Size = new System.Drawing.Size(387, 17);
            this.labelParentFolderFilter.TabIndex = 12;
            this.labelParentFolderFilter.Text = "Entire folders containing at least 1 file with these extensions:";
            // 
            // textBoxParentFolderFilter
            // 
            this.textBoxParentFolderFilter.Location = new System.Drawing.Point(18, 268);
            this.textBoxParentFolderFilter.Name = "textBoxParentFolderFilter";
            this.textBoxParentFolderFilter.Size = new System.Drawing.Size(380, 22);
            this.textBoxParentFolderFilter.TabIndex = 9;
            // 
            // comboBoxOptions
            // 
            this.comboBoxOptions.FormattingEnabled = true;
            this.comboBoxOptions.Items.AddRange(new object[] {
            "Move files and folders; create a shortcut (.lnk) at old location.",
            "Move files and folders; do not create a shortcut.",
            "Copy files and folders; create a shortcut (.lnk) at original location.",
            "Copy files and folders; do not create a shortcut."});
            this.comboBoxOptions.Location = new System.Drawing.Point(12, 370);
            this.comboBoxOptions.Name = "comboBoxOptions";
            this.comboBoxOptions.Size = new System.Drawing.Size(381, 24);
            this.comboBoxOptions.TabIndex = 10;
            // 
            // labelOptions
            // 
            this.labelOptions.AutoSize = true;
            this.labelOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOptions.Location = new System.Drawing.Point(12, 347);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(58, 17);
            this.labelOptions.TabIndex = 15;
            this.labelOptions.Text = "Action:";
            // 
            // buttonRun
            // 
            this.buttonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRun.ForeColor = System.Drawing.Color.Firebrick;
            this.buttonRun.Location = new System.Drawing.Point(17, 455);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(302, 23);
            this.buttonRun.TabIndex = 17;
            this.buttonRun.Text = "Run selected action on search results";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonCSV
            // 
            this.buttonCSV.Location = new System.Drawing.Point(1062, 455);
            this.buttonCSV.Name = "buttonCSV";
            this.buttonCSV.Size = new System.Drawing.Size(142, 23);
            this.buttonCSV.TabIndex = 18;
            this.buttonCSV.Text = "Save list to CSV...";
            this.buttonCSV.UseVisualStyleBackColor = true;
            this.buttonCSV.Visible = false;
            this.buttonCSV.Click += new System.EventHandler(this.buttonCSV_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(322, 455);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 21;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(448, 455);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(588, 23);
            this.progressBar1.TabIndex = 22;
            this.progressBar1.Visible = false;
            // 
            // checkBoxOverwriteNewer
            // 
            this.checkBoxOverwriteNewer.AutoSize = true;
            this.checkBoxOverwriteNewer.Location = new System.Drawing.Point(212, 400);
            this.checkBoxOverwriteNewer.Name = "checkBoxOverwriteNewer";
            this.checkBoxOverwriteNewer.Size = new System.Drawing.Size(178, 21);
            this.checkBoxOverwriteNewer.TabIndex = 23;
            this.checkBoxOverwriteNewer.Text = "even if they are newer?";
            this.checkBoxOverwriteNewer.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(13, 498);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 17);
            this.labelStatus.TabIndex = 24;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 571);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(1191, 100);
            this.listBox1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 551);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Messages:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(445, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(366, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Search Results (unselect to exclude from action):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Search filters:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "File Locations:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1017, 674);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(186, 17);
            this.linkLabel1.TabIndex = 30;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Copy messages to clipboard";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Lis);
            // 
            // checkBoxExclude2
            // 
            this.checkBoxExclude2.AutoSize = true;
            this.checkBoxExclude2.Checked = true;
            this.checkBoxExclude2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExclude2.Location = new System.Drawing.Point(115, 296);
            this.checkBoxExclude2.Name = "checkBoxExclude2";
            this.checkBoxExclude2.Size = new System.Drawing.Size(220, 21);
            this.checkBoxExclude2.TabIndex = 31;
            this.checkBoxExclude2.Text = "excluding folders on first level.";
            this.checkBoxExclude2.UseVisualStyleBackColor = true;
            // 
            // HyperCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 709);
            this.Controls.Add(this.checkBoxExclude2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.checkBoxOverwriteNewer);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCSV);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.labelOptions);
            this.Controls.Add(this.comboBoxOptions);
            this.Controls.Add(this.textBoxParentFolderFilter);
            this.Controls.Add(this.labelParentFolderFilter);
            this.Controls.Add(this.buttonSimulate);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBoxExts);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.checkBoxSubFolders);
            this.Controls.Add(this.checkBoxOverwrite);
            this.Controls.Add(this.buttonDir2);
            this.Controls.Add(this.textBoxDir2);
            this.Controls.Add(this.labelDir2);
            this.Controls.Add(this.buttonDir1);
            this.Controls.Add(this.textBoxDir1);
            this.Controls.Add(this.labelDir1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "HyperCopy";
            this.Text = "HyperCopy";
            this.Load += new System.EventHandler(this.HyperCopy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDir1;
        private System.Windows.Forms.TextBox textBoxDir1;
        private System.Windows.Forms.Button buttonDir1;
        private System.Windows.Forms.Label labelDir2;
        private System.Windows.Forms.TextBox textBoxDir2;
        private System.Windows.Forms.Button buttonDir2;
        private System.Windows.Forms.CheckBox checkBoxOverwrite;
        private System.Windows.Forms.CheckBox checkBoxSubFolders;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.TextBox textBoxExts;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonSimulate;
        private System.Windows.Forms.Label labelParentFolderFilter;
        private System.Windows.Forms.TextBox textBoxParentFolderFilter;
        private System.Windows.Forms.ComboBox comboBoxOptions;
        private System.Windows.Forms.Label labelOptions;
        private System.Windows.Forms.ColumnHeader Filename;
        private System.Windows.Forms.ColumnHeader Directory;
        private System.Windows.Forms.ColumnHeader ItemSize;
        private System.Windows.Forms.ColumnHeader LastMod;
        private System.Windows.Forms.ColumnHeader NewPath;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonCSV;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBoxOverwriteNewer;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox checkBoxExclude2;
    }
}


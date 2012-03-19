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
            this.checkBoxSubfolderPreserve = new System.Windows.Forms.CheckBox();
            this.checkBoxSubFolders = new System.Windows.Forms.CheckBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.textBoxExts = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Directory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastMod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NewPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusErrors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSimulate = new System.Windows.Forms.Button();
            this.labelParentFolderFilter = new System.Windows.Forms.Label();
            this.textBoxParentFolderFilter = new System.Windows.Forms.TextBox();
            this.comboBoxOptions = new System.Windows.Forms.ComboBox();
            this.labelOptions = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonCSV = new System.Windows.Forms.Button();
            this.labelProgress = new System.Windows.Forms.Label();
            this.checkBoxSupressErrors = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // labelDir1
            // 
            this.labelDir1.AutoSize = true;
            this.labelDir1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDir1.Location = new System.Drawing.Point(13, 12);
            this.labelDir1.Name = "labelDir1";
            this.labelDir1.Size = new System.Drawing.Size(133, 17);
            this.labelDir1.TabIndex = 0;
            this.labelDir1.Text = "Source directory:";
            // 
            // textBoxDir1
            // 
            this.textBoxDir1.Location = new System.Drawing.Point(15, 32);
            this.textBoxDir1.Name = "textBoxDir1";
            this.textBoxDir1.Size = new System.Drawing.Size(273, 22);
            this.textBoxDir1.TabIndex = 1;
            this.textBoxDir1.Text = "C:\\temp";
            // 
            // buttonDir1
            // 
            this.buttonDir1.Location = new System.Drawing.Point(16, 61);
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
            this.labelDir2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDir2.Location = new System.Drawing.Point(13, 141);
            this.labelDir2.Name = "labelDir2";
            this.labelDir2.Size = new System.Drawing.Size(164, 17);
            this.labelDir2.TabIndex = 3;
            this.labelDir2.Text = "Destination directory:";
            // 
            // textBoxDir2
            // 
            this.textBoxDir2.Location = new System.Drawing.Point(14, 161);
            this.textBoxDir2.Name = "textBoxDir2";
            this.textBoxDir2.Size = new System.Drawing.Size(273, 22);
            this.textBoxDir2.TabIndex = 5;
            this.textBoxDir2.Text = "C:\\test";
            // 
            // buttonDir2
            // 
            this.buttonDir2.Location = new System.Drawing.Point(16, 189);
            this.buttonDir2.Name = "buttonDir2";
            this.buttonDir2.Size = new System.Drawing.Size(75, 23);
            this.buttonDir2.TabIndex = 6;
            this.buttonDir2.Text = "Browse...";
            this.buttonDir2.UseVisualStyleBackColor = true;
            this.buttonDir2.Click += new System.EventHandler(this.buttonDir2_Click);
            // 
            // checkBoxSubfolderPreserve
            // 
            this.checkBoxSubfolderPreserve.AutoSize = true;
            this.checkBoxSubfolderPreserve.Checked = true;
            this.checkBoxSubfolderPreserve.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSubfolderPreserve.Location = new System.Drawing.Point(20, 218);
            this.checkBoxSubfolderPreserve.Name = "checkBoxSubfolderPreserve";
            this.checkBoxSubfolderPreserve.Size = new System.Drawing.Size(304, 21);
            this.checkBoxSubfolderPreserve.TabIndex = 7;
            this.checkBoxSubfolderPreserve.Text = "Preserve subfolder structure when moving?";
            this.checkBoxSubfolderPreserve.UseVisualStyleBackColor = true;
            this.checkBoxSubfolderPreserve.Visible = false;
            // 
            // checkBoxSubFolders
            // 
            this.checkBoxSubFolders.AutoSize = true;
            this.checkBoxSubFolders.Checked = true;
            this.checkBoxSubFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSubFolders.Location = new System.Drawing.Point(20, 91);
            this.checkBoxSubFolders.Name = "checkBoxSubFolders";
            this.checkBoxSubFolders.Size = new System.Drawing.Size(300, 21);
            this.checkBoxSubFolders.TabIndex = 3;
            this.checkBoxSubFolders.Text = "Include sub-subfolders and files in search?";
            this.checkBoxSubFolders.UseVisualStyleBackColor = true;
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilter.Location = new System.Drawing.Point(13, 275);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(391, 17);
            this.labelFilter.TabIndex = 8;
            this.labelFilter.Text = "Move files with these extensions (comma separated):";
            // 
            // textBoxExts
            // 
            this.textBoxExts.Location = new System.Drawing.Point(15, 299);
            this.textBoxExts.Name = "textBoxExts";
            this.textBoxExts.Size = new System.Drawing.Size(271, 22);
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
            this.NewPath,
            this.StatusErrors});
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
            this.Directory.Text = "In Folder";
            this.Directory.Width = -2;
            // 
            // ItemSize
            // 
            this.ItemSize.Text = "Size KB";
            this.ItemSize.Width = -2;
            // 
            // LastMod
            // 
            this.LastMod.Text = "Last Modification";
            this.LastMod.Width = -2;
            // 
            // NewPath
            // 
            this.NewPath.Text = "New Location";
            this.NewPath.Width = -2;
            // 
            // StatusErrors
            // 
            this.StatusErrors.Text = "Status";
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.Location = new System.Drawing.Point(16, 449);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(75, 23);
            this.buttonSimulate.TabIndex = 11;
            this.buttonSimulate.Text = "Simulate";
            this.buttonSimulate.UseVisualStyleBackColor = true;
            this.buttonSimulate.Click += new System.EventHandler(this.buttonSimulate_Click);
            // 
            // labelParentFolderFilter
            // 
            this.labelParentFolderFilter.AutoSize = true;
            this.labelParentFolderFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParentFolderFilter.Location = new System.Drawing.Point(13, 333);
            this.labelParentFolderFilter.Name = "labelParentFolderFilter";
            this.labelParentFolderFilter.Size = new System.Drawing.Size(428, 17);
            this.labelParentFolderFilter.TabIndex = 12;
            this.labelParentFolderFilter.Text = "Move entire folders containing files with these extensions:";
            // 
            // textBoxParentFolderFilter
            // 
            this.textBoxParentFolderFilter.Location = new System.Drawing.Point(12, 354);
            this.textBoxParentFolderFilter.Name = "textBoxParentFolderFilter";
            this.textBoxParentFolderFilter.Size = new System.Drawing.Size(272, 22);
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
            this.comboBoxOptions.Location = new System.Drawing.Point(16, 419);
            this.comboBoxOptions.Name = "comboBoxOptions";
            this.comboBoxOptions.Size = new System.Drawing.Size(381, 24);
            this.comboBoxOptions.TabIndex = 10;
            // 
            // labelOptions
            // 
            this.labelOptions.AutoSize = true;
            this.labelOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOptions.Location = new System.Drawing.Point(16, 396);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(58, 17);
            this.labelOptions.TabIndex = 15;
            this.labelOptions.Text = "Action:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(448, 437);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 17);
            this.labelStatus.TabIndex = 16;
            // 
            // buttonRun
            // 
            this.buttonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRun.ForeColor = System.Drawing.Color.Firebrick;
            this.buttonRun.Location = new System.Drawing.Point(102, 449);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 17;
            this.buttonRun.Text = "Run Now";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Visible = false;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonCSV
            // 
            this.buttonCSV.Location = new System.Drawing.Point(1062, 446);
            this.buttonCSV.Name = "buttonCSV";
            this.buttonCSV.Size = new System.Drawing.Size(142, 23);
            this.buttonCSV.TabIndex = 18;
            this.buttonCSV.Text = "Save list to CSV...";
            this.buttonCSV.UseVisualStyleBackColor = true;
            this.buttonCSV.Visible = false;
            this.buttonCSV.Click += new System.EventHandler(this.buttonCSV_Click);
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(201, 455);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 17);
            this.labelProgress.TabIndex = 19;
            // 
            // checkBoxSupressErrors
            // 
            this.checkBoxSupressErrors.AutoSize = true;
            this.checkBoxSupressErrors.Location = new System.Drawing.Point(20, 110);
            this.checkBoxSupressErrors.Name = "checkBoxSupressErrors";
            this.checkBoxSupressErrors.Size = new System.Drawing.Size(294, 21);
            this.checkBoxSupressErrors.TabIndex = 4;
            this.checkBoxSupressErrors.Text = "Ignore permission errors and keep going?";
            this.checkBoxSupressErrors.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(16, 449);
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
            // HyperCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 481);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBoxSupressErrors);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.buttonCSV);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelOptions);
            this.Controls.Add(this.comboBoxOptions);
            this.Controls.Add(this.textBoxParentFolderFilter);
            this.Controls.Add(this.labelParentFolderFilter);
            this.Controls.Add(this.buttonSimulate);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBoxExts);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.checkBoxSubFolders);
            this.Controls.Add(this.checkBoxSubfolderPreserve);
            this.Controls.Add(this.buttonDir2);
            this.Controls.Add(this.textBoxDir2);
            this.Controls.Add(this.labelDir2);
            this.Controls.Add(this.buttonDir1);
            this.Controls.Add(this.textBoxDir1);
            this.Controls.Add(this.labelDir1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "HyperCopy";
            this.Text = "HyperMove";
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
        private System.Windows.Forms.CheckBox checkBoxSubfolderPreserve;
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
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonCSV;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.CheckBox checkBoxSupressErrors;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ColumnHeader StatusErrors;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}


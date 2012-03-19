using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using IWshRuntimeLibrary;
using NLog;

namespace WindowsFormsApplication1
{
    public partial class HyperCopy : Form
    {
        private FolderBrowserDialog FileBrowser1 = new FolderBrowserDialog();
        private FolderBrowserDialog FileBrowser2 = new FolderBrowserDialog();
        private long bytes = 0;
        private bool stoploop = false;
        private string[] exts; 
        private string[] folderexts;
        private string sourcedir;
        private string td;
        private SearchOption so = SearchOption.AllDirectories;
        private BackgroundWorker bw = new BackgroundWorker();
        private BackgroundWorker bwUI = new BackgroundWorker();
        private BackgroundWorker bwMove = new BackgroundWorker();
        private int finalsize;
        private int seconds = 0;
        private Logger logger = LogManager.GetLogger("HyperCopy");
        private bool createshortcut = true;
        private bool optionalcopy = false;
        
        public HyperCopy()
        {
            InitializeComponent();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bwMove.WorkerSupportsCancellation = true;
            bwMove.WorkerReportsProgress = true;
            bwMove.DoWork += new DoWorkEventHandler(bwMove_DoWork);
            bwMove.ProgressChanged += new ProgressChangedEventHandler(bwMove_ProgressChanged);
            bwMove.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwMove_RunWorkerCompleted);
            bwUI.WorkerReportsProgress=true;
            bwUI.DoWork += new DoWorkEventHandler(bwUI_DoWork);
            bwUI.ProgressChanged += new ProgressChangedEventHandler(bwUI_ProgressChanged);
            bwUI.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(bwUIWorkCompleted);
            bwUI.WorkerSupportsCancellation = true;
            FileBrowser1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            FileBrowser1.ShowNewFolderButton = true;
            FileBrowser2.RootFolder = System.Environment.SpecialFolder.MyComputer;
            FileBrowser2.ShowNewFolderButton = true;
            comboBoxOptions.SelectedIndex = 0;
            initListView();
            buttonRun.Enabled = false;


        }

        private void HyperCopy_Load(object sender, EventArgs e)
        {

        }

        private void bwUI_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                Thread.Sleep(500);
                if (bw.CancellationPending)
                    return;
                bwUI.ReportProgress(0, ".");
                Thread.Sleep(500);
                if (bw.CancellationPending)
                    return; 
                bwUI.ReportProgress(0, "..");
                Thread.Sleep(500);
                if (bw.CancellationPending)
                    return;
                bwUI.ReportProgress(0, "...");
                Thread.Sleep(500);
                if (bw.CancellationPending)
                    return;
                bwUI.ReportProgress(0, "....");
            }
            while (bw.IsBusy);
        }

        private void bwUI_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
         labelProgress.Text="Processing." + e.UserState;
        }

        private void bwUIWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelProgress.Text = "Complete.";
        }

        private void initListView() 
        {
            listView1.Clear();
            bytes = 0;
            finalsize = 0;
            stoploop = false;
            buttonCSV.Visible = false;
            buttonRun.Visible = false;
            buttonRun.Enabled = false;
            labelStatus.Text = "";
            labelProgress.Text = "Ready.";
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.CheckBoxes = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            ColumnHeader[] cols = {Filename,Directory,ItemSize,LastMod,NewPath,StatusErrors};
            listView1.Columns.AddRange(cols);
            listView1.Update();
        }

        private void buttonDir1_Click(object sender, EventArgs e)
        {
            if (FileBrowser1.ShowDialog() == DialogResult.OK)
            {
                textBoxDir1.Text = FileBrowser1.SelectedPath;
            }
        }

        private void buttonDir2_Click(object sender, EventArgs e)
        {
            if (FileBrowser2.ShowDialog() == DialogResult.OK)
            {
                textBoxDir2.Text = FileBrowser2.SelectedPath;
            }
        }

        private void buttonSimulate_Click(object sender, EventArgs e)
        {
            string filtered = textBoxExts.Text.Replace(" ", "");
            filtered = filtered.Replace(".", "");
            exts = filtered.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string filtereddirs = textBoxParentFolderFilter.Text.Replace(" ", "");
            filtereddirs = filtereddirs.Replace(".", "");
            folderexts = filtereddirs.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string a in exts) {
                foreach (string b in folderexts) {
                    if (a == b)
                    {
                        MessageBox.Show("Too redundant to have the same extension in both searches.");
                        return;
                    }
                }
            }
            
            if (listView1.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show("This will clear the current search results, are you sure?", "Yes", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                    initListView();
            }
            try
            {   
                DirectoryInfo source = new DirectoryInfo(textBoxDir1.Text);
                DirectoryInfo dest = new DirectoryInfo(textBoxDir2.Text);
                sourcedir = source.FullName;
                td = dest.FullName;
                if (source.Root.Name == source.Name)
                    td = td+ "\\";
            }
            catch (DirectoryNotFoundException dnfe)
            { MessageBox.Show("Path not found: {0}\n" + dnfe.Message.ToString()); }
            catch (UnauthorizedAccessException uae)
            { MessageBox.Show("Check Permissions: \n" + uae.Message.ToString()); }
            catch (ArgumentException ae)
            { MessageBox.Show("Need a valid path: \n" + ae.Message.ToString()); }


            if (!checkBoxSubFolders.Checked)
                so = SearchOption.TopDirectoryOnly;
            else
                so = SearchOption.AllDirectories;
            if (!bwUI.IsBusy)
                bwUI.RunWorkerAsync();
            //Start background process
            if (bw.IsBusy != true)
            {
                buttonCancel.Visible = true;
                bw.RunWorkerAsync();
            }

        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                // Data structure to hold names of subfolders to be
                // examined for files.
                string root = sourcedir;
                Stack<string> dirs = new Stack<string>(20);

                if (!System.IO.Directory.Exists(root))
                {
                    throw new ArgumentException();
                }
                dirs.Push(root);
                string[] subDirs = { };
                while (dirs.Count > 0)
                {
                    string currentDir = dirs.Pop();
                    try
                    {
                        subDirs = System.IO.Directory.GetDirectories(currentDir);
                    }
                    catch (DirectoryNotFoundException dnfe)
                    { MessageBox.Show("Path not found: {0}\n" + dnfe.Message.ToString()); }
                    catch (UnauthorizedAccessException uae)
                    {
                        if (checkBoxSupressErrors.Checked)
                            continue;
                        MessageBox.Show("Check Permissions: \n" + uae.Message.ToString());
                        continue;
                    }
                    catch (ArgumentException ae)
                    { MessageBox.Show("Need a valid path: \n" + ae.Message.ToString()); }
                    catch (Exception ge)
                    { MessageBox.Show("Unknown exception: " + ge.Message); }

                    string[] files = null;
                    stoploop = false;
                    bw.ReportProgress(0, currentDir);
                    try
                    {
                        files = System.IO.Directory.GetFiles(currentDir);
                    }
                    catch (DirectoryNotFoundException dnfe)
                    { MessageBox.Show("Path not found: {0}\n" + dnfe.Message.ToString()); }
                    catch (UnauthorizedAccessException uae)
                    { MessageBox.Show("Check Permissions: \n" + uae.Message.ToString()); }
                    catch (ArgumentException ae)
                    { MessageBox.Show("Need a valid path: \n" + ae.Message.ToString()); }
                    catch (NullReferenceException nr)
                    { MessageBox.Show(nr.Message.ToString()); }
                    // Perform the required action on each file here.
                    // Modify this block to perform your required task.
                    try
                    {
                        foreach (string f in files)
                        {

                            foreach (string ext in exts)
                            {
                                if (f.EndsWith("." + ext))
                                {
                                    try
                                    {
                                        FileInfo file = new FileInfo(f);
                                        string target = (td + currentDir.Replace(sourcedir, ""));
                                        string[] subitems = { file.Name, currentDir, (file.Length / 1024).ToString(), file.LastWriteTime.ToShortDateString(), target.ToString(), "-" };
                                        ListViewItem item = new ListViewItem(subitems);
                                        item.Checked = true;
                                        addToList(item);
                                    }
                                    catch (PathTooLongException ptl)
                                    {
                                        logger.Error("Path too long! " + f);
                                        if (!checkBoxSupressErrors.Checked)
                                            MessageBox.Show(f+"\n"+ptl.Message.ToString());
                                    }

                                }
                            }
                            foreach (string b in folderexts)
                            {
                                if (stoploop)
                                    continue;
                                if (f.EndsWith("." + b))
                                {
                                    long dirbytes = 0;
                                    foreach (FileInfo g in new DirectoryInfo(currentDir).EnumerateFiles("*"))
                                    {
                                        dirbytes += g.Length;
                                    }
                                    string target = td + currentDir.Replace(sourcedir, "");
                                    string[] subitems = { "Entire Folder:", currentDir, (dirbytes / 1024).ToString(), System.IO.Directory.GetLastWriteTime(currentDir).ToShortDateString(), target, "-" };
                                    ListViewItem item = new ListViewItem(subitems);
                                    item.Checked = true;
                                    item.BackColor = Color.AliceBlue;
                                    addToList(item);
                                    bw.ReportProgress(0, currentDir);
                                    //since being here in got all the files on any match...
                                    stoploop = true;
                                }
                            }

                        }
                    }
                    catch (System.IO.FileNotFoundException z)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        MessageBox.Show(z.ToString());
                        logger.Error(z.Message);
                        continue;
                    }
                    catch (NullReferenceException ne)
                    {
                        MessageBox.Show(ne.Message);
                        logger.Error(ne.Message);
                        continue;
                    }

                    if (bw.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }


                    // Push the subdirectories onto the stack for traversal.
                    // This could also be done before handing the files.
                    if (so == SearchOption.AllDirectories)
                    {
                        foreach (string str in subDirs)
                        {
                            if (str.EndsWith(" "))
                            {
                                MessageBox.Show("Bad directory name found in " + str + "\nTrailing space not allowed.");
                                continue;
                            }

                            dirs.Push(str);
                        }
                    }
                }
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (seconds != System.DateTime.Now.Second)
            {
                this.labelStatus.Text = e.UserState.ToString();
                seconds = System.DateTime.Now.Second;
            }    
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bwUI.CancelAsync();
            buttonCancel.Visible = false;
            buttonRun.Visible = true;
            buttonRun.Enabled = true;
            if ((e.Cancelled == true))
            {   this.labelProgress.Text = "Canceled!";
                foreach (ListViewItem kb in listView1.Items)
                    finalsize += Int32.Parse(kb.SubItems[2].Text);
                this.labelStatus.Text = ("Found " + listView1.Items.Count + " items totaling " + finalsize + " KBytes.");
                this.buttonCancel.Visible = false;
                this.buttonCSV.Visible = true;
                this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.listView1.Update();
            }

            else if (!(e.Error == null))
            {     this.labelProgress.Text = ("Error: " + e.Error.Message); }

            else
            {
                this.labelProgress.Text = "Complete.";
                foreach (ListViewItem kb in listView1.Items)
                    finalsize += Int32.Parse(kb.SubItems[2].Text);
                this.labelStatus.Text = ("Found " + listView1.Items.Count + " items totaling " + finalsize + " KBytes.");
                this.buttonCancel.Visible = false;
                this.buttonCSV.Visible = true;
                this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.listView1.Update();
                this.buttonRun.Visible = true;
                this.buttonRun.Enabled = true;
            }
        }

        private void bwMove_DoWork(object sender, DoWorkEventArgs e)
        {
            List<ListViewItem> lv = e.Argument as List<ListViewItem>;
            BackgroundWorker worker = sender as BackgroundWorker;
            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                IWshShell MyShell = new IWshShell_Class();
                IWshRuntimeLibrary.IWshShortcut MyShortcut;

                foreach (ListViewItem i in lv)
                {
                    
                        string fn = i.SubItems[0].Text.ToString();
                        string sd = i.SubItems[1].Text.ToString();
                        string size = i.SubItems[2].Text.ToString();
                        string date = i.SubItems[3].Text.ToString();
                        string targetd = i.SubItems[4].Text.ToString();
                        //throws unauthorized access
                        DirectoryInfo target = new DirectoryInfo(targetd);
                        if (!target.Exists)
                            try
                            {
                                target.Create();
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                if (!checkBoxSupressErrors.Checked)
                                MessageBox.Show(ex.ToString());
                            }
                    FileInfo targetfile;
                    FileInfo sourcefile;
                        if (fn == "Entire Folder:") 
                            targetfile = new FileInfo(target.FullName);
                        else
                            targetfile = new FileInfo(target.FullName + "\\" + fn);
                        if (targetfile.Exists)
                        {
                            //check if destination is newer
                            if (targetfile.LastAccessTime.CompareTo(DateTime.Parse(date)) >= 0)
                            {
                                //log error
                                logger.Warn("Target file last access time newer than source: " + targetfile.LastAccessTime.ToString() + " SKIPPED!");
                                //i.SubItems[5].Text = ("Target file last access time newer than source: " + targetfile.LastAccessTime.ToString() + " SKIPPED!");
                                //i.BackColor = Color.Red;
                                continue;
                            }
                        }

                        //create shortcut and move file.
                        ;
                        if (fn == "Entire Folder:")
                        {
                            DirectoryInfo sourcefiles = new DirectoryInfo(sd);
                            worker.ReportProgress(0, sd);
                            foreach (FileInfo s in sourcefiles.GetFiles("*", SearchOption.AllDirectories))
                            {
                                targetfile = new FileInfo(target.FullName + "\\" + s.FullName.Replace(sd, ""));
                                try
                                {
                                    XCopy.Copy(s.FullName, targetfile.FullName, true, true);
                                }
                                catch (Win32Exception a)
                                {
                                    if (!checkBoxSupressErrors.Checked)
                                        MessageBox.Show(s.FullName + "\n" + a.Message);
                                    logger.Error("Access Denied"+a.Message);

                                }
                                logger.Info("Copied file to " + targetfile.FullName + " - (" + size + " KB)");
                                if (!optionalcopy)
                                {
                                    logger.Info("Deleting file... " + s.FullName + " - (" + size + " KB)");
                                    try
                                    {
                                        s.Delete();
                                    }
                                    catch (UnauthorizedAccessException uae)
                                    {
                                        if (!checkBoxSupressErrors.Checked)
                                        MessageBox.Show(s.FullName + "\n" + uae.Message);
                                        logger.Error("Permission denied deleting " + s.FullName);
                                    }
                                }

 
                            }
                                if (createshortcut)
                                {
                                    MyShortcut = (IWshRuntimeLibrary.IWshShortcut)MyShell.CreateShortcut(sd + ".lnk");
                                    MyShortcut.TargetPath = targetfile.Directory.ToString();
                                    MyShortcut.Save();
                                    logger.Info("Created shortcut " + MyShortcut.ToString());
                                    DirectoryInfo d = new DirectoryInfo(sd);
                                    logger.Info("Deleting directory... " + d.FullName + " - (" + size + " KB)");
                                    try
                                    {
                                        d.Delete();
                                    }
                                    catch (UnauthorizedAccessException uae)
                                    {
                                        if (!checkBoxSupressErrors.Checked)
                                            MessageBox.Show(d.FullName + "\n" + uae.Message);
                                        logger.Error("Permission denied deleting " + d.FullName);
                                    }
                                    catch (IOException)
                                    {
                                        logger.Error("Could not delete " + d.FullName);
                                    }
                                }
                                //continue;
                        }
                        else {
                       sourcefile = new FileInfo(sd + "\\" + fn);
                        XCopy.Copy(sourcefile.FullName, targetfile.FullName, true, true, (o, pce) =>
                        {
                            worker.ReportProgress(pce.ProgressPercentage, sourcefile.FullName);
                        });
                        logger.Info("Copied file to " + targetfile.FullName + " - (" + size + " KB)");

                        if (!optionalcopy)
                        {
                            logger.Info("Deleting file... " + sourcefile.FullName + " - (" + size + " KB)");
                            try
                            {
                                sourcefile.Delete();
                            }
                            catch (UnauthorizedAccessException uae)
                            {
                                if (!checkBoxSupressErrors.Checked)
                                MessageBox.Show(sourcefile.FullName + "\n" + uae.Message);
                                logger.Error("Permission denied deleting " + sourcefile.FullName);
                            }

                        }

                        if (createshortcut)
                        {
                            MyShortcut = (IWshRuntimeLibrary.IWshShortcut)MyShell.CreateShortcut(sourcefile.FullName + ".lnk");
                            MyShortcut.TargetPath = targetfile.FullName;
                            MyShortcut.Save();
                            logger.Info("Created shortcut " + MyShortcut.ToString());
                        }
                    
                }
                }
                labelStatus.BeginInvoke(new MethodInvoker(
                    () => labelStatus.Text = "Completed!  See log file in " + Application.StartupPath));
            }
        }

        private void bwMove_ProgressChanged(object sender, ProgressChangedEventArgs e) 
        {
            //if (seconds != System.DateTime.Now.Second)
            {
                this.labelStatus.Text = e.UserState.ToString();
                progressBar1.Value = e.ProgressPercentage;
                //seconds = System.DateTime.Now.Second;
            }    
        }

        private void bwMove_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) 
        {
            labelStatus.Text = "Completed!";
            progressBar1.Visible = false;
            buttonCancel.Visible = false;
        }



        //the following 2 methods were lifted from http://stackoverflow.com/questions/1008556/c-sharp-export-listview-to-csv 
        public static void ListViewToCSV(ListView listView, string filePath, bool includeHidden)
        {
            //make header string
            StringBuilder result = new StringBuilder();
            WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0, i => listView.Columns[i].Text);

            //export data rows
            foreach (ListViewItem listItem in listView.Items)
                WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0, i => listItem.SubItems[i].Text);

            System.IO.File.WriteAllText(filePath, result.ToString());
        }

        private static void WriteCSVRow(StringBuilder result, int itemsCount, Func<int, bool> isColumnNeeded, Func<int, string> columnValue)
        {
            bool isFirstTime = true;
            for (int i = 0; i < itemsCount; i++)
            {
                if (!isColumnNeeded(i))
                    continue;

                if (!isFirstTime)
                    result.Append(",");
                isFirstTime = false;

                result.Append(String.Format("\"{0}\"", columnValue(i)));
            }
            result.AppendLine();
        }

        private void buttonCSV_Click(object sender, EventArgs e)
        {
            FileDialog CSVBrowser = new SaveFileDialog();
            CSVBrowser.FileName=System.DateTime.Now.ToOADate() + "_HyperFileMove";
            CSVBrowser.DefaultExt = "csv";
            if (CSVBrowser.ShowDialog() == DialogResult.OK) 
            {
                //FileStream fs = new FileStream( CSVBrowser.FileName, FileMode.CreateNew);
                ListViewToCSV(listView1, CSVBrowser.FileName, false);
            }
        }

        private void statuslabelupdate()
        {
            labelStatus.Text = ("Found " + listView1.Items.Count + " items totaling " + bytes + " Kbytes.");
        }
        private void addToList(ListViewItem a)
        {
            if (listView1.InvokeRequired && !listView1.Items.Contains(a))
            {
                listView1.BeginInvoke(new MethodInvoker(
                    () => listView1.Items.Add(a)));
            }
            else if (!listView1.Items.Contains(a))
            {
                listView1.Items.Add(a);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (bw.WorkerSupportsCancellation == true)
            {
                bw.CancelAsync();
            }
            if (bwMove.IsBusy)
            {
                bwMove.CancelAsync();
                logger.Error("User cancelled file copying operations with the Cancel button");
                buttonRun.Visible = true;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (comboBoxOptions.SelectedIndex == 1)
                createshortcut = false;
            else if (comboBoxOptions.SelectedIndex == 2)
                optionalcopy = true;
            else if (comboBoxOptions.SelectedIndex == 3)
            {
                optionalcopy = true;
                createshortcut = false;
            }
            
            long totalsize = 0;
            labelStatus.Text = "Calculating space required...";
            foreach (ListViewItem i in listView1.Items)
            {
                if (i.Selected)
                    totalsize = +long.Parse(i.SubItems[2].ToString());
            }
            DriveInfo t = new DriveInfo(td.Substring(0, 1));
            if (!(t.AvailableFreeSpace >= totalsize * 1024))
                {
                    MessageBox.Show("Not enough space on destination drive, please create space or reduce the number of files to copy. (" + t.AvailableFreeSpace.ToString() + " bytes free on "+t.Name+")");
                    return;
                }
            DialogResult result = MessageBox.Show("This will start moving files and may take a long time to complete. Are you sure?", "Yes", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                if (bwMove.IsBusy != true)
                {
                    buttonCancel.Visible = true;
                    List<ListViewItem> lv = new List<ListViewItem>();
                    foreach (ListViewItem i in listView1.Items) 
                    {
                        if (i.Checked)
                        lv.Add(i);
                    }
                    bwMove.RunWorkerAsync(lv);
                }
            }
            progressBar1.Visible = true;
        }
        
        private void moveFiles()
        {
            
        }
            }

           
        }
    


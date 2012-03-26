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
        //Global variables
        private FolderBrowserDialog FileBrowser1 = new FolderBrowserDialog();
        private FolderBrowserDialog FileBrowser2 = new FolderBrowserDialog();
        private long bytes = 0;
        private bool stoploop = false;
        private bool exclude2;
        private string[] exts; 
        private string[] folderexts;
        private string sourcedir;
        private string td;
        private SearchOption so = SearchOption.AllDirectories;
        private BackgroundWorker bw = new BackgroundWorker();
        private BackgroundWorker bwMove = new BackgroundWorker();
        private int finalsize;
        private int totalitems;
        private long seconds = 0;
        private Logger logger = LogManager.GetLogger("HyperCopy");
        private bool createshortcut = true;
        private bool optionalcopy = false;
        private bool overwrite;
        private bool overwritenewer;
        
        public HyperCopy()
        {
            InitializeComponent();
            //Background worker setup
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
            //UI setup
            FileBrowser1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            FileBrowser1.ShowNewFolderButton = true;
            FileBrowser2.RootFolder = System.Environment.SpecialFolder.MyComputer;
            FileBrowser2.ShowNewFolderButton = true;
            comboBoxOptions.SelectedIndex = 0;
            buttonRun.Enabled = false;
            initListView();
            addMessage( "Ready!");
        }

        private void HyperCopy_Load(object sender, EventArgs e){}

        private void initListView() 
        {
            listView1.Clear();
            bytes = 0;
            finalsize = 0;
            totalitems = 0;
            stoploop = false;
            buttonCSV.Visible = false;
            buttonRun.Enabled = false;
            labelStatus.Text = "";
            listView1.View = View.Details;
            listView1.LabelEdit = true;
            listView1.AllowColumnReorder = true;
            listView1.CheckBoxes = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            ColumnHeader[] cols = {Filename,Directory,ItemSize,LastMod,NewPath};
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
                else if (result ==DialogResult.Cancel)
                    return;
            }
            try
            {   
                DirectoryInfo source = new DirectoryInfo(textBoxDir1.Text);
                DirectoryInfo dest = new DirectoryInfo(textBoxDir2.Text);
                sourcedir = source.FullName;
                td = dest.FullName;
                if (source.Root.Name == source.Name)
                    td = td+ "\\";
                if (!source.Exists)
                {
                    throw new ArgumentException();
                }
            }
            catch (DirectoryNotFoundException dnfe)
            { MessageBox.Show("Path not found: " + dnfe.Message.ToString()); return; }
            catch (UnauthorizedAccessException uae)
            { MessageBox.Show("Check Permissions: " + uae.Message.ToString()); return; }
            catch (ArgumentException ae)
            { MessageBox.Show("Need a valid path: " + sourcedir + " " + ae.Message.ToString()); return; }

            exclude2 = checkBoxExclude2.Checked;
            if (!checkBoxSubFolders.Checked)
                so = SearchOption.TopDirectoryOnly;
            else
                so = SearchOption.AllDirectories;

            //Start background process to search for files and update the UI with progress asynchronously
            if (bw.IsBusy != true)
            {
                listBox1.Items.Clear();
                buttonCancel.Visible = true;
                progressBar1.Visible = true;
                bw.RunWorkerAsync();
            }

        }
        //Worker for the Simulate button
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
                string root = sourcedir;
                // Data structure to hold names of subfolders to be
                // examined for files.
                Stack<string> dirs = new Stack<string>(20);
                dirs.Push(root);
                string[] subDirs = { };
                while (dirs.Count > 0)
                {
                    string currentDir = dirs.Pop();
                    string[] files = { };
                    try
                    {
                        subDirs = System.IO.Directory.GetDirectories(currentDir);
                        files = System.IO.Directory.GetFiles(currentDir);
                    }
                    catch (DirectoryNotFoundException dnfe)
                    { MessageBox.Show("Path not found: " + dnfe.Message.ToString()); continue; }
                    catch (UnauthorizedAccessException uae)
                    { addMessage( "Check Permissions: " + uae.Message.ToString()); continue; }
                    catch (ArgumentException ae)
                    { addMessage("Need a valid path: " + ae.Message.ToString()); continue; }
                    catch (NullReferenceException nr)
                    { addMessage("Null Reference: " + nr.Message.ToString()); }
                    catch (Exception ge)
                    { addMessage("Unknown exception: " + ge.Message); continue; }

                    stoploop = false;
                    // Perform the required action on each file here.
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
                                        bytes += file.Length;
                                        string[] subitems = { file.Name, currentDir, (file.Length / 1024).ToString(), file.LastWriteTime.ToLongDateString(), target.ToString() };
                                        ListViewItem item = new ListViewItem(subitems);
                                        item.Checked = true;
                                        addToList(item);
                                        totalitems++;
                                    }
                                    catch (PathTooLongException ptl)
                                    {
                                        logger.Error("Path too long! " + f);
                                        addMessage(f + " " + ptl.Message.ToString());
                                    }

                                }
                            }
                            //check for extension that move the entire folder
                            foreach (string b in folderexts)
                            {
                                if (stoploop)
                                    continue;
                                if (f.EndsWith("." + b))
                                {
                                    long dirbytes = 0;
                                    int diritems = 0;
                                    DirectoryInfo cd = new DirectoryInfo(currentDir);
                                    string parentd = "null";
                                    string gparentd = "null";
                                    if (cd.Parent.Exists)
                                    {
                                        parentd = cd.Parent.FullName;
                                        if (cd.Parent.Parent != null)
                                            gparentd = cd.Parent.Parent.FullName;
                                    }
                                    if (parentd != sourcedir && gparentd != sourcedir && cd.FullName != sourcedir || !exclude2)
                                    {
                                        foreach (FileInfo g in cd.EnumerateFiles("*", so))
                                        {
                                            dirbytes += g.Length;
                                            totalitems++;
                                            diritems++;
                                        }
                                        string target = td + currentDir.Replace(sourcedir, "");
                                        bytes += dirbytes;
                                        string[] subitems = { "Entire Folder: (" + diritems + " items)", currentDir, (dirbytes / 1024).ToString(), cd.LastWriteTime.ToLongDateString(), target };
                                        ListViewItem item = new ListViewItem(subitems);
                                        item.Checked = true;
                                        item.BackColor = Color.AliceBlue;
                                        addToList(item);
                                        totalitems++;
                                        bw.ReportProgress(dirs.Count + subDirs.Length, currentDir);
                                        //since being here in got all the files on any match...
                                        stoploop = true;
                                    }
                                }
                            }

                        }
                    }
                    catch (System.IO.FileNotFoundException z)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call 
                        // then just continue.
                        addMessage("File not found! " + z.ToString());
                        logger.Error(z.Message);
                        continue;
                    }
                    catch (NullReferenceException ne)
                    {
                        addMessage("Null Reference: " + ne.Message);
                        logger.Error(ne.Message);
                        continue;
                    }
                    catch (UnauthorizedAccessException uae)
                    {
                        addMessage("Check Permissions: " + uae.Message);
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
                                addMessage("Bad directory name found in " + str + " Trailing space not allowed.");
                                logger.Warn("Bad directory name found in " + str + " Trailing space not allowed.");
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
                this.labelStatus.Text = "Found " + totalitems + " items totaling " + bytes/1024 + " Kbytes so far. \nNow searching: "+e.UserState.ToString();
                progressBar1.Value = e.ProgressPercentage%101;
                seconds = System.DateTime.Now.Second;
            }    
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonCancel.Visible = false;
            progressBar1.Visible = false;
            buttonRun.Enabled = true;
            buttonRun.Enabled = true;
            labelStatus.Text = "";
            if ((e.Cancelled == true))
            {   
                addMessage("Canceled! " + System.DateTime.Now.ToLongTimeString());
            }

            else if (!(e.Error == null))
            {     
                addMessage("Error: " + e.Error.Message); 
            }

            else
            {
                addMessage("Complete.");
            }
            foreach (ListViewItem kb in listView1.Items)
                finalsize += Int32.Parse(kb.SubItems[2].Text);
            addMessage("Found " + totalitems + " items totaling " + finalsize + " KBytes.");
            this.buttonCancel.Visible = false;
            this.buttonCSV.Visible = true;
            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listView1.Update();
        }
        //Worker for the Run button 
        //Main functionality done here
        private void bwMove_DoWork(object sender, DoWorkEventArgs e)
        {
            List<ListViewItem> lv = e.Argument as List<ListViewItem>;
            BackgroundWorker worker = sender as BackgroundWorker;
            if (bw.IsBusy)
                bw.CancelAsync();
            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
                return;
            }
            else
            {
                IWshShell MyShell = new IWshShell_Class();
                IWshRuntimeLibrary.IWshShortcut MyShortcut;
                int tomove = lv.Count;
                int movedsub = 0;
                int moved = 0;
                long bytesmoved = 0;
                foreach (ListViewItem i in lv)
                {
                    if (bwMove.CancellationPending)
                        return;
                    string fn = i.SubItems[0].Text.ToString();
                    string sd = i.SubItems[1].Text.ToString();
                    string size = i.SubItems[2].Text.ToString();
                    string date = i.SubItems[3].Text.ToString();
                    string targetd = i.SubItems[4].Text.ToString();
                    //create target directory if necessary
                    DirectoryInfo target = new DirectoryInfo(targetd);
                    if (!target.Exists)
                        try { target.Create(); }
                        catch (UnauthorizedAccessException ex)
                        {   
                            addMessage("Unable to create: " + target + ex.ToString());
                            logger.Error(ex.Message);
                            continue;
                        }
                    FileInfo targetfile;
                    FileInfo sourcefile;
                    //directory copy   
                    if (fn.StartsWith("Entire Folder:"))
                    {
                        if (!target.Exists)
                            try { target.Create(); }
                            catch (UnauthorizedAccessException ex)
                            {
                                addMessage("Unable to create: " + target + ex.ToString());
                                logger.Error(ex.Message);
                                continue;
                            }
                        targetfile = new FileInfo(target.FullName);
                        DirectoryInfo sourcefiles = new DirectoryInfo(sd);
                        worker.ReportProgress(0, sd);
                        movedsub = 0;
                        if (!sourcefiles.Exists)
                        {
                            addMessage("Folder does not exist: " + sourcefiles.FullName );
                            logger.Error("Folder does not exist: " + sourcefiles.FullName );
                            continue;
                        }
                        foreach (FileInfo s in sourcefiles.GetFiles("*", so))
                        {
                            targetfile = new FileInfo(target.FullName + "\\" + s.FullName.Replace(sd, ""));
                            if (!targetfile.Directory.Exists)
                                try { targetfile.Directory.Create(); }
                                catch (UnauthorizedAccessException ex)
                                {
                                    addMessage("Unable to create: " + targetfile.Directory + ex.ToString());
                                    logger.Error(ex.Message);
                                    continue;
                                }
                            movedsub++;
                            try
                            {
                                string msg = s.FullName + "\n" + bytesmoved + " bytes transferred so far.  Moved " + movedsub + " files from sub folder.";
                                XCopy.Copy(s.FullName, targetfile.FullName, overwrite, true, (o, pce) =>
                                {
                                    worker.ReportProgress(pce.ProgressPercentage, msg);
                                });
                                moved++;
                                bytesmoved += s.Length;
                            }
                            catch (Win32Exception a)
                            {
                                addMessage("Could not copy: " + s.FullName + a.Message);
                                logger.Error(s.FullName+ " " +a.Message);
                                continue;
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
                                    addMessage("Permission denied deleting file " + uae.Message);
                                    logger.Error("Permission denied deleting file " + uae.Message);
                                }
                            }


                        }
                        if (createshortcut)
                        {
                            MyShortcut = (IWshRuntimeLibrary.IWshShortcut)MyShell.CreateShortcut(sourcefiles.FullName + ".lnk");
                            MyShortcut.TargetPath = target.FullName.ToString();
                            try
                            {
                                MyShortcut.Save();
                            }
                            catch (Exception ex)
                            {
                                addMessage("Error creating shortcut: " + ex.Message);
                                logger.Error("Error creating shortcut: " + ex.Message);
                            }
                            logger.Info("Created shortcut " + MyShortcut.FullName.ToString());
                            if (so == SearchOption.AllDirectories)
                            {
                                DirectoryInfo d = new DirectoryInfo(sd);
                                logger.Info("Deleting directory... " + d.FullName + " - (" + size + " KB)");
                                try
                                {
                                    d.Delete();
                                }
                                catch (UnauthorizedAccessException uae)
                                {
                                    addMessage("Permission denied deleting " + uae.Message);
                                    logger.Error("Permission denied deleting " + uae.Message);
                                }
                                catch (IOException)
                                {
                                    logger.Error("Could not delete " + d.FullName);
                                    addMessage("Error deleting " + d.FullName);
                                }
                            }
                        }
                    }
                    //single file copy
                    else
                    {
                        targetfile = new FileInfo(target.FullName + "\\" + fn);
                        if (targetfile.Exists)
                        {
                            //check if destination is newer
                            if (targetfile.LastAccessTime.CompareTo(DateTime.Parse(date)) >= 0 && !overwritenewer)
                            {
                                logger.Info("Target file last access time newer than source: " + targetfile.LastAccessTime.ToString() + " Skipping.");
                                addMessage("Target file last access time newer than source: " + targetfile.LastAccessTime.ToString() + " Skipping.");
                                continue;
                            }
                        }
                        
                        sourcefile = new FileInfo(sd + "\\" + fn);
                        if (!sourcefile.Exists)
                        {
                            addMessage("File does not exist: " + sourcefile.FullName);
                            logger.Error("File does not exist: " + sourcefile.FullName);
                            continue;
                        }
                        try
                        {
                            string msg = sourcefile.FullName + "\n" + bytesmoved + " bytes transferred so far. " + moved + " / " + totalitems + " files.";
                            XCopy.Copy(sourcefile.FullName, targetfile.FullName, overwrite, true, (o, pce) =>
                            {
                                worker.ReportProgress(pce.ProgressPercentage, msg);
                            });

                        }
                        catch (Win32Exception a)
                        {
                            addMessage("Exception: " + targetfile.FullName +" "+ a.Message);
                            logger.Error("Exception: " + targetfile.FullName +" "+ a.Message);
                            continue;
                        }
                        moved++;
                        bytesmoved += sourcefile.Length;
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
                                addMessage("Permission denied deleting " + sourcefile.FullName + " " + uae.Message);
                                logger.Error("Permission denied deleting " + sourcefile.FullName);
                            }
                        }
                        if (createshortcut)
                        {
                            MyShortcut = (IWshRuntimeLibrary.IWshShortcut)MyShell.CreateShortcut(sourcefile.FullName + ".lnk");
                            MyShortcut.TargetPath = targetfile.FullName;
                            try
                            {
                                MyShortcut.Save();
                            }
                            catch (Exception ex)
                            {
                                addMessage("Error creating shortcut: " + ex.Message);
                                logger.Error("Error creating shortcut: " + ex.Message);
                                continue;
                            }
                            logger.Info("Created shortcut " + MyShortcut.FullName.ToString());
                        }
                    }
                }
                addMessage("Completed " + System.DateTime.Now.ToLongTimeString());
                addMessage("*See detailed log file in " + Application.StartupPath);
            }
        }

        private void bwMove_ProgressChanged(object sender, ProgressChangedEventArgs e) 
        {
            if (seconds+1500000 <= System.DateTime.Now.Ticks)
            {
                this.labelStatus.Text = e.UserState.ToString();
                progressBar1.Value = e.ProgressPercentage;
                seconds = System.DateTime.Now.Ticks;
            }    
        }

        private void bwMove_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) 
        {
            labelStatus.Text = "";
            progressBar1.Visible = false;
            buttonCancel.Visible = false;
        }

        private void buttonCSV_Click(object sender, EventArgs e)
        {
            FileDialog CSVBrowser = new SaveFileDialog();
            CSVBrowser.FileName=System.DateTime.Now.ToOADate() + "_HyperFileMove";
            CSVBrowser.DefaultExt = "csv";
            if (CSVBrowser.ShowDialog() == DialogResult.OK) 
            {
                ListViewToCSV(listView1, CSVBrowser.FileName, false);
            }
        }

        private void addMessage(string s)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.BeginInvoke(new MethodInvoker(
                    () => listBox1.Items.Insert(0, s)));
            }
            else
            {
                listBox1.Items.Insert(0,s);
            }
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
            if (bwMove.WorkerSupportsCancellation==true)
            {
                bwMove.CancelAsync();
                addMessage("User Cancelled! "+System.DateTime.Now.ToLongTimeString());
                logger.Error("User cancelled file copying operations with the Cancel button");
                buttonRun.Enabled = true;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            buttonCancel.Enabled = true;
            createshortcut = true;
            optionalcopy = false;
            if (comboBoxOptions.SelectedIndex == 1)       
                createshortcut=false;
            else if (comboBoxOptions.SelectedIndex == 2)
                optionalcopy = true;
            else if (comboBoxOptions.SelectedIndex == 3)
            {
                optionalcopy = true;
                createshortcut = false;
            }
            overwrite = checkBoxOverwrite.Checked;
            overwritenewer = checkBoxOverwriteNewer.Checked;
            addMessage("Action started "+System.DateTime.Now.ToLongTimeString());
            long totalsize = 0;
            addMessage("Calculating space required...");
            foreach (ListViewItem i in listView1.Items)
            {
                if (i.Checked)
                    totalsize += long.Parse(i.SubItems[2].Text.ToString());
            }
            DriveInfo t = new DriveInfo(td.Substring(0, 1));
            if (!(t.AvailableFreeSpace >= totalsize * 1024))
                {
                    MessageBox.Show("Not enough space on destination drive, please create space or reduce the number of files to copy. (" + t.AvailableFreeSpace.ToString() + " bytes free on "+t.Name+")");
                    addMessage("Not enough space on destination drive, please create space or reduce the number of files to copy. (" + t.AvailableFreeSpace.ToString() + " bytes free on "+t.Name+")");
                    return;
                }
            addMessage(totalsize+" required, "+t.AvailableFreeSpace/1024+" available on "+t.RootDirectory.Name);
            DialogResult result = MessageBox.Show("This will start moving "+totalsize+"Kb of files and may take a long time to complete. Are you sure?", "Yes", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
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
                    addMessage("Starting to " + comboBoxOptions.SelectedItem.ToString());
                    progressBar1.Visible = true;
                    bwMove.RunWorkerAsync(lv);
                }
            }
        }

        private void checkBoxOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
                checkBoxOverwriteNewer.Visible = true;
            else
            {
                checkBoxOverwriteNewer.Visible = false;
                checkBoxOverwriteNewer.Checked = false;
            }
        }

        private void textBoxDir2_TextChanged(object sender, EventArgs e)
        {
            if (buttonRun.Enabled == true)
            {
                //MessageBox.Show("Changing the target directory requires you to simulate again to update the list.  Clicking Run will still copy to location displayed in the list!");
            }
        }

        public void CopyListBoxToClipboard()
        {
            ListBox lb = listBox1;
            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < lb.Items.Count; i++)
            {
                buffer.AppendLine(lb.Items[i].ToString());
            }
            Clipboard.SetText(buffer.ToString());
        }

        private void Lis(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopyListBoxToClipboard();
        }

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
    }  
}
    


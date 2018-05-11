using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Media;

namespace D2MoCa
{
    public partial class FrmD2QS : Form
    {
        internal class SafeNativeMethods // not used
        {
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            internal static extern int SetWindowText(IntPtr hWnd, string text);

            [DllImport("user32.dll")]
            internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

            [DllImport("user32.dll")]
            static extern IntPtr CreateIconFromResource(byte[] presbits, uint dwResSize, bool fIcon, uint dwVer);
        }

        bool d2sound = false; // control sound
        int[] ProgramID = new int[40]; // autostart/close program -- not used
        bool editProgram = false; // used when adding program to listview
        int dllbtn = 0; // used when injecting dll
        D2procsWorker d2procs = new D2procsWorker(); // used when starting/controlling d2procs
        Proc_DLL procAndDLL = new Proc_DLL(); // used for auto start/close+DLL stuff
        OtherFunctions otherFunc = new OtherFunctions(); // for cursor and stuff
        SoundPlayer splayer = new SoundPlayer(); // to play sounds

        public FrmD2QS()
        {
            InitializeComponent();
        }

        private void FrmD2QS_Load(object sender, EventArgs e)
        {
            MainArgumentChecker(Environment.GetCommandLineArgs()); // do command line args
            Height = 350; // make sure ui looks fine
            Width = 422;
            MaximumSize = new Size(422, 500);
            MinimumSize = new Size(422, 250);

            FillTempInfo();
            LoadSettings(); // load from resources
            UpdateFlow1(); // make d2 buttons
            UpdateFlow2(); // make hack buttons
            UpdateContextMenu(); // fix dll buttons
            procAndDLL.AutoStartPrograms(lstPrograms); // check if we should start something
            SetNewFont(); // use d2font in ui (needs work)
            tstInfoLabel.Text = "Ready to serve, my lord!";
        }

        private void FillTempInfo()
        {
            for (int i = 1; i < 5; i++)
            {
                d2procs.AddD2Proc(new D2proc(@"D:\Spil\Diablo II\Diablo II - 1.14D bnet" + i.ToString() + @"\Game.exe", ""));
            }

            //IProcDLL pd = new DLLInfos("name", "path");
            //IProcDLL pd2 = new ProcInfo("", "", "", true, true, true);
            //ProcDLL pdlist = new ProcDLL();
            //pdlist.AddProcDLL(pd);
            //pdlist.ListProcDLL.Add(pd2);

            return;
        }

        private void MainArgumentChecker(string[] args) // deal with arguments on launch
        {
            foreach (string arg in args)
            {
                if (arg.ToLower() == "d21")
                {
                    if (Properties.Settings.Default.D2Paths[0] != "")
                    {
                        d2procs.StartD2(Properties.Settings.Default.D2Paths[0], "-w " + Properties.Settings.Default.D2Arguements[0], this);
                        d2procs.ReleaseD2Windows();
                    }
                }
                else if (arg.ToLower() == "d22")
                {
                    if (Properties.Settings.Default.D2Paths[1] != "")
                    {
                        d2procs.StartD2(Properties.Settings.Default.D2Paths[1], "-w " + Properties.Settings.Default.D2Arguements[1], this);
                        d2procs.ReleaseD2Windows();
                    }
                }
                else if (arg.ToLower() == "d23")
                {
                    if (Properties.Settings.Default.D2Paths[2] != "")
                    {
                        d2procs.StartD2(Properties.Settings.Default.D2Paths[2], "-w " + Properties.Settings.Default.D2Arguements[2], this);
                        d2procs.ReleaseD2Windows();
                    }
                }
                else if (arg.ToLower() == "d24")
                {
                    if (Properties.Settings.Default.D2Paths[3] != "")
                    {
                        d2procs.StartD2(Properties.Settings.Default.D2Paths[3], "-w " + Properties.Settings.Default.D2Arguements[3], this);
                        d2procs.ReleaseD2Windows();
                    }
                }
                else if (true)
                {
                    for (int i = 0; i < Properties.Settings.Default.ProgramStrings.Count; i++)
                    {
                        if (Properties.Settings.Default.ProgramStrings[i].Length < 1)
                        {
                            break;
                        }
                        string[] programString = { "", "", "", "", "" };
                        // split the string to get all the info
                        programString = Properties.Settings.Default.ProgramStrings[i].Split(new Char[] { '|' });
                        if (!programString[4].Contains("DLL"))
                        {
                            if (programString[1].ToLower() == arg.ToLower())
                            {
                                Process.Start(programString[2], programString[3]);
                            }
                        }
                    }
                }
            }
            if (args.Contains("quit"))
            {
                this.Close();
            }
        }

        #region load+clear+save settings
        private void LoadSettings()
        {
            // load from settings
            tstInfoLabel.Text = "D2 paths loaded";


            tstInfoLabel.Text = "D2 arguments loaded";

            // clear list for a new list
            lstPrograms.Items.Clear();
            tstInfoLabel.Text = "Program path list cleared";

            // add new list
            for (int i = 0; i < Properties.Settings.Default.ProgramStrings.Count; i++)
            {
                if (Properties.Settings.Default.ProgramStrings[i].Length < 1)
                {
                    break;
                }

                ListViewItem lstItem = new ListViewItem();
                string[] tempSubs = { "", "", "", "" };
                lstItem.SubItems.AddRange(tempSubs);
                string[] programString = { "", "", "", "", "" };
                // true/false (show on main page)
                lstItem.Checked = false;
                if (Properties.Settings.Default.ProgramStrings[i].StartsWith("TRUE"))
                {
                    lstItem.Checked = true;
                }
                programString = Properties.Settings.Default.ProgramStrings[i].Split(new Char[] { '|' });

                // 1 = program name
                lstItem.SubItems[0].Text = programString[1];
                // 2 = path
                lstItem.SubItems[1].Text = programString[2];
                // 3 = arguments
                lstItem.SubItems[2].Text = programString[3];
                // 4 = START+CLOSE
                lstItem.SubItems[3].Text = programString[4];
                // add to list
                lstPrograms.Items.Add(lstItem);

                tstInfoLabel.Text = lstItem.Text + " added to list";
                // safety
                lstItem = null;
            }
            tstInfoLabel.Text = "Info for all programs loaded";
        }

        private void SaveProgPaths()
        {
            string[] strings2 = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""};
            // clear programpaths
            Properties.Settings.Default.ProgramStrings.Clear();
            Properties.Settings.Default.ProgramStrings.AddRange(strings2);

            for (int i = 0; i < lstPrograms.Items.Count; i++)
            {
                if (lstPrograms.Items[i].Text.Equals(""))
                {
                    break;
                }
                Properties.Settings.Default.ProgramStrings[i] = "FALSE";
                if (lstPrograms.Items[i].Checked)
                {
                    Properties.Settings.Default.ProgramStrings[i] = "TRUE";
                }
                Properties.Settings.Default.ProgramStrings[i] += "|" + lstPrograms.Items[i].SubItems[0].Text;
                Properties.Settings.Default.ProgramStrings[i] += "|" + lstPrograms.Items[i].SubItems[1].Text;
                Properties.Settings.Default.ProgramStrings[i] += "|" + lstPrograms.Items[i].SubItems[2].Text;
                Properties.Settings.Default.ProgramStrings[i] += "|" + lstPrograms.Items[i].SubItems[3].Text;
            }

            // update buttons
            UpdateFlow2();
            UpdateContextMenu();
            Properties.Settings.Default.Save();
        }

        private void ClearAllSettings()
        {
            string[] strings = { "", "", "", "" };
            string[] strings2 = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                                "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""};
            // clear d2paths
            Properties.Settings.Default.D2Paths.Clear();
            Properties.Settings.Default.D2Paths.AddRange(strings);

            // clear d2arguments
            Properties.Settings.Default.D2Arguements.Clear();
            Properties.Settings.Default.D2Arguements.AddRange(strings);

            // clear programpaths
            Properties.Settings.Default.ProgramStrings.Clear();
            Properties.Settings.Default.ProgramStrings.AddRange(strings2);
        }

        private void SaveAllSettings()
        {
            // save d2paths
            // save to settings

            // save d2arguments
            // save to settings

            for (int i = 0; i < lstPrograms.Items.Count; i++)
            {
                if (lstPrograms.Items[i].Text.Equals(""))
                {
                    break;
                }
                Properties.Settings.Default.ProgramStrings[i] = "FALSE";
                if (lstPrograms.Items[i].Checked)
                {
                    Properties.Settings.Default.ProgramStrings[i] = "TRUE";
                }
                Properties.Settings.Default.ProgramStrings[i] += "|" + lstPrograms.Items[i].SubItems[0].Text;
                Properties.Settings.Default.ProgramStrings[i] += "|" + lstPrograms.Items[i].SubItems[1].Text;
                Properties.Settings.Default.ProgramStrings[i] += "|" + lstPrograms.Items[i].SubItems[2].Text;
                Properties.Settings.Default.ProgramStrings[i] += "|" + lstPrograms.Items[i].SubItems[3].Text;
            }

            // save it all
            Properties.Settings.Default.Save();
        }
        #endregion

        #region dynamic buttons
        // update d2 buttons
        private void UpdateFlow1()
        {
            flowEachD2.Controls.Clear();

            for (int i = 0; i < d2procs.d2Procs.Count; i++)
            {
                // new button (D2)
                Button progBtnD2Standard = new Button();
                // save the index of the program in the button info
                progBtnD2Standard.Tag = i;
                // random button name
                progBtnD2Standard.Name = "btnDiablo" + i.ToString();
                // set the text on the button
                if (i + 1 < 10)
                {
                    progBtnD2Standard.Text = "D2_0" + (i + 1).ToString();
                }
                else
                {
                    progBtnD2Standard.Text = "D2_" + (i + 1).ToString();
                }

                // size stuff
                progBtnD2Standard.Size = new Size(48, 23);
                // add to flow
                flowEachD2.Controls.Add(progBtnD2Standard);
                // add click function
                progBtnD2Standard.Click += btnD2_Click;


                // new button (-w)
                Button progBtnD2WindowMode = new Button();
                // save the index of the program in the button info
                progBtnD2WindowMode.Tag = i;
                // random button name
                progBtnD2WindowMode.Name = "btnDiabloW" + i.ToString();
                // set the text on the button
                progBtnD2WindowMode.Text = "-w";
                // size stuff
                progBtnD2WindowMode.Size = new Size(26, 23);
                // add to flow
                flowEachD2.Controls.Add(progBtnD2WindowMode);
                // add click function
                progBtnD2WindowMode.Click += btnD2W_Click;


                // new button (dropdown)
                Button progBtnDropdown = new Button();
                // save the index of the program in the button info
                progBtnDropdown.Tag = i;
                // random button name
                progBtnDropdown.Name = "btnDiabloD" + i.ToString();
                // set the text on the button
                progBtnDropdown.Text = "";
                progBtnDropdown.Image = Properties.Resources.GlyphDown;
                // size stuff
                progBtnDropdown.Size = new Size(17, 18);
                // add to flow
                flowEachD2.Controls.Add(progBtnDropdown);
                // add click function
                progBtnDropdown.Click += progBtnD_Click;
                //contextMenuStrip1.AutoClose = false;

                // new textbox (arguments)
                TextBox txtArguments = new TextBox();
                // special name for textbox
                txtArguments.Name = i.ToString();
                txtArguments.Size = new Size(85, 20);
                txtArguments.TextChanged += TxtArguments_TextChanged;
                flowEachD2.Controls.Add(txtArguments);
            }
        }

        private void TxtArguments_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int.TryParse(tb.Name, out int i);

            d2procs.d2Procs[i].d2Args = tb.Text;
        }

        // update program buttons
        private void UpdateFlow2()
        {
            // clean the flow panel
            flowPrograms.Controls.Clear();

            // add buttons to flow panel
            for (int i = 0; i < lstPrograms.Items.Count; i++)
            {
                // only if check to be on main page
                if (lstPrograms.Items[i].Checked)
                {
                    // new button
                    Button progBtn = new Button();
                    // save the index of the program in the button info
                    progBtn.Tag = i;
                    // random button name
                    progBtn.Name = "btn" + lstPrograms.Items[i].Text;
                    // set the text on the button
                    progBtn.Text = lstPrograms.Items[i].Text;
                    // size stuff
                    progBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    progBtn.AutoSize = Enabled;
                    // add to flow
                    flowPrograms.Controls.Add(progBtn);
                    // add click function
                    progBtn.Click += progBtn_Click;
                }
            }
        }

        // add -w when starting d2
        void btnD2W_Click(object sender, EventArgs e)
        {
            splayer.Stream = Properties.Resources.button;
            if (d2sound) { splayer.Play(); }

            // make button object to work with
            Button btn = (Button)sender;
            // find the program index
            int j = (int)btn.Tag;

            // start the program associated with the button
            try
            {
                string tmp = "";
                if (d2procs.d2Procs[j].d2Args != null && d2procs.d2Procs[j].d2Args != "")
                    tmp = d2procs.d2Procs[j].d2Args;
                d2procs.StartD2(d2procs.d2Procs[j].d2Path, "-w " + tmp, this);
                d2procs.ReleaseD2Windows();
                tstInfoLabel.Text = "Diablo 2: '" + btn.Text + "' started with " + " as arguments";
            }
            catch (Exception)
            {
                // fail
                throw;
            }
        }

        // launch d2 with listed arguments
        void btnD2_Click(object sender, EventArgs e)
        {
            splayer.Stream = Properties.Resources.button;
            if (d2sound) { splayer.Play(); }

            // make button object to work with
            Button btn = (Button)sender;
            // find the program index
            int j = (int)btn.Tag;

            // start the program associated with the button
            try
            {
                d2procs.StartD2(d2procs.d2Procs[j].d2Path, d2procs.d2Procs[j].d2Args, this);
                d2procs.ReleaseD2Windows();
                tstInfoLabel.Text = "Diablo 2: '" + btn.Text + "' started with " + " as arguments";
            }
            catch (Exception)
            {
                // fail
                throw;
            }
        }

        // dll dropdown button
        void progBtnD_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show((Button)sender, new Point(0, 18));
        }

        // start program from list
        void progBtn_Click(object sender, EventArgs e)
        {
            splayer.Stream = Properties.Resources.button;
            if (d2sound) { if (d2sound) { splayer.Play(); } }

            // make button object to work with
            Button btn = (Button)sender;
            // find the program index
            int j = (int)btn.Tag;

            // start the program associated with the button
            try
            {
                Process.Start(lstPrograms.Items[j].SubItems[1].Text, lstPrograms.Items[j].SubItems[2].Text);
                tstInfoLabel.Text = "Program: '" + lstPrograms.Items[j].Text + "' started";
            }
            catch (Exception)
            {
                // fail
                throw;
            }
        }

        // update dll menu
        private void UpdateContextMenu()
        {
            contextMenuStrip1.Items.Clear();
            ToolStripMenuItem topBtn = new ToolStripMenuItem();
            topBtn.Text = "Inject a DLL into D2";
            topBtn.Enabled = false;
            topBtn.ToolTipText = "This CAN inject DLL into a non D2 window. Use at your own risk!";
            contextMenuStrip1.Items.Add(topBtn);

            for (int i = 0; i < lstPrograms.Items.Count; i++)
            {
                // only if check to be on main page
                if (lstPrograms.Items[i].SubItems[3].Text == "DLL")
                {
                    // new button
                    ToolStripMenuItem dllBtn = new ToolStripMenuItem();
                    // save the index of the program in the button info
                    dllBtn.Tag = i;
                    // button name
                    dllBtn.Name = "btn" + lstPrograms.Items[i].Text;
                    // set the text on the button
                    dllBtn.Text = lstPrograms.Items[i].Text;
                    // set tt for btn
                    dllBtn.ToolTipText = "This CAN inject DLL into a non D2 window. Use at your own risk!";
                    // add to list
                    contextMenuStrip1.Items.Add(dllBtn);
                    // add click function
                    dllBtn.Click += DllBtn_Click;
                }
            }
        }

        // inject dll
        void DllBtn_Click(object sender, EventArgs e)
        {
            splayer.Stream = Properties.Resources.button;
            if (d2sound) { splayer.Play(); }

            DllInjectionResult res = DLLfixer.GetInstance.Inject("Diablo II", "game", @"C:\Users\Bonzai\Desktop\Andet\D2\d2mr-1.14d\d2mr.dll");
            return;
            // make button object to work with
            ToolStripMenuItem btn = (ToolStripMenuItem)sender;
            // find the program index
            int j = (int)btn.Tag;
            string dllpath = lstPrograms.Items[j].SubItems[1].Text;
            int d2pid = 0;
            string[] d2files = new string[4];
            for (int i = 0; i < Properties.Settings.Default.D2Paths.Count; i++)
            {
                d2files[i] = Path.GetFileNameWithoutExtension(Properties.Settings.Default.D2Paths[i]);
            }

            Process[] lstprocs = Process.GetProcesses();
            foreach (Process item in lstprocs)
            {
                if (item.ProcessName.Equals("Game") || item.ProcessName.Equals("Diablo II") || item.ProcessName.Equals(d2files[0])
                     || item.ProcessName.Equals(d2files[1]) || item.ProcessName.Equals(d2files[2]) || item.ProcessName.Equals(d2files[3]))
                {
                    if (dllbtn == 1 && item.MainWindowTitle == "D2_1")
                    {
                        d2pid = item.Id;
                        break;
                    }
                    else if (dllbtn == 2 && item.MainWindowTitle == "D2_2")
                    {
                        d2pid = item.Id;
                        break;
                    }
                    else if (dllbtn == 3 && item.MainWindowTitle == "D2_3")
                    {
                        d2pid = item.Id;
                        break;
                    }
                    else if (dllbtn == 4 && item.MainWindowTitle == "D2_4")
                    {
                        d2pid = item.Id;
                        break;
                    }
                }
            }
            if (d2pid != 0) // inject DLL if we found the right D2
            {
                //procAndDLL.InjectDLL(d2pid.ToString() + " \"" + dllpath + "\"");
                tstInfoLabel.Text = lstPrograms.Items[j].Text + " injected into your D2_" + dllbtn.ToString() + " window";
            }
            else
            {
                tstInfoLabel.Text = "Error!: Didn't find the specified D2 window";
                MessageBox.Show("Didn't find the specified D2 window", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region add+edit+delete+find programs
        private void btnAddProgram_Click(object sender, EventArgs e)
        {
            splayer.Stream = Properties.Resources.button;
            if (d2sound) { splayer.Play(); }

            // no path
            if (txtProgramPath.Text == "")
            {
                tstInfoLabel.Text = "Missing path!: Need a program path!";
                MessageBox.Show("Need a program path", "Missing path!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListViewItem newProgram = new ListViewItem();
            // when we edit a program from the list
            if (editProgram)
            {
                lstPrograms.Items[lstPrograms.SelectedItems[0].Index].Text = txtProgramName.Text;
                lstPrograms.Items[lstPrograms.SelectedItems[0].Index].Checked = chkEnableProgram.Checked;
                lstPrograms.Items[lstPrograms.SelectedItems[0].Index].SubItems[1].Text = txtProgramPath.Text;
                lstPrograms.Items[lstPrograms.SelectedItems[0].Index].SubItems[2].Text = txtProgramArguments.Text;
                if (!chkDLL.Checked)
                {
                    if (chkStartProgram.Checked)
                    {
                        lstPrograms.Items[lstPrograms.SelectedItems[0].Index].SubItems[3].Text = "START";
                        if (chkCloseProgram.Checked)
                        {
                            lstPrograms.Items[lstPrograms.SelectedItems[0].Index].SubItems[3].Text += "+CLOSE";
                        }
                    }
                    else if (chkCloseProgram.Checked)
                    {
                        lstPrograms.Items[lstPrograms.SelectedItems[0].Index].SubItems[3].Text = "CLOSE";
                    }
                    else
                    {
                        lstPrograms.Items[lstPrograms.SelectedItems[0].Index].SubItems[3].Text = " ";
                    }
                }
                else
                {
                    lstPrograms.Items[lstPrograms.SelectedItems[0].Index].SubItems[3].Text = "DLL";
                }
                // done with edit mode
                editProgram = false;
            }
            // when we add a new program
            else
            {
                // add program to list
                newProgram.Checked = chkEnableProgram.Checked;
                newProgram.Text = txtProgramName.Text;
                newProgram.SubItems.Add(txtProgramPath.Text);
                newProgram.SubItems.Add(txtProgramArguments.Text);
                if (!chkDLL.Checked) // if not a DLL
                {
                    if (chkStartProgram.Checked)
                    {
                        newProgram.SubItems.Add("START");
                        if (chkCloseProgram.Checked)
                        {
                            newProgram.SubItems[3].Text += "+CLOSE";
                        }
                    }
                    else if (chkCloseProgram.Checked)
                    {
                        newProgram.SubItems.Add("CLOSE");
                    }
                    else
                    {
                        newProgram.SubItems.Add("-"); // if nothing
                    }
                }
                else
                {
                    newProgram.SubItems.Add("DLL"); // if DLL
                }
                lstPrograms.Items.Add(newProgram); // add to list
            }

            // save settings in listview
            SaveProgPaths();
            tstInfoLabel.Text = "Saved program paths";

            // clear boxes
            chkCloseProgram.Checked = false;
            chkEnableProgram.Checked = false;
            chkStartProgram.Checked = false;
            chkDLL.Checked = false;
            txtProgramArguments.Clear();
            txtProgramPath.Clear();
            txtProgramName.Clear();

            // fix buttons
            btnEditProgram.Enabled = true;
            btnDeleteProgram.Enabled = true;
            lstPrograms.Enabled = true;
            chkStartProgram.Enabled = true;
            chkEnableProgram.Enabled = true;
            chkCloseProgram.Enabled = true;
        }

        private void btnEditProgram_Click(object sender, EventArgs e)
        {
            splayer.Stream = Properties.Resources.button;
            if (d2sound) { splayer.Play(); }

            if (lstPrograms.Items.Count < 1)
                return;

            // check check check
            if (lstPrograms.SelectedItems != null)
            {
                tstInfoLabel.Text = "Edit program: " + lstPrograms.SelectedItems[0].SubItems[0].Text;
                chkEnableProgram.Checked = lstPrograms.SelectedItems[0].Checked;
                txtProgramName.Text = lstPrograms.SelectedItems[0].SubItems[0].Text;
                txtProgramPath.Text = lstPrograms.SelectedItems[0].SubItems[1].Text;
                txtProgramArguments.Text = lstPrograms.SelectedItems[0].SubItems[2].Text;
                if (lstPrograms.SelectedItems[0].SubItems[3].Text.Contains("START"))
                {
                    chkStartProgram.Checked = true;
                }
                else
                {
                    chkStartProgram.Checked = false;
                }
                if (lstPrograms.SelectedItems[0].SubItems[3].Text.Contains("CLOSE"))
                {
                    chkCloseProgram.Checked = true;
                }
                else
                {
                    chkCloseProgram.Checked = false;
                }
                if (lstPrograms.SelectedItems[0].SubItems[3].Text.Contains("DLL"))
                {
                    chkDLL.Checked = true;
                }
                // disable buttons
                btnDeleteProgram.Enabled = false;
                btnEditProgram.Enabled = false;
                lstPrograms.Enabled = false;

                // edit mode
                editProgram = true;

                // set focus
                txtProgramName.Focus();
            }
        }

        private void btnDeleteProgram_Click(object sender, EventArgs e)
        {
            splayer.Stream = Properties.Resources.button;
            if (d2sound) { splayer.Play(); }

            // check check check
            if (lstPrograms.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Delete??", "You sure??", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tstInfoLabel.Text = "Program: '" + lstPrograms.SelectedItems[0].Text + "' deleted. Saved programs.";
                    lstPrograms.Items.RemoveAt(lstPrograms.SelectedItems[0].Index);
                    SaveProgPaths();
                }
            }
        }

        private void btnFindProgram_Click(object sender, EventArgs e)
        {
            splayer.Stream = Properties.Resources.button;
            if (d2sound) { splayer.Play(); }

            openFileDialog.Title = "Find '.exe' or '.dll' file to launch from the Main page";
            openFileDialog.Filter = ".exe/.dll file (*.exe/*.dll)|*.exe;*.dll";
            if (txtProgramPath.Text != "")
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(txtProgramPath.Text);
                openFileDialog.FileName = Path.GetFileName(txtProgramPath.Text);
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtProgramPath.Text = openFileDialog.FileName;
            }
        }
        #endregion

        #region find+add+edit+delete d2
        // find game.exe file
        private void btnFindD2_Click(object sender, EventArgs e)
        {
            // gogo find game.exe
        }

        // save d2info
        private void btnD2addSave_Click(object sender, EventArgs e)
        {
            // check valid info
            // add to d2list
            // add to listview
            // save settings
            // update flow
        }

        // edit marked d2
        private void btnD2edit_Click(object sender, EventArgs e)
        {
            // check valid info
            // edit d2list (remove old + add new?)
            // add to listview
            // save settings
            // update flow
        }

        // delete d2 from list
        private void btnD2delete_Click(object sender, EventArgs e)
        {
            // remove from d2list
            // remove from listview
            // save settings
            // update flow
        }
        #endregion

        #region Link label + tab changed
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // more arguments
            Process.Start("http://diablo2.diablowiki.net/Game_commands#Target_Line_Commands");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            splayer.Stream = Properties.Resources.button;
            if (d2sound) { splayer.Play(); }
        }
        #endregion

        #region Small UI stuff
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            d2procs.ReleaseD2Windows();
            //ReleaseD2Windows();
            //procAndDLL.AutoClosePrograms(lstPrograms);
            //AutoClosePrograms();
        }

        private void chkDLL_CheckedChanged(object sender, EventArgs e)
        {
            splayer.Stream = Properties.Resources.button;
            if (d2sound) { splayer.Play(); }

            if (chkDLL.Checked)
            {
                txtProgramArguments.Enabled = false;
                chkCloseProgram.Enabled = false;
                chkStartProgram.Enabled = false;
                chkEnableProgram.Enabled = false;
            }
            else
            {
                txtProgramArguments.Enabled = true;
                chkCloseProgram.Enabled = true;
                chkStartProgram.Enabled = true;
                chkEnableProgram.Enabled = true;
            }
        }

        private void ifEnter(object sender, KeyEventArgs e) //only set for program/dll FIX!!!
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtProgramPath.Text != "" && txtProgramName.Text != "")
                {
                    btnAddProgram_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("It seems your forgot the button name or the program path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtProgramArguments_KeyDown(object sender, KeyEventArgs e) // ifEnter
        {
            ifEnter(sender, e);
        }

        private void txtProgramPath_KeyDown(object sender, KeyEventArgs e) // ifEnter
        {
            ifEnter(sender, e);
        }

        private void txtProgramName_KeyDown(object sender, KeyEventArgs e) // ifEnter
        {
            ifEnter(sender, e);
        }

        private void lstPrograms_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            splayer.Stream = Properties.Resources.button;
            if (d2sound) { splayer.Play(); }

            // save and update ui
            SaveProgPaths();
            UpdateFlow2();
            UpdateContextMenu();
        }

        private void lstDiablo2Paths_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // edit d2list (remove old + add new?)
            // add to listview
            // save settings
            // update flow
        }

        private void tsbSound_Click(object sender, EventArgs e)
        {
            if (d2sound)
            {
                d2sound = false;
                tsbSound.Image = Properties.Resources.d2chk_false;
                tsbSound.Text = "Sound: OFF";
            }
            else
            {
                d2sound = true;
                splayer.Stream = Properties.Resources.button;
                if (d2sound) { splayer.Play(); }
                tsbSound.Image = Properties.Resources.d2chk_true;
                tsbSound.Text = "Sound: ON";
            }
        }

        private void SetNewFont() // needs work
        {
            byte[] fontBytes = Properties.Resources.D2small;
            string fontpath = Path.Combine(Path.GetTempPath(), "d2qsD2Font.ttf");

            using (FileStream fontfile = new FileStream(fontpath, FileMode.OpenOrCreate))
                fontfile.Write(fontBytes, 0, fontBytes.Length);
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(fontpath);
            //foreach (Control c in this.Controls)
            //{
            //    c.Font = new Font(pfc.Families[0], 7, FontStyle.Regular);
            //}
        }
        #endregion
    }
}
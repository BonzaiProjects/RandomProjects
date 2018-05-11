using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2QS
{
    public partial class Form1 : Form
    {
        DiabloManager dm = new DiabloManager();
        int mainWidth = 0;
        int mainHeight = 0;

        public Form1()
        {
            InitializeComponent();
        }

        #region DiabloSettingsGUI
        DiabloInfo editingDiablo;
        private void tmDiabloEdit_Click(object sender, EventArgs e)
        {
            dgvDiabloSettings.EndEdit();
            editingDiablo = (DiabloInfo)dgvDiabloSettings.CurrentRow.DataBoundItem;
            txtGamePath.Text = editingDiablo.GamePath;
            txtArguments.Text = editingDiablo.Arguments;
            txtWindowTitle.Text = editingDiablo.WindowTitle;
            chkShowOnMain.Checked = editingDiablo.ShowOnMain;
            chkUseGlide.Checked = editingDiablo.UseGlideSettings;
            chkWindowMode.Checked = editingDiablo.GlideSettings.WindowMode == 1 ? true : false;
            chkCaptureMouse.Checked = editingDiablo.GlideSettings.CaptureMouse == 1 ? true : false;
            cmbStaticSize.SelectedIndex = (int)editingDiablo.GlideSettings.StaticSize;
            chkDesktopResolution.Checked = editingDiablo.GlideSettings.DesktopResolution == 1 ? true : false;

            // update gui
            EditMode(true);
        }

        private void EditMode(bool on)
        {
            if (on)
            {
                // update buttons
                btnAddDiabloToList.Visible = false;
                btnAddDiabloToList.Enabled = false;
                btnEditDiabloCancel.Visible = true;
                btnEditDiabloCancel.Enabled = true;
                btnEditDiabloUpdate.Visible = true;
                btnEditDiabloUpdate.Enabled = true;
                dgvDiabloSettings.Enabled = false;
            }
            else
            {
                // clear
                txtGamePath.Text = "";
                txtWindowTitle.Text = "";
                chkUseGlide.Checked = false;
                chkWindowMode.Checked = true;
                chkCaptureMouse.Checked = false;
                cmbStaticSize.SelectedIndex = 0;
                chkDesktopResolution.Checked = true;
                dgvDiabloSettings.ClearSelection();
                
                // update buttons
                btnAddDiabloToList.Visible = true;
                btnAddDiabloToList.Enabled = true;
                btnEditDiabloCancel.Visible = false;
                btnEditDiabloCancel.Enabled = false;
                btnEditDiabloUpdate.Visible = false;
                btnEditDiabloUpdate.Enabled = false;
                dgvDiabloSettings.Enabled = true;
            }
        }

        private void tmDiabloDelete_Click(object sender, EventArgs e)
        {
            DiabloInfo selectedItem = (DiabloInfo)dgvDiabloSettings.CurrentRow.DataBoundItem;
            DialogResult res = MessageBox.Show("Delete this?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                dm.RemoveDiabloEntry(selectedItem);
            }
        }

        private void dgvDiabloSettings_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && dgvDiabloSettings.SelectedRows.Count == 1)
            {
                ctmDiabloList.Show(MousePosition);
            }
        }

        private void btnEditDiabloUpdate_Click(object sender, EventArgs e)
        {
            dm.RemoveDiabloEntry(editingDiablo);
            AddDiabloSettings();
            EditMode(false);
        }

        private void btnEditDiabloCancel_Click(object sender, EventArgs e)
        {
            EditMode(false);
        }

        private void btnAddDiabloToList_Click(object sender, EventArgs e)
        {
            AddDiabloSettings();
        }

        private void AddDiabloSettings()
        {
            DiabloInfo d = new DiabloInfo(txtGamePath.Text, txtArguments.Text, txtWindowTitle.Text, txtButtonText.Text, chkShowOnMain.Checked, chkRunAsAdmin.Checked, chkUseGlide.Checked, 
                chkWindowMode.Checked ? 1 : 0, chkCaptureMouse.Checked ? 1 : 0, (StaticSize)cmbStaticSize.SelectedIndex, chkDesktopResolution.Checked ? 1 : 0);
            dm.AddDiabloEntry(d);
        }
        
        private void tmDiabloDesktopShortcut_Click(object sender, EventArgs e)
        {
            DiabloInfo d = (DiabloInfo)dgvDiabloSettings.CurrentRow.DataBoundItem;
            string args = "-start " + Helper.ToShortString(d.ID);
            WshShell wsh = new WshShell();
            IWshShortcut shortcut = wsh.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\D2QS - " + d.ButtonText + ".lnk") as IWshShortcut;
            shortcut.Arguments = args;
            shortcut.TargetPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            // not sure about what this is for
            shortcut.WindowStyle = 1;
            shortcut.Description = "Start D2QS";
            shortcut.WorkingDirectory = Directory.GetCurrentDirectory();
            shortcut.IconLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            shortcut.Save();
        }
        #endregion

        private void CreateDiabloBox(DiabloInfo diablo)
        {
            GroupBox gb = new GroupBox();
            gb.Text = "Window Title:";
            if (diablo.WindowTitle != "" && diablo.WindowTitle != null)
            {
                gb.Text += Environment.NewLine + diablo.WindowTitle;
            }
            gb.Size = new Size(87, 100);

            Button btn = new Button();
            btn.Text = diablo.ButtonText;
            btn.Tag = diablo;
            btn.Click += Btn_Click;
            gb.Controls.Add(btn);
            btn.Location = new Point(6, 46);

            TextBox txt = new TextBox();
            txt.Tag = diablo;
            txt.Name = "txtArgs" + diablo.ToString();
            txt.Text = diablo.Arguments;
            txt.TextChanged += Txt_TextChanged;
            txt.Size = new Size(87, 20);
            gb.Controls.Add(txt);
            txt.Location = new Point(0, 74);

            Label lbl = new Label();
            lbl.Text = "?";
            lbl.Font = new Font(lbl.Font.Name, lbl.Font.SizeInPoints, FontStyle.Underline);
            SetToolTip(lbl, "DiabloInfo:" + Environment.NewLine + diablo.GamePath + Environment.NewLine + diablo.Arguments + Environment.NewLine + diablo.WindowTitle + Environment.NewLine
                + diablo.ButtonText + Environment.NewLine + "RunAsAdmin: " + (diablo.RunAsAdmin ? "True": "False") + Environment.NewLine + "UseGlideSettings: " 
                + (diablo.UseGlideSettings ? "True" : "False") + Environment.NewLine + "GlideSettings:" + Environment.NewLine + "WindowMode: " + diablo.GlideSettings.WindowMode
                + Environment.NewLine + "CaptureMouse: " + diablo.GlideSettings.CaptureMouse + Environment.NewLine + "StaticSize: " + Helper.GetEnumDescription(diablo.GlideSettings.StaticSize)
                + Environment.NewLine + "DesktopResolution: " + diablo.GlideSettings.DesktopResolution);
            lbl.Cursor = Cursors.Hand;
            gb.Controls.Add(lbl);
            lbl.Location = new Point(75, 0);

            flpDiabloBoxes.Controls.Add(gb);
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            DiabloInfo d2 = (DiabloInfo)((TextBox)sender).Tag;
            d2.Arguments = ((TextBox)sender).Text;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            DiabloInfo d2 = (DiabloInfo)((Button)sender).Tag;
            string args = ((TextBox)((GroupBox)((Button)sender).Parent).Controls["txtArgs" + d2.ToString()]).Text;
            d2.Arguments = args;
            dm.StartDiablo(d2, this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                dm.LoadDiabloInfoListFromSettings();
                if (Environment.GetCommandLineArgs()[1].ToLower().StartsWith("-start") && Environment.GetCommandLineArgs().Length > 2)
                {
                    Hide();
                    Guid id = Helper.FromShortString(Environment.GetCommandLineArgs()[2]);
                    foreach (DiabloInfo item in dm.DiabloInfoList)
                    {
                        //MessageBox.Show("Compare:" + Environment.NewLine + item.ID + Environment.NewLine + id);
                        if (item.ID == id)
                        {
                            dm.StartDiablo(item, this);
                            Close();
                            return;
                        }
                    }
                }
                if (Environment.GetCommandLineArgs()[1].ToLower().StartsWith("-startall") && dm.DiabloInfoList.Count > 0)
                {
                    Hide();
                    foreach (DiabloInfo item in dm.DiabloInfoList)
                    {
                        dm.StartDiablo(item, this);
                    }
                    Close();
                    return;
                }
                MessageBox.Show("Didn't find any setting fitting your shortcut. Try making a new one.");
                Show();
            }

            SetToolTip(lblArgumentHelp, "Remember -w for window mode.");
            SetToolTip(lblGlideSettings, "Will override current glide settings. Don't start different D2 with different glide settings.");
            dm.DiabloInfoList.ListChanged += DiabloInfoList_ListChanged;
            cmbStaticSize.DataSource = Helper.ToList(typeof(StaticSize));
            cmbStaticSize.DisplayMember = "Value";
            cmbStaticSize.ValueMember = "Key";

            // get dats source for data grid views
            dgvDiabloSettings.DataSource = dm.DiabloInfoList;
            if (dm.SelectedRealm != -1)
            {
                cmbDiabloRealmList.DataSource = dm.DiabloRealmList;
                cmbDiabloRealmList.DisplayMember = "Realm";
                cmbDiabloRealmList.SelectedIndex = dm.SelectedRealm;
            }
            else
            {
                cmbDiabloRealmList.Items.Add("ERROR");
                cmbDiabloRealmList.SelectedIndex = 0;
            }

            //string t = "";
            //foreach (DataGridViewColumn item in dgvDiabloSettings.Columns)
            //{
            //    t += item.Name + Environment.NewLine;
            //}
            //MessageBox.Show(t);

            // fix diablosettings columns
            dgvDiabloSettings.Columns["GlideSettings"].Visible = false;
            dgvDiabloSettings.Columns["RunAsAdmin"].Visible = false;
            dgvDiabloSettings.Columns["ButtonText"].Visible = false;
            dgvDiabloSettings.Columns["ID"].Visible = false;
            dgvDiabloSettings.Columns["ShowOnMain"].DisplayIndex = 0;
            dgvDiabloSettings.Columns["ShowOnMain"].HeaderText = "Show";
            dgvDiabloSettings.Columns["ShowOnMain"].Width = 40;
            dgvDiabloSettings.Columns["WindowTitle"].DisplayIndex = 1;
            dgvDiabloSettings.Columns["WindowTitle"].Width = 95;
            dgvDiabloSettings.Columns["WindowTitle"].HeaderText = "Window Title";
            dgvDiabloSettings.Columns["UseGlideSettings"].DisplayIndex = 2;
            dgvDiabloSettings.Columns["UseGlideSettings"].HeaderText = "Use Glide";
            dgvDiabloSettings.Columns["UseGlideSettings"].Width = 60;
            //dgvDiabloSettings.Columns["Arguments"].DisplayIndex = 3;
            dgvDiabloSettings.Columns["Arguments"].HeaderText = "Arguments";
            dgvDiabloSettings.Columns["Arguments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvDiabloSettings.Columns["Arguments"].Width = 60;
            //dgvDiabloSettings.Columns["GamePath"].DisplayIndex = 4;
            dgvDiabloSettings.Columns["GamePath"].HeaderText = "Game Path";
            dgvDiabloSettings.Columns["GamePath"].Width = 120;
            //dgvDiabloSettings.Columns["GamePath"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            cmbStaticSize.SelectedIndex = 0;

            dm.LoadDiabloInfoListFromSettings();
            if (flpDiabloBoxes.Controls.Count == 0)
            {
                Label l = new Label();
                l.Text = "This page will contain boxes to start each Diablo setting created in the 'Diablo Settings' tab.";
                l.AutoSize = true;
                flpDiabloBoxes.Controls.Add(l);
            }
            Width = Properties.Settings.Default.MainWidth;
            Height = Properties.Settings.Default.MainHeight;
            tabControl1.Focus();
        }

        private void SetToolTip(Control control, string tooltip)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(control, tooltip);
            tt.AutoPopDelay = 10000;
        }

        private void UpdateMainDiabloBoxes()
        {
            flpDiabloBoxes.Controls.Clear();
            foreach (DiabloInfo item in dm.DiabloInfoList)
            {
                if (item.ShowOnMain)
                {
                    CreateDiabloBox(item);
                }
            }
        }

        private void DiabloInfoList_ListChanged(object sender, ListChangedEventArgs e)
        {
            // update main tab
            UpdateMainDiabloBoxes();

            if (flpDiabloBoxes.Controls.Count == 0)
            {
                Label l = new Label();
                l.Text = "This page will contain boxes to start each Diablo setting created in the 'Diablo Settings' tab.";
                l.AutoSize = true;
                flpDiabloBoxes.Controls.Add(l);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set form size depending on tab
            switch (tabControl1.SelectedIndex)
            {
                case 0: // main
                    Height = mainHeight;
                    Width = mainWidth;
                    break;
                case 1: // diablo settings
                    Width = 420;
                    Height = 525;
                    txtGamePath.Focus();
                    break;
                case 2: // program settings
                    Width = 420;
                    Height = 525;
                    break;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.MainHeight = mainHeight;
            Properties.Settings.Default.MainWidth = mainWidth;
            Properties.Settings.Default.Save();

            dm.SaveDiabloInfoListToSettings();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                mainHeight = Height;
                mainWidth = Width;
            }
        }

        private void btnPathSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.Filter = "Game.exe|Game.exe";
            // HKEY_CURRENT_USER\Software\Blizzard Entertainment\Diablo II
            string path = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Blizzard Entertainment\Diablo II", "InstallPath", @"C:\").ToString();
            dia.InitialDirectory = path;
            dia.FileName = "Game.exe";

            if (dia.ShowDialog() == DialogResult.OK)
            {
                txtGamePath.Text = dia.FileName;
            }
        }

        private void btnTotalShortcut_Click(object sender, EventArgs e)
        {
            string args = "-startall";
            WshShell wsh = new WshShell();
            IWshShortcut shortcut = wsh.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\D2QS - StartALL.lnk") as IWshShortcut;
            shortcut.Arguments = args;
            shortcut.TargetPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            // not sure about what this is for
            shortcut.WindowStyle = 1;
            shortcut.Description = "Start D2QS";
            shortcut.WorkingDirectory = Directory.GetCurrentDirectory();
            shortcut.IconLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            shortcut.Save();
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            string path = @"D:\saved.txt";
            StreamReader reader = new StreamReader(path);
            dm.DiabloInfoList.Clear();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                dm.AddDiabloEntry(dm.D2InfoFromString(line));
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            string path = @"D:\saved.txt";
            StreamWriter writer = new StreamWriter(path);
            foreach (DiabloInfo item in dm.DiabloInfoList)
            {
                writer.WriteLine(dm.D2InfoToString(item));
            }
            writer.Flush();
            writer.Close();
        }
    }
}

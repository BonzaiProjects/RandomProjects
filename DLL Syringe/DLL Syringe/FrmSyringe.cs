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

namespace DLL_Syringe
{
    public partial class FrmSyringe : Form
    {
        internal bool ProcessEditMode = false;
        internal bool DLLEditMode = false;

        public FrmSyringe()
        {
            InitializeComponent();

            // TODO: more tooltip
            // TODO: save data; settings.settings | txt file | serialize
            // TODO: autocompletesource -- fill autocomplete on focus?
            //Processes procs = new Processes();
            //Process[] allProcs = procs.FindAllProcesses();

            //AutoCompleteStringCollection procnames = new AutoCompleteStringCollection();
            //txtProcessName.AutoCompleteCustomSource.Clear();

            //foreach (Process item in allProcs)
            //{
            //    //procnames.Add(item.ProcessName);
            //    txtProcessName.AutoCompleteCustomSource.Add(item.ProcessName);
            //}
        }

        private void FillProcessListMain()
        {
            lstProcessListMain.Items.Clear();

            Processes procs = new Processes(); // proc class
            List<string[]> proctofind = new List<string[]>(); // empty list of what to look for
            string[] procinfo = { "", "" }; // empty string for loop

            foreach (ListViewItem item in lstProcessListSettings.Items) // look in settings
            {
                procinfo[0] = item.SubItems[0].Text; // window title
                if (item.SubItems.Count > 1) // only if name is specified
                {
                    procinfo[1] = item.SubItems[1].Text.ToLower(); // process name
                }
                proctofind.Add(procinfo); // add to list
                string[] procinfo2 = { "", "" }; // empty dummy
                procinfo = procinfo2; // clear procinfo
            }

            List<Process> findings = procs.FindProcesses(proctofind); // use list from loop

            foreach (Process proc in findings) // put findings in list
            {
                string[] info = { proc.MainWindowTitle, proc.ProcessName, proc.Id.ToString() };
                ListViewItem lstitem = new ListViewItem(info);
                lstProcessListMain.Items.Add(lstitem);
            }
        }

        private void FillDLLlistMain()
        {
            lstDLLlistMain.Items.Clear();

            for (int i = 0; i < lstDLLlistSettings.Items.Count; i++)
            {
                ListViewItem lstitem = new ListViewItem();
                lstitem = lstDLLlistSettings.Items[i];
                lstDLLlistMain.Items.Add(lstitem);
            }

            //lstDLLlistMain.Items.AddRange(lstDLLlistSettings.Items);
        }

        private void btnProcessRefreshList_Click(object sender, EventArgs e)
        {
            FillProcessListMain(); // refill process list main
        }

        private void cmbProcessAutoRefresh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // timer
            if (cmbProcessAutoRefresh.SelectedIndex == 0) // OFF
            {
                timerProcessList.Stop();
                return;
            }
            timerProcessList.Interval = cmbProcessAutoRefresh.SelectedIndex * 1000; // set timer to X seconds
            timerProcessList.Start();
        }

        private void timerProcessList_Tick(object sender, EventArgs e)
        {
            FillProcessListMain(); // every X second refill process list main
        }

        private void btnDLLinjectDLL_Click(object sender, EventArgs e)
        {
            // TODO: results
            for (int i = 0; i < lstDLLlistMain.SelectedItems.Count; i++) // for every selected DLL
            {
                for (int j = 0; j < lstProcessListMain.SelectedItems.Count; j++) // for every selected Process
                {
                    DllInjectionResult _res = InjectDLL.GetInstance.Inject
                        (lstProcessListMain.Items[j].SubItems[0].Text, lstProcessListMain.Items[j].SubItems[1].Text, lstDLLlistMain.Items[i].SubItems[2].Text); // try to inject
                    tslTooltipMain.Text = _res.ToString();
                    switch (_res) // check the result
                    {
                        case (DllInjectionResult.DllNotFound):
                            break;
                        case (DllInjectionResult.GameProcessNotFound):
                            break;
                        case (DllInjectionResult.InjectionFailed):
                            break;
                        case (DllInjectionResult.Success):
                            break;
                    }
                }
            }
        }

        private void btnFindDLL_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDLLpath.Text = @openFileDialog.FileName;
            }
        }

        private void btnDLLsave_Click(object sender, EventArgs e)
        {
            if (txtDLLname.Text == "" || txtDLLpath.Text == "") // no info
            {
                MessageBox.Show("Failed");
                return;
            }

            if (DLLEditMode) // edit list
            {
                int _id = lstDLLlistSettings.Items.IndexOf(lstDLLlistSettings.SelectedItems[0]);
                lstDLLlistMain.Items[_id].SubItems[0].Text = txtDLLname.Text;
                lstDLLlistMain.Items[_id].SubItems[1].Text = txtDLLdescription.Text;
                lstDLLlistMain.Items[_id].SubItems[2].Text = @txtDLLpath.Text;

                lstDLLlistSettings.SelectedItems[0].SubItems[0].Text = txtDLLname.Text;
                lstDLLlistSettings.SelectedItems[0].SubItems[1].Text = txtDLLdescription.Text;
                lstDLLlistSettings.SelectedItems[0].SubItems[2].Text = @txtDLLpath.Text;

                lstDLLlistSettings.Enabled = true;
                DLLEditMode = false;
            }
            else // add new
            {              
                ListViewItem lstitem = new ListViewItem();
                lstitem.Name = ""; // 
                lstitem.SubItems.Add("");
                lstitem.SubItems.Add("");

                lstitem.SubItems[0].Text = txtDLLname.Text;
                lstitem.SubItems[1].Text = txtDLLdescription.Text;
                lstitem.SubItems[2].Text = @txtDLLpath.Text;

                lstDLLlistSettings.Items.Add(lstitem);
                
                lstDLLlistMain.Items.Add((ListViewItem)lstitem.Clone());
            }

            // cleanup
            txtDLLname.Text = "";
            txtDLLdescription.Text = "";
            txtDLLpath.Text = "";

            txtDLLname.Focus();
        }

        private void lstDLLlistSettings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // edit dll
            if (lstDLLlistSettings.SelectedItems.Count != 1)
            {
                MessageBox.Show("Select only 1 item and double click to edit");
                return;
            }

            if (lstDLLlistSettings.SelectedItems != null)
            {
                txtDLLname.Text = lstDLLlistSettings.SelectedItems[0].SubItems[0].Text;
                txtDLLdescription.Text = lstDLLlistSettings.SelectedItems[0].SubItems[1].Text;
                txtDLLpath.Text = lstDLLlistSettings.SelectedItems[0].SubItems[2].Text;
            }

            // fix interface
            lstDLLlistSettings.Enabled = false;
            DLLEditMode = true;
            txtDLLname.Focus();
        }

        private void lstProcessListSettings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // edit proc
            if (lstProcessListSettings.SelectedItems.Count != 1) // only edit 1
            {
                MessageBox.Show("Select only 1 item and double click to edit");
                return;
            }

            if (lstProcessListSettings.SelectedItems != null) // safety?
            {
                txtProcessName.Text = lstProcessListSettings.SelectedItems[0].SubItems[1].Text;
                txtProcessWinTitle.Text = lstProcessListSettings.SelectedItems[0].SubItems[0].Text;
            }

            // fix interface
            lstProcessListSettings.Enabled = false;
            ProcessEditMode = true;
            txtProcessWinTitle.Focus();
        }

        private void btnProcessSave_Click(object sender, EventArgs e)
        {
            if (txtProcessWinTitle.Text == "" && txtProcessName.Text == "") // no info
            {
                MessageBox.Show("Failed");
                return;
            }

            if (ProcessEditMode) // edit list
            {
                lstProcessListSettings.SelectedItems[0].SubItems[0].Text = txtProcessWinTitle.Text;
                lstProcessListSettings.SelectedItems[0].SubItems[1].Text = txtProcessName.Text;
                lstProcessListSettings.Enabled = true;
                ProcessEditMode = false;                
            }
            else // add new
            {
                ListViewItem lstitem = new ListViewItem();
                lstitem.Name = ""; // 
                lstitem.SubItems.Add("");
                lstitem.SubItems[0].Text = txtProcessWinTitle.Text;
                lstitem.SubItems[1].Text = txtProcessName.Text;
                lstProcessListSettings.Items.Add(lstitem);
            }

            // cleanup
            txtProcessName.Text = "";
            txtProcessWinTitle.Text = "";

            txtProcessWinTitle.Focus();
        }

        private void txtProcessWinTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtProcessName.Focus();
        }

        private void txtProcessName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnProcessSave_Click(sender, e);
        }

        private void lstDLLlistSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstDLLlistSettings.SelectedItems != null) // selected items are not 0
            {
                if (e.KeyCode == Keys.Delete) // delete selected from list
                {
                    if (MessageBox.Show("Delete selected?", "DLL Syringe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (ListViewItem item in lstDLLlistSettings.SelectedItems)
                        {
                            int _id = lstDLLlistSettings.Items.IndexOf(item); // get id for main

                            lstDLLlistMain.Items.RemoveAt(_id); // remove at main

                            lstDLLlistSettings.Items.Remove(item); // remove at settings
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.A) // select all in list
                {
                    foreach (ListViewItem item in lstDLLlistSettings.Items)
                    {
                        item.Selected = true;
                    }
                } 
            }
        }

        private void lstProcessListSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (lstProcessListSettings.SelectedItems != null) // selected items are not 0
            {
                if (e.KeyCode == Keys.Delete) // delete selected from list
                {
                    if (MessageBox.Show("Delete selected?", "DLL Syringe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (ListViewItem item in lstProcessListSettings.SelectedItems)
                        {
                            lstProcessListSettings.Items.Remove(item);
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.A) // select all in list
                {
                    foreach (ListViewItem item in lstProcessListSettings.Items)
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        private void btnProcessFullList_Click(object sender, EventArgs e)
        {
            List<ListViewItem> thechosen = new List<ListViewItem>();
            FrmProcessList frm2 = new FrmProcessList();
            if (frm2.ShowDialog() == DialogResult.Cancel) // showdialog > show -- to stop code here while we use frm2
            {
                return; // cancel button pressed
            }

            // add to list button pressed
            foreach (ListViewItem item in frm2.lstBigList.Items) // biglist is "public" on frm2
            {
                if (item.Checked) // if we checked the process in frm2
                {
                    thechosen.Add(item);
                }
            }

            frm2.Dispose(); // free resources so frm1 can use them

            foreach (ListViewItem lstitem in thechosen) // add to our list
            {
                // TODO: check if already in list?
                lstProcessListSettings.Items.Add(lstitem);
            }
        }
    }
}

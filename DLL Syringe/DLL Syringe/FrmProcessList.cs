using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace DLL_Syringe
{
    public partial class FrmProcessList : Form
    {
        public FrmProcessList()
        {
            InitializeComponent();

            FillProcessList();
        }

        private void FillProcessList()
        {
            lstBigList.Items.Clear();

            Process[] allProcs = Process.GetProcesses();

            foreach (Process proc in allProcs)
            {
                ListViewItem lstitem = new ListViewItem();
                lstitem.Name = ""; // for maintitle
                lstitem.SubItems.Add(""); // for procname
                lstitem.SubItems.Add(""); // for procid

                lstitem.SubItems[0].Text = proc.MainWindowTitle;
                lstitem.SubItems[1].Text = proc.ProcessName;
                lstitem.SubItems[2].Text = proc.Id.ToString();

                lstBigList.Items.Add(lstitem);
            }
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

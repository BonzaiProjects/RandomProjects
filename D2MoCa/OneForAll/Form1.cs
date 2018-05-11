using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneForAll
{
    public partial class Form1 : Form
    {
        DiabloPanel dp = new DiabloPanel();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"D:\Spil\Diablo II\Diablo II - 1.14D bnet1\Game.exe";
            //D2WindowController.StartD2(this, diabloHostPanel1, "D2_1", path);
            
            dp.StartD2(panel1, "D2_1", path);
            string path2 = @"D:\Spil\Diablo II\Diablo II - 1.14D bnet2\Game.exe";
            //D2WindowController.StartD2(this, diabloHostPanel2, "D2_2", path2);
            dp.StartD2(panel2, "D2_2", path2);

            dp.OnHandleChange += UpdateLabel;
        }

        private delegate void UpdateLabelDelegate(IntPtr d2, IntPtr parent, IntPtr panel, IntPtr form);
        private void UpdateLabel(IntPtr d2Handle, IntPtr d2Parent, IntPtr panelHandle, IntPtr formHandle)
        {
            if (label1.InvokeRequired)
            {
                label1.Invoke(new UpdateLabelDelegate(UpdateLabel), d2Handle, d2Parent, panelHandle, formHandle);
            }
            else
            {
                label1.Text = DateTime.Now + " -- D2: " + d2Handle + " -- Parent: " + d2Parent + " -- Panel: " + panelHandle + " -- Form: " + formHandle;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //diabloHostPanel1.BringToFront();
            //diabloHostPanel1.DiabloWindow.overlayForm.BringIntoView();
            //diabloHostPanel1.DiabloWindow.underlayForm.BringToFront();
            panel1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //diabloHostPanel2.BringToFront();
            //diabloHostPanel2.DiabloWindow.overlayForm.BringIntoView();
            //diabloHostPanel2.DiabloWindow.underlayForm.BringToFront();
            panel2.BringToFront();
        }

        private void Backup()
        {
            /*
            Process diabloProcess = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"D:\Spil\Diablo II\Diablo II - 1.14D bnet1\Game.exe";
            info.Arguments = "-w -ns";
            
            diabloProcess = Process.Start(info);
            diabloProcess.EnableRaisingEvents = true;
            //diabloProcess.Exited += new EventHandler(diabloProcess_Exited);

            // Wait for the app to load
            diabloProcess.WaitForInputIdle();

            var diabloHandle = diabloProcess.MainWindowHandle;

            DiabloWindow dw = new DiabloWindow(this, diabloHostPanel1, diabloHandle, "D2_1"); // Application.OpenForms[0]

            diabloHostPanel1.BindDiabloWindow(dw);
            dw.Activate();
            */
        }
    }
}

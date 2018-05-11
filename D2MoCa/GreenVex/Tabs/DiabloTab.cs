using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace GreenVex
{
    class DiabloTab : TabPage
    {
        private void InitializeComponent()
        {

        }

        private string exePath;

        private IntPtr diabloHandle;
        private DiabloWindow diabloWindow;
        private DiabloHostPanel diabloPanel;

        public DiabloWindow DiabloWindow { get { return diabloWindow; } }


        public DiabloTab(string text, string path)
        {
            this.exePath = path;
            this.Text = text;

            diabloPanel = new DiabloHostPanel();
            diabloPanel.Width = Convert.ToInt32(800m * 1);
            diabloPanel.Height = Convert.ToInt32(600m * 1); ;
            diabloPanel.Location = new Point(10, 14);
            this.Controls.Add(diabloPanel);

            Button LoadDiabloButton = new Button();
            LoadDiabloButton.Text = "Load D2";
            LoadDiabloButton.Location = new Point(Convert.ToInt32(800m * 1 + 20m), 10);
            LoadDiabloButton.Click += new EventHandler(LoadDiabloButton_Click);
            this.Controls.Add(LoadDiabloButton);

            CheckBox checkBox = new CheckBox();
            checkBox.Text = "Sound";
            checkBox.Location = new Point(Convert.ToInt32(800m * 1 + 20m), 40);
            this.Controls.Add(checkBox);
        }

        void LoadDiabloButton_Click(object sender, EventArgs e)
        {
            LoadDiablo2();
        }

        public void LoadDiablo2()
        {
            if (diabloWindow == null)
            {
                if (!string.IsNullOrEmpty(exePath) && System.IO.File.Exists(exePath))
                {
                    Process diabloProcess = new Process();
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = exePath;
                    if (((CheckBox)this.Controls[2]).Checked)
                        info.Arguments = "-w -sndbkg";
                    else
                        info.Arguments = "-w -ns";
                    
                    
                    diabloProcess = Process.Start(info);
                    diabloProcess.EnableRaisingEvents = true;
                    diabloProcess.Exited += new EventHandler(diabloProcess_Exited);

                    // Wait for the app to load
                    diabloProcess.WaitForInputIdle();

                    diabloHandle = diabloProcess.MainWindowHandle;

                    // If greater than Windows XP
                    if (Environment.OSVersion.Version.Major > 5)
                    {
                        diabloWindow = new DiabloWindow(Application.OpenForms[0], diabloPanel, diabloHandle, Text);
                        diabloPanel.BindDiabloWindow(diabloWindow);

                        if (((TabControl)this.Parent).SelectedTab == this)
                        {
                            diabloWindow.Activate();
                        }
                        else
                        {
                            diabloWindow.Deactivate();
                        }
                    }
                }
                else
                {
                    //ConsoleTab.WriteLine("Could not find diablo 2 game.exe " + exePath);
                }
            }
        }

        private delegate void ProcessExitedDelegate(object sender, EventArgs e);
        void diabloProcess_Exited(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new ProcessExitedDelegate(diabloProcess_Exited), sender, e);
                }
                catch (Exception)
                {
                }
            }
            else
            {
                diabloPanel.ReleaseDiabloWindow();

                if (diabloWindow != null)
                {
                    diabloWindow.Close();
                    diabloWindow = null;
                }

                //ConsoleTab.WriteLine("Closed " + ((Process)sender).StartInfo.FileName);
            }
        }

        public void Activate()
        {
            if (diabloWindow != null)
            {
                DiabloWindow.SetHostPanel(diabloPanel);
                diabloWindow.Activate();
            }
        }

        public void Deactivate()
        {
            if (diabloWindow != null)
            {
                diabloWindow.Deactivate();
            }
        }
    }
}

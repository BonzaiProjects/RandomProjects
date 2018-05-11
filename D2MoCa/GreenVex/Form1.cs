using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenVex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ReleaseAll()
        {
            if (dhpActiveMain.DiabloWindow != null)
            {
                dhpActiveMain.ReleaseDiabloWindow();
            }

            foreach (TabPage tab in this.tabControl1.TabPages)
            {
                if (tab is DiabloTab)
                {
                    DiabloHostPanel diabloPanel = tab.Controls[0] as DiabloHostPanel;
                    if (diabloPanel != null)
                    {
                        diabloPanel.ReleaseDiabloWindow();
                    }
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab is DiabloTab)
                {
                    ((DiabloTab)tab).Deactivate();
                }
                //else if (tab is OverviewTab)
                //{
                //    ((OverviewTab)tab).Deactivate();
                //}
            }

            UpdateFlows();
        }

        private void UpdateFlows()
        {
            if (this.tabControl1.SelectedTab is DiabloTab)
            {
                ((DiabloTab)this.tabControl1.SelectedTab).Activate();
            }
            else // main tab
            {
                foreach (TabPage tab in tabControl1.TabPages)
                {
                    if (dhpActiveMain.DiabloWindow != null && tab.Text == dhpActiveMain.DiabloWindow.Text)
                    {

                    }
                    else if (tab is DiabloTab)
                    {
                        // Look through the current panels to see if we have added it already.
                        DiabloHostPanel existingPanel = null;

                        foreach (Panel panel in flpDiabloWindows.Controls)
                        {
                            if (panel.Controls.Count > 0 && ((DiabloTab)tab).DiabloWindow == ((DiabloHostPanel)panel.Controls[0]).DiabloWindow)
                            {
                                existingPanel = (DiabloHostPanel)panel.Controls[0];
                                break;
                            }
                        }

                        // If we have, activate it.
                        if (existingPanel != null)
                        {
                            existingPanel.DiabloWindow.SetHostPanel(existingPanel);
                            existingPanel.DiabloWindow.Activate();
                        }
                        // If we havnt, Add it.
                        else
                        {
                            if (((DiabloTab)tab).DiabloWindow != null)
                            {
                                existingPanel = new DiabloHostPanel();
                                existingPanel.Width = 334; // Convert.ToInt32(400m * 1);
                                existingPanel.Height = 250; // Convert.ToInt32(300m * 1);
                                existingPanel.Location = new Point(10, 10);
                                ((Panel)flpDiabloWindows.Controls[((DiabloTab)tab).Text]).Controls.Add(existingPanel);
                                //flpDiabloWindows.Controls.Add(existingPanel);
                                //main.Controls.Add(existingPanel); // here
                                existingPanel.BindDiabloWindow(((DiabloTab)tab).DiabloWindow);
                                existingPanel.DiabloWindow.SetHostPanel(existingPanel);
                                existingPanel.DiabloWindow.Activate();
                            }
                        }
                    }
                }

                // Remove any inactive panels
                for (int i = flpDiabloWindows.Controls.Count; i > 0; i--)
                {
                    if (((Panel)flpDiabloWindows.Controls[i - 1]).Controls.Count > 0)
                    {
                        DiabloHostPanel panel = ((Panel)flpDiabloWindows.Controls[i - 1]).Controls[0] as DiabloHostPanel;
                        if (panel != null)
                        {
                            if (panel.DiabloWindow == null || panel.DiabloWindow.Disposed)
                            {
                                ((Panel)flpDiabloWindows.Controls[0]).Controls.Remove(panel);
                                //flpDiabloButtons
                            }
                        }
                    }
                }
            }
        }

        private void UpdateGroupBoxes()
        {
            flpDiabloButtons.Controls.Clear();

            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab is DiabloTab)
                {
                    Panel p = new Panel { Name = ((DiabloTab)tab).Text, Width = 334, Height = 250 };
                    p.Margin = new Padding(0);
                    flpDiabloButtons.Margin = new Padding(0);
                    flpDiabloWindows.Controls.Add(p);

                    GroupBox box = new GroupBox();
                    box.Text = tab.Text;
                    box.Width = 190;
                    box.Height = 250;
                    flpDiabloButtons.Controls.Add(box);
                    ButtonMaker((DiabloTab)tab, box);
                }
            }
        }

        private void ButtonMaker(DiabloTab tab, GroupBox box)
        {
            // close, activate, abuse
            for (int i = 0; i < 4; i++)
            {
                Button b = new Button();
                switch (i)
                {
                    case 0:
                        b.Text = "Activate Diablo";
                        b.Location = new Point(10, 20);
                        break;
                    case 1:
                        b.Text = "Close Diablo";
                        b.Location = new Point(10, 50);
                        break;
                    case 2:
                        b.Text = "Abuse Diablo";
                        b.Location = new Point(10, 80);
                        break;
                    case 3:
                        b.Text = "Load Diablo";
                        b.Location = new Point(10, 110);
                        break;
                }
                b.Tag = tab;
                box.Controls.Add(b);
                b.Click += B_Click;
            }
        }

        private void B_Click(object sender, EventArgs e)
        {
            DiabloTab tab = (DiabloTab)((Button)sender).Tag;

            switch (((Button)sender).Text)
            {
                case "Activate Diablo":
                    if (dhpActiveMain.DiabloWindow != null)
                    {
                        foreach (var item in tabControl1.TabPages)
                        {
                            if (item is DiabloTab && ((DiabloTab)item).Text == dhpActiveMain.DiabloWindow.Text)
                            {
                                dhpActiveMain.DiabloWindow.Deactivate();
                                ((DiabloHostPanel)((DiabloTab)item).Controls[0]).BindDiabloWindow(dhpActiveMain.DiabloWindow);
                                ((DiabloHostPanel)((DiabloTab)item).Controls[0]).DiabloWindow.SetHostPanel(((DiabloHostPanel)((DiabloTab)item).Controls[0]));
                                ((DiabloHostPanel)((DiabloTab)item).Controls[0]).DiabloWindow.Activate();
                                ((DiabloHostPanel)((DiabloTab)item).Controls[0]).RegisterEvents();
                                UpdateFlows();
                                break;
                            }
                        }
                    }
                    tab.DiabloWindow.Deactivate();
                    dhpActiveMain.BindDiabloWindow(tab.DiabloWindow);
                    dhpActiveMain.DiabloWindow.SetHostPanel(dhpActiveMain);
                    dhpActiveMain.DiabloWindow.Activate();
                    dhpActiveMain.RegisterEvents();
                    break;
                case "Close Diablo":

                    UpdateFlows();
                    break;
                case "Abuse Diablo": // checkbox?

                    break;
                case "Load Diablo":
                    tab.LoadDiablo2();
                    UpdateFlows();
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(new DiabloTab("D2_1", @"D:\Spil\Diablo II\Diablo II - 1.14D bnet1\Game.exe"));
            tabControl1.TabPages.Add(new DiabloTab("D2_2", @"D:\Spil\Diablo II\Diablo II - 1.14D bnet2\Game.exe"));
            tabControl1.TabPages.Add(new DiabloTab("D2_3", @"D:\Spil\Diablo II\Diablo II - 1.14D bnet3\Game.exe"));
            tabControl1.TabPages.Add(new DiabloTab("D2_4", @"D:\Spil\Diablo II\Diablo II - 1.14D bnet4\Game.exe"));

            UpdateFlows();
            UpdateGroupBoxes();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleaseAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateFlows();
        }
    }
}

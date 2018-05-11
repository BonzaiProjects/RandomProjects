using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2PartyTime
{
    public partial class Form1 : Form
    {
        Process p = new Process();

        private const int SW_SHOWMAXIMIZED = 3;

        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOREPOSITION = 0x0200;

        public static int GWL_STYLE = -16;
        private const int WS_MAXIMIZE = 0x01000000;
        public static int WS_CHILD = 0x40000000; //child window
        public static int WS_BORDER = 0x00800000; //window with border
        public static int WS_DLGFRAME = 0x00400000; //window with double border but no title
        public static int WS_CAPTION = 0x00C00000;
        public static int WS_SIZEBOX = 0x00040000;
        public static int WS_THICKFRAME = 0x00040000;
        private static int MYSTUFF = WS_BORDER | WS_DLGFRAME | WS_CAPTION | WS_SIZEBOX | WS_THICKFRAME;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void RunD2(string path, Panel pan)
        {
            ProcessStartInfo psi = new ProcessStartInfo(path);
            psi.Arguments = "-w";
            //psi.WindowStyle = ProcessWindowStyle.Minimized;
            p = Process.Start(psi);
            p.WaitForInputIdle();

            while (p.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Yield();
            }

            IntPtr pt = p.MainWindowHandle;
            SafeNativeMethods.SetParent(pt, pan.Handle); // Process.GetCurrentProcess().MainWindowHandle);
            int style = SafeNativeMethods.GetWindowLong(pt, GWL_STYLE); // get the original window style
            SafeNativeMethods.SetWindowLong(pt, GWL_STYLE, (style & ~MYSTUFF)); // change window style (remove border)
            SafeNativeMethods.SetWindowPos(pt, IntPtr.Zero, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOZORDER); // move to the corner of the panel
            //SafeNativeMethods.ShowWindow(pt, SW_SHOWMAXIMIZED); // maximize the window
        }
        
        internal class SafeNativeMethods
        {
            [DllImport("user32.dll")]
            public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32")]
            public static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndParent);

            [DllImport("user32.dll")]
            internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            [DllImport(@"user32.dll", EntryPoint = "SetWindowPos", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
            public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            return;
            IntPtr pt = p.MainWindowHandle;
            SafeNativeMethods.SetParent(pt, pnlMainD2.Handle); // Process.GetCurrentProcess().MainWindowHandle);
            int style = SafeNativeMethods.GetWindowLong(pt, GWL_STYLE); // get the original window style
            SafeNativeMethods.SetWindowLong(pt, GWL_STYLE, (style & ~MYSTUFF)); // change window style (remove border)
            SafeNativeMethods.SetWindowPos(pt, IntPtr.Zero, 0, 0, 0, 0, SWP_NOSIZE); // move to the corner of the panel
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path1 = @"D:\Spil\Diablo II\Diablo II - 1.14D bnet1\Game.exe";
            RunD2(path1, pnlMainD2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path2 = @"D:\Spil\Diablo II\Diablo II - 1.14D bnet2\Game.exe";

            RunCustomD2(path2, diabloPanel);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //diabloPanel.D2Window.Activate();
        }

        IntPtr diabloHandle;
        D2Window diabloWindow = null;
        private void RunCustomD2(string path, D2HostPanel diabloPanel)
        {
            if (diabloWindow == null)
            {
                if (!string.IsNullOrEmpty(path) && System.IO.File.Exists(path))
                {
                    Process diabloProcess = new Process();
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = path;
                    info.Arguments = "-w";

                    diabloProcess = Process.Start(info);
                    diabloProcess.EnableRaisingEvents = true;
                    diabloProcess.Exited += new EventHandler(diabloProcess_Exited);

                    // Wait for the app to load
                    diabloProcess.WaitForInputIdle();

                    diabloHandle = diabloProcess.MainWindowHandle;

                    // If greater than Windows XP
                    if (System.Environment.OSVersion.Version.Major > 5)
                    {
                        diabloWindow = new D2Window(Application.OpenForms[0], diabloPanel, diabloHandle);
                        diabloPanel.BindDiabloWindow(diabloWindow);
                    }
                }
            }
            //diabloPanel.DiabloWindow.Activate();
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
            }
        }
    }
}

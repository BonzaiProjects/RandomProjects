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

namespace D2Testing
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

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
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

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // start and throw into panel
            StartD2(@"D:\Spil\Diablo II\Diablo II - 1.14D bnet1\Game.exe", d2HostPanel1);

            Rectangle myRect = new Rectangle();

            RECT rct;

            if (!SafeNativeMethods.GetWindowRect(new HandleRef(d2HostPanel1, p.MainWindowHandle), out rct))
            {
                MessageBox.Show("ERROR");
                return;
            }
            //MessageBox.Show(rct.ToString());

            myRect.X = rct.Left;
            myRect.Y = rct.Top;
            myRect.Width = rct.Right - rct.Left;
            myRect.Height = rct.Bottom - rct.Top;
            d2HostPanel1.Width = myRect.Width;
            d2HostPanel1.Height = myRect.Height;
            label2.Text = "Height: " + d2HostPanel1.Height + " || Width: " + d2HostPanel1.Width;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // create invisible top layer
            AddOverlayWindow(d2HostPanel1);
        }

        private void AddOverlayWindow(D2HostPanel panel)
        {
            D2Overlay overlay = new D2Overlay(panel, p.MainWindowHandle);
            Subscribe(overlay);
            overlay.Focus();
        }

        private void Subscribe(D2Overlay o)
        {
            o.status += new D2Overlay.StatusUpdate(HeardIt);
        }
        private void HeardIt(string status, EventArgs e)
        {
            label1.Text = status;
        }

        private void StartD2(string path, D2HostPanel panel)
        {
            ProcessStartInfo psi = new ProcessStartInfo(path);
            psi.Arguments = "-w -sndbkg";
            p = Process.Start(psi);
            p.WaitForInputIdle();

            while (p.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Yield();
            }

            IntPtr pt = p.MainWindowHandle;
            SafeNativeMethods.SetParent(pt, panel.Handle); // Process.GetCurrentProcess().MainWindowHandle);
            int style = SafeNativeMethods.GetWindowLong(pt, GWL_STYLE); // get the original window style
            SafeNativeMethods.SetWindowLong(pt, GWL_STYLE, (style & ~MYSTUFF)); // change window style (remove border)
            SafeNativeMethods.SetWindowPos(pt, IntPtr.Zero, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOZORDER); // move to the corner of the panel
            p.EnableRaisingEvents = true;
            p.Exited += P_Exited;
            //SafeNativeMethods.ShowWindow(pt, SW_SHOWMAXIMIZED); // maximize the window
        }

        private void P_Exited(object sender, EventArgs e)
        {
            CloseOverlay();
        }

        delegate void CloseOverlayDelegate();
        private void CloseOverlay()
        {
            if (d2HostPanel1.InvokeRequired || label1.InvokeRequired)
            {
                CloseOverlayDelegate d = new CloseOverlayDelegate(CloseOverlay);
                this.Invoke(d);
            }
            else
            {
                foreach (Control item in d2HostPanel1.Controls)
                {
                    if (item is D2Overlay)
                    {
                        ((D2Overlay)item).UnRegisterEvents();
                        d2HostPanel1.Controls.Remove(item);
                    }
                }
                //d2HostPanel1.Controls.Clear();
                label1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StartD2(@"D:\Spil\Diablo II\Diablo II - 1.14D bnet2\Game.exe", d2HostPanel2);
            AddOverlayWindow(d2HostPanel2);
        }
    }
}

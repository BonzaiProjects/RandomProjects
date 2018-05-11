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
using System.Windows.Interop;

namespace D2aioFrm
{
    public partial class Form1 : Form
    {
        Process p = new Process();

        public Form1()
        {
            InitializeComponent();
            //GoFullScreen();
        }

        private void GoFullScreen()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

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
        private static int MYSTUFF = WS_BORDER | WS_DLGFRAME | WS_CAPTION |WS_SIZEBOX | WS_THICKFRAME;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSDK.ItemWorker iw = new DataSDK.ItemWorker();
            return;

            string path = @"D:\Dropbox\GitHub\d2bot-with-kolbot - vHack new\D2Bot.exe";
            ProcessStartInfo psi = new ProcessStartInfo(path);
            p = Process.Start(psi);
            p.WaitForInputIdle();

            while (p.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Yield();
            }

            IntPtr pt = p.MainWindowHandle; // get the handle from the process
            SafeNativeMethods.SetParent(pt, panel1.Handle); // set main handle = handle of the panel frame
            int style = SafeNativeMethods.GetWindowLong(pt, GWL_STYLE); // get the original window style
            SafeNativeMethods.SetWindowLong(pt, GWL_STYLE, (style & ~MYSTUFF)); // change window style (remove border)
            SafeNativeMethods.ShowWindow(pt, SW_SHOWMAXIMIZED); // maximize the window
        }

        internal class SafeNativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

            [DllImport("user32.dll", SetLastError = true)]
            internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32")]
            internal static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndParent);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            internal static extern bool SetWindowText(IntPtr hWnd, string text);

            [DllImport("user32.dll", SetLastError = true)]
            internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

            [DllImport("user32.dll")]
            internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

            [DllImport("user32.dll", SetLastError = true)]
            internal static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            internal static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }
    }
}

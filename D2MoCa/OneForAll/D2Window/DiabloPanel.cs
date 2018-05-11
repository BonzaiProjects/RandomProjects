using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneForAll
{
    public class DiabloPanel
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport(@"user32.dll", EntryPoint = "SetWindowPos", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern IntPtr GetParent(IntPtr hWnd);

        private const uint SWP_NOSIZE = 0x0001;
        //private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOZORDER = 0x0004;
        //private const uint SWP_NOREDRAW = 0x0008;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_FRAMECHANGED = 0x0020;
        //private const uint SWP_SHOWWINDOW = 0x0040;
        //private const uint SWP_HIDEWINDOW = 0x0080;
        //private const uint SWP_NOCOPYBITS = 0x0100;
        private const uint SWP_NOOWNERZORDER = 0x0200;
        //private const uint SWP_NOSENDCHANGING = 0x0400;

        private static int GWL_STYLE = -16;
        private const int WS_MAXIMIZE = 0x01000000;
        //private static int WS_CHILD = 0x40000000; //child window
        private static int WS_BORDER = 0x00800000; //window with border
        private static int WS_DLGFRAME = 0x00400000; //window with double border but no title
        private static int WS_CAPTION = 0x00C00000;
        private static int WS_SIZEBOX = 0x00040000;
        private static int WS_THICKFRAME = 0x00040000;
        private static int MYSTUFF = WS_BORDER | WS_DLGFRAME | WS_CAPTION | WS_SIZEBOX | WS_THICKFRAME;

        public delegate void CheckHandle(IntPtr d2Handle, IntPtr d2Parent, IntPtr panelHandle, IntPtr formHandle);
        public event CheckHandle OnHandleChange;

        public void StartD2(Panel hostPanel, string name, string d2Path)
        {
            // does the panel contain a D2?

            Process diabloProcess = new Process();
            diabloProcess.StartInfo.FileName = d2Path;
            diabloProcess.StartInfo.Arguments = "-w -ns -3dfx";

            diabloProcess.Start();
            diabloProcess.EnableRaisingEvents = true;
            diabloProcess.Exited += DiabloProcess_Exited;

            // Wait for the app to load
            diabloProcess.WaitForInputIdle();

            while (diabloProcess.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Yield();
            }

            var diabloHandle = diabloProcess.MainWindowHandle;
            var panelHandle = hostPanel.Handle;
            var formHandle = hostPanel.Parent.Handle;

            SetParent(diabloHandle, panelHandle);

            int style = GetWindowLong(diabloHandle, GWL_STYLE); // get the original window style
            SetWindowLong(diabloHandle, GWL_STYLE, (style & ~MYSTUFF)); // change window style (remove border)

            SetWindowPos(diabloHandle, IntPtr.Zero, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOACTIVATE | SWP_NOZORDER | SWP_NOOWNERZORDER | SWP_FRAMECHANGED);

            //Thread t = new Thread(() => Handler(diabloProcess, panelHandle, formHandle));
            //t.IsBackground = true;
            //t.Start();

            //Thread t2 = new Thread(() => Capturing(diabloHandle, panelHandle, formHandle));
            //t2.IsBackground = true;
            //t2.Start();
        }

        private void DiabloProcess_Exited(object sender, EventArgs e)
        {
            
        }
        
        private void Handler(Process d2, IntPtr panelHandle, IntPtr formHandle)
        {
            while (true)
            {
                IntPtr d2Parent = GetParent(d2.Handle);
                OnHandleChange(d2.Handle, d2Parent, panelHandle, formHandle);
                Thread.Sleep(3000);
            }
        }

        private void Capturing(IntPtr diabloHandle, IntPtr panelHandle, IntPtr formHandle)
        {
            var k1 = GetParent(diabloHandle);
            var k2 = GetParent(panelHandle);
            return;
            bool working = true;
            while (working)
            {
                if (GetParent(diabloHandle) != panelHandle)
                {
                    SetParent(diabloHandle, panelHandle);

                    int style = GetWindowLong(diabloHandle, GWL_STYLE); // get the original window style
                    SetWindowLong(diabloHandle, GWL_STYLE, (style & ~MYSTUFF)); // change window style (remove border)

                    SetWindowPos(diabloHandle, IntPtr.Zero, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOACTIVATE | SWP_NOZORDER | SWP_NOOWNERZORDER | SWP_FRAMECHANGED);
                }
                else
                {
                    working = false;
                } 
            }
        }

        private class Diablo
        {
            
        }
    }
}

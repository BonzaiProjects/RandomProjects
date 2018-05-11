using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace D2MoCa
{
    class D2procsWorker
    {
        Process D2proc;
        Process D2proc1;
        Process D2proc2;
        Process D2proc3;

        public List<D2proc> d2Procs { get; private set; }

        internal class SafeNativeMethods
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            internal static extern bool SetWindowText(IntPtr hWnd, string text);

            [DllImport("user32.dll")]
            internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        }

        public void AddD2Proc(D2proc d2)
        {
            if (d2Procs == null)
                d2Procs = new List<D2proc>();

            d2Procs.Add(d2);
        }

        public void DeleteD2Proc(D2proc d2)
        {
            if (d2Procs.Contains(d2))
                d2Procs.Remove(d2);
        }

        public void StartD2(string path, string arguments, Form d2qsForm)
        {
            CaptureD2Windows(d2qsForm);

            // simple process starter
            D2proc = new Process();

            D2proc.StartInfo.WorkingDirectory = path;
            D2proc.StartInfo.FileName = path;
            D2proc.StartInfo.Arguments = arguments;
            try
            {
                D2proc = Process.Start(D2proc.StartInfo);
                D2proc.WaitForInputIdle();
                while (D2proc.Handle == IntPtr.Zero)
                {

                }
                Thread.Sleep(1000);
                SafeNativeMethods.SetWindowText(D2proc.MainWindowHandle, "D2_1");
                return;
                // name the d2 windows
                if (D2proc.StartInfo.FileName == Properties.Settings.Default.D2Paths[0])
                {
                    SafeNativeMethods.SetWindowText(D2proc.MainWindowHandle, "D2_1");
                    return;
                }
                if (D2proc.StartInfo.FileName == Properties.Settings.Default.D2Paths[1])
                {
                    SafeNativeMethods.SetWindowText(D2proc.MainWindowHandle, "D2_2");
                    return;
                }
                if (D2proc.StartInfo.FileName == Properties.Settings.Default.D2Paths[2])
                {
                    SafeNativeMethods.SetWindowText(D2proc.MainWindowHandle, "D2_3");
                    return;
                }
                if (D2proc.StartInfo.FileName == Properties.Settings.Default.D2Paths[3])
                {
                    SafeNativeMethods.SetWindowText(D2proc.MainWindowHandle, "D2_4");
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                DialogResult diares = MessageBox.Show("You failed in either you game.exe path or your arguments" + "\n" + @"Path should be like C:\Games\Diablo II\game.exe" + "\n" +
                    "Arguments should be like -ns -glide" + "\n" + "Click yes for a list of arguments(diablo wiki site)", "You failed", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (diares == DialogResult.Yes)
                {
                    Process.Start("http://diablo2.diablowiki.net/Game_commands#Target_Line_Commands");
                }
            }
        }

        private void CaptureD2Windows(Form mainFrom)
        {
            // capture d2 windows to open an extra window
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Equals("Game") || theprocess.ProcessName.StartsWith("Game_D2"))
                {
                    if (theprocess == D2proc1 || theprocess == D2proc2 || theprocess == D2proc3)
                    {
                    }
                    else if (D2proc1 == null)
                    {
                        D2proc1 = theprocess;
                        IntPtr pt = D2proc1.MainWindowHandle;
                        SafeNativeMethods.SetParent(pt, mainFrom.Handle);
                    }
                    else if (D2proc2 == null)
                    {
                        D2proc2 = theprocess;
                        IntPtr pt = D2proc2.MainWindowHandle;
                        SafeNativeMethods.SetParent(pt, mainFrom.Handle);
                    }
                    else if (D2proc3 == null)
                    {
                        D2proc3 = theprocess;
                        IntPtr pt = D2proc3.MainWindowHandle;
                        SafeNativeMethods.SetParent(pt, mainFrom.Handle);
                    }
                }
            }
        }

        public void ReleaseD2Windows()
        {
            // release d2 windows again
            if (D2proc1 != null)
            {
                SafeNativeMethods.SetParent(D2proc1.MainWindowHandle, IntPtr.Zero);
                D2proc1 = null;
            }
            if (D2proc2 != null)
            {
                SafeNativeMethods.SetParent(D2proc2.MainWindowHandle, IntPtr.Zero);
                D2proc2 = null;
            }
            if (D2proc3 != null)
            {
                SafeNativeMethods.SetParent(D2proc3.MainWindowHandle, IntPtr.Zero);
                D2proc3 = null;
            }
        }
    }
}

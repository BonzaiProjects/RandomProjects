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

namespace D2MoCa
{
    class Proc_DLL
    {
        int[] ProgramID = new int[40]; // autostart/close program
        //bool editProgram = false; // used when adding program to listview
        //int dllbtn = 0; // used when injecting dll
        D2procsWorker d2procs = new D2procsWorker(); // used when starting d2procs

        //public void InjectDLL(string arguments) // <pid> (from the d2) "c:\path\to\dot.dll"
        //{
        //    if (File.Exists(Path.Combine(Path.GetTempPath(), "d2qsdllinject.exe")))
        //    {
        //        File.Delete(Path.Combine(Path.GetTempPath(), "d2qsdllinject.exe"));
        //    }
        //    byte[] exeBytes = Properties.Resources.RemoteDLLInjector32;
        //    string exeToRun = Path.Combine(Path.GetTempPath(), "d2qsdllinject.exe");

        //    using (FileStream exeFile = new FileStream(exeToRun, FileMode.CreateNew))
        //        exeFile.Write(exeBytes, 0, exeBytes.Length);

        //    try
        //    {
        //        Process dllProc = new Process();
        //        dllProc.StartInfo.FileName = exeToRun;
        //        dllProc.StartInfo.Arguments = arguments;
        //        dllProc.StartInfo.CreateNoWindow = true;
        //        dllProc.StartInfo.UseShellExecute = false;
        //        dllProc.Start();
        //        dllProc.WaitForExit();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        #region auto start+close programs
        public void AutoStartPrograms(ListView lstPrograms)
        {
            for (int i = 0; i < lstPrograms.Items.Count; i++)
            {
                if (lstPrograms.Items[i].SubItems[3].Text.Contains("START"))
                {
                    ProgramID.SetValue(Process.Start(lstPrograms.Items[i].SubItems[1].Text, lstPrograms.Items[i].SubItems[2].Text).Id, 0);
                }
            }
        }

        public void AutoClosePrograms(ListView lstPrograms)
        {
            for (int i = 0; i < lstPrograms.Items.Count; i++)
            {
                if (lstPrograms.Items[i].SubItems[3].Text.Contains("CLOSE"))
                {
                    Process.GetProcessById(ProgramID[0]).Kill();
                }
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneForAll
{
    public static class D2WindowController
    {
        static List<DiabloWindow> dwindows = new List<DiabloWindow>();

        public static void StartD2(Form mainForm, DiabloHostPanel panel, string title, string gameExePath)
        {
            Process diabloProcess = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = gameExePath;
            info.Arguments = "-w -ns";

            diabloProcess = Process.Start(info);
            diabloProcess.EnableRaisingEvents = true;
            //diabloProcess.Exited += new EventHandler(diabloProcess_Exited);

            // Wait for the app to load
            diabloProcess.WaitForInputIdle();

            var diabloHandle = diabloProcess.MainWindowHandle;

            DiabloWindow dw = new DiabloWindow(mainForm, panel, diabloHandle, title); // Application.OpenForms[0]

            panel.BindDiabloWindow(dw);
            dw.Activate();
        }
    }
}

using System.Collections.Generic;
using System.Diagnostics;

namespace DLL_Syringe
{
    class Processes
    {
        public List<Process> FindProcesses(List<string[]> processinfo) // processinfo = title+name
        {
            List<Process> findings = new List<Process>();
            Process[] lstprocs = Process.GetProcesses();

            foreach (Process proc in lstprocs)
            {
                foreach (string[] item in processinfo)
                {
                    if ((item[0] != null || item[0] != "") && item[0] == proc.MainWindowTitle) // find title
                    {
                        if ((item[1] != null || item[1] != "") && item[1] == proc.ProcessName.ToLower()) // find title+name combo
                        {
                            // add to findings
                            findings.Add(proc);
                        }
                        else // found only title
                        {
                            // add to findings
                            findings.Add(proc);
                        }
                    }
                    else if ((item[0] == null || item[0] == "") && (item[1] != null || item[1] != "") && item[1] == proc.ProcessName.ToLower()) // find name
                    {
                        // find only name
                        // add to findings
                        findings.Add(proc);
                    }
                    // found nothing.. next..
                }
            }
            return findings;
        }
    }
}

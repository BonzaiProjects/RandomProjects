using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2MoCa.Objects
{
    class ProcessInfo: ProcessObject
    {
        public bool AutoClose { get; set; }

        public ProcessInfo(string Name, string Path, string Arguments, Point StartPoint, bool AutoStart, bool AutoClose) : base(Name, Path, Arguments, StartPoint, AutoStart)
        {
            this.AutoClose = AutoClose;
        }
    }
}

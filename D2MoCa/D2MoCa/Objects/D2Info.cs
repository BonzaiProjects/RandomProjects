using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2MoCa.Objects
{
    class D2Info: ProcessObject
    {
        public List<IDllInfo> AutoInject { get; set; }

        public D2Info(string Name, string Path, string Arguments, Point StartPoint, bool AutoStart): base(Name, Path, Arguments, StartPoint, AutoStart)
        {
            if (AutoInject == null)
                AutoInject = new List<IDllInfo>();
        }
    }
}

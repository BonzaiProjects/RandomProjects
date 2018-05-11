using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2MoCa.Objects
{
    class ProcessObject: IProcessObject
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Arguments { get; set; }
        public Point StartPoint { get; set; }
        public bool AutoStart { get; set; }

        public ProcessObject(string Name, string Path, string Arguments, Point StartPoint, bool AutoStart)
        {
            this.Name = Name;
            this.Path = Path;
            this.Arguments = Arguments;
            this.StartPoint = StartPoint;
            this.AutoStart = AutoStart;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2MoCa.Objects
{
    class DllInfo: IDllInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public DllInfo(string Name, string Path)
        {
            this.Name = Name;
            this.Path = Path;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2MoCa
{
    class D2proc
    {
        public string d2Path { get; private set; }
        public string d2Args { get; private set; }

        public D2proc(string d2Path, string d2Args)
        {
            if (d2Args == null)
                d2Args = "";
            
            this.d2Path = d2Path;
            this.d2Args = d2Args;
        }
    }
}

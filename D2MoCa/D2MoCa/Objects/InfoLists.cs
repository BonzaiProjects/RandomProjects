using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2MoCa.Objects
{
    class InfoLists
    {
        public List<IProcessObject> ProcessList { get; set; }
        public List<IDllInfo> DllList { get; set; }

        public InfoLists()
        {
            if (ProcessList == null)
                ProcessList = new List<IProcessObject>();

            if (DllList == null)
                DllList = new List<IDllInfo>();
        }
    }
}

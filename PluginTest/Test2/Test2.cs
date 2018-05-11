using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginSDK;

namespace Test2
{
    public class Test2 : IPlugin
    {
        public string GetPluginName()
        {
            return "Test2";
        }

        public void Start(UserData data)
        {
            
        }
    }
}

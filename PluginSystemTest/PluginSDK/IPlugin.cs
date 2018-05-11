using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginSDK
{
    public interface IPlugin
    {
        string GetPluginName();
        void Start(UserData data);
    }
}

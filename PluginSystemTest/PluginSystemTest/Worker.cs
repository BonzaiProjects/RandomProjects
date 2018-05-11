using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginSDK;
using System.IO;
using System.Reflection;

namespace PluginSystemTest
{
    class Worker
    {
        public IPlugin GetPluginName()
        {
            //Load(Environment.CurrentDirectory + "\\Plugins\\PluginTest.dll");
            String[] plugins = Directory.GetFiles(Environment.CurrentDirectory + "\\Plugins", "*.dll");
            Assembly asm = null;
            Type[] tt = null;
            object t = null;
            try
            {
                asm = Assembly.LoadFile(plugins[0]);
                tt = asm.GetTypes();
                t = Activator.CreateInstance(tt[0]);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            IPlugin pl = (IPlugin)t;
            return pl;
        }

        public static IPlugin Load(String file)
        {
            if (!File.Exists(file) || !file.EndsWith(".dll", true, null))
                return null;

            Assembly asm = null;

            try
            {
                asm = Assembly.LoadFile(file);
            }
            catch (Exception)
            {
                // unable to load
                return null;
            }

            Type pluginInfo = null;
            try
            {
                Type[] types = asm.GetTypes();
                Assembly core = AppDomain.CurrentDomain.GetAssemblies().Single(x => x.GetName().Name.Equals("Lab.Core"));
                Type type = core.GetType("Lab.Core.IPlugin");
                foreach (var t in types)
                    if (type.IsAssignableFrom((Type)t))
                    {
                        pluginInfo = t;
                        break;
                    }

                if (pluginInfo != null)
                {
                    Object o = Activator.CreateInstance(pluginInfo);
                    IPlugin plugin = (IPlugin)o;
                    //Plugins.Register(plugin);
                    return plugin;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}

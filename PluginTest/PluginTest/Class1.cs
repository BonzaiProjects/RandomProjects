using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginSDK;

namespace PluginTest
{
    public class Class1 : IPlugin
    {
        public string GetPluginName()
        {
            return "Dis is ma name mofo!";
        }

        public void Start(UserData data)
        {
            Console.WriteLine("Test plugin loaded... Press a key to calculate...");
            Console.ReadKey();

            int result = 0;
            switch (data.Calc)
            {
                case CalcType.Plus:
                    result = data.NumbA + data.NumbB;
                    break;
                case CalcType.Minus:
                    result = data.NumbA - data.NumbB;
                    break;
                case CalcType.Multiply:
                    result = data.NumbA * data.NumbB;
                    break;
                case CalcType.Divide:
                    result = data.NumbA / data.NumbB;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Result: " + result);
        }
    }
}

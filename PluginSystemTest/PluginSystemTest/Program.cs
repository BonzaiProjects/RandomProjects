using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginSDK;

namespace PluginSystemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker w = new Worker();
            UserData u = new UserData();
            Console.WriteLine("Need data before we run the plugin.");
            Console.Write("Number A: ");
            int temp = 0;
            int.TryParse(Console.ReadLine(), out temp);
            u.NumbA = temp;
            temp = 0;
            Console.Write("Number B: ");
            int.TryParse(Console.ReadLine(), out temp);
            u.NumbB = temp;
            temp = 0;
            Console.WriteLine("What should we do with the numbers?");
            Console.WriteLine("     1: Plus");
            Console.WriteLine("     2: Minus");
            Console.WriteLine("     3: Multiply");
            Console.WriteLine("     4: Divide");
            Console.Write("Choice: ");
            u.Calc = (CalcType)Enum.Parse(typeof(CalcType), Console.ReadLine());
            IPlugin plug = w.GetPluginName();
            Console.WriteLine("Running plugin: " + plug.GetPluginName());
            plug.Start(u);

            Console.ReadKey();
        }
    }
}

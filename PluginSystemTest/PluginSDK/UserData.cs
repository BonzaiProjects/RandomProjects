using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginSDK
{
    public class UserData
    {
        public CalcType Calc { get; set; }
        public int NumbA { get; set; }
        public int NumbB { get; set; }
    }

    public enum CalcType
    {
        Plus = 1,
        Minus = 2,
        Multiply = 3,
        Divide = 4
    }
}

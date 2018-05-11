using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    class CenturyFromYear
    {
        public int centuryFromYear(int year)
        {
            if ((year % 100) == 0)
            {
                int result = (year / 100);
                Console.WriteLine("Year " + year + " is in the " + result + " century");
                return year / 100;
            }
            else
            {
                int result = (year / 100) + 1;
                Console.WriteLine("Year " + year + " is in the " + result + " century");
                return result;
            }
        }
    }
}

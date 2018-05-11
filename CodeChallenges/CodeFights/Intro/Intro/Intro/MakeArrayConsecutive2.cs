using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    class MakeArrayConsecutive2
    {
        public int makeArrayConsecutive2(int[] statues)
        {
            int missing = 0;
            int[] sortedCopy = statues.OrderBy(x => x).ToArray();
            for (int i = 0; i < sortedCopy.Length - 1; i++)
            {
                if (sortedCopy[i] + 1 != sortedCopy[i + 1])
                {
                    missing += (sortedCopy[i + 1] - sortedCopy[i] - 1);
                }
            }
            return missing;
        }
    }
}

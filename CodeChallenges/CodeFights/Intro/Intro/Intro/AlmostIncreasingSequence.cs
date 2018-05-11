using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    class AlmostIncreasingSequence
    {
        public bool almostIncreasingSequence(int[] sequence)
        {
            int i = checkSequence(sequence, -1);
            if (i == -1)
                return true;
            if (checkSequence(sequence, i) == -1)
                return true;
            if (checkSequence(sequence, i + 1) == -1)
                return true;
            return false;
        }

        int checkSequence(int[] sequence, int start)
        {
            if (start > 0 && start < sequence.Length - 1)
            {
                if (sequence[start - 1] >= sequence[start + 1])
                {
                    return start - 1;
                }
            }
            for (int i = start + 1; i < sequence.Length - 1; i++)
            {
                if (sequence[i] >= sequence[i + 1])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

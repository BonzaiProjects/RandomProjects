using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    class AdjacentElementsProduct
    {
        public int adjacentElementsProduct(int[] inputArray)
        {
            int result = -1000000;
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                int j = inputArray[i] * inputArray[i + 1];
                if (j > result)
                    result = j;
            }
            return result;
        }
    }
}

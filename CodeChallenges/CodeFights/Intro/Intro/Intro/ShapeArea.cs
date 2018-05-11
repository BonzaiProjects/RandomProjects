using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro
{
    class ShapeArea
    {
        int shapeArea(int n)
        {
            if (n == 1)
                return 1;
            int result = 0;
            result = (n * n) + (n - 1) * (n - 1);
            return result;
        }
    }
}

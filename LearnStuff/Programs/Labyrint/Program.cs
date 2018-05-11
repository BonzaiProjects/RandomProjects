using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            LabyrinthCreater.Class1 c = new LabyrinthCreater.Class1();
            c.CreateLabyrinth(5, 10);
        }
    }
}

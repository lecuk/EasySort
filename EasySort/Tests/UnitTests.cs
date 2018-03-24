using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using EasySort.Classes;

namespace EasySort.Tests
{
    static class UnitTests
    {
        public static void TestHSV()
        {
            for (int i = 0; i < 36; i++)
            {
                Console.WriteLine(DrawingStyler.ColorFromHSV(i * 10, 100, 100).ToString());
            }
        }
    }
}

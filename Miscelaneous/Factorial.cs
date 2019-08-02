using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace MS_01.Miscelaneous
{
    public static class Factorial
    {
        static void DemoMain()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            BigInteger factorial = 1;
            for (int x = 0; x < n; x++)
            {
                factorial *= n - x;
            }
            Console.WriteLine(factorial);
        }
    }
}

using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    class Fun {}

    public class Program
    {
        public static void d(int value=1)
        {
            System.Console.WriteLine(value);
        }
        public static void Main(string[] args)
        {
            char c = '0';
            float f = 1;
            double d = f;

            return;
                int x = Convert.ToInt32(Console.ReadLine());

                int result = 0;
                for (int i = 1; i < int.MaxValue; i++)
                {
                    result = Convert.ToInt32( Convert.ToString(i, 2) );
                    if (result % x == 0) break;  
                }

                Console.WriteLine(result);
        }
    }
}

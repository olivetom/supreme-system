using System;
namespace MS_01
{
    public class PassByValue
    {
        public PassByValue()
        {
        }

        public static void Increment(int var)
        {
            var++;
        }

        public static void PassByValueMain()
        {
            int i = 10;
            Console.WriteLine("Value of i before increment is :  " + i);
            Increment(i);
            Console.WriteLine("Value of i after increment is :  " + i);
        }
    }
}

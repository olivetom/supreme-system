using System;
namespace MS_01
{
    public class PassByReference
    {
        public int value;

        public PassByReference()
        {
        }

        public static void Increment(PassByReference value)
        {
            (value.value)++;
        }

        public static void IncrementArray(int[] arreglo)
        {
            for (var i = 0; i < arreglo.Length;i++)
            {
                arreglo[i]++;
            }
        }

        public static void PassByReferenceMain()
        {
            PassByReference x = new PassByReference();
            x.value = 10;
            Console.WriteLine("Value of i before increment is :  " + x.value);
            Increment(x);
            Increment(x);
            Console.WriteLine("Value of i after increment is :  " + x.value);

            //array is a reference type
            int[] arreglo = { 1, 4 };

            foreach (var e in arreglo)
                System.Console.WriteLine(e);

            IncrementArray(arreglo);

            foreach (var e in arreglo)
                System.Console.WriteLine(e);

        }
    }

}

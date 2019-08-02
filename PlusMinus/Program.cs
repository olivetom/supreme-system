using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //int n = Convert.ToInt32(Console.ReadLine());
            //string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = { 1, -1, 0};
            /*for (int i = 0; i < arr_temp.Length; i++)
            {
                arr[i] = Int32.Parse(arr_temp[i]);
            }*/
            decimal positivos, negativos, zeros;
            positivos = negativos = zeros = 0;
            foreach (var number in arr) 
            {
                if (number > 0) positivos++;
                else if (number < 0) negativos++;
                else zeros++;
            }
            int l = arr.Length;
            System.Console.WriteLine("{0:F5}",positivos/l);
            System.Console.WriteLine("{0:F5}",negativos/l);
            System.Console.WriteLine("{0:F5}",zeros/l);
        }
    }
}
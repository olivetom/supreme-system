using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = 8;
            for (int i=0; i < n; i++)
            {
                for (int j=0; j < n-i-1; j++)
                {
                    System.Console.Write(" ");

                }
                for (int stair=0; stair < i+1; stair++)
                    System.Console.Write("#");
                System.Console.WriteLine();
            }
        }
    }
}

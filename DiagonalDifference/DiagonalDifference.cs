using System;

namespace DiagonalDifference  
{
    class Program 
    {
        public static void Main(string[] args)
        {
           int[][] matrix = new int[3][]
           { 
               new int[] {11,2,4}, 
               new int[] {4,5,6},
               new int[]  {10,8,-12} 
           };

           //int[,] matrix = new int[3,3] { {11,2,4}, {4,5,6}, {10,8,-12} };

           /*foreach (int item in matrix)
           {
               Console.WriteLine(item);
           }*/
           int s = matrix.GetLength(0);
           int suma = 0;
           int sumb = 0;
           for (int i=0; i<s;i++)
           {
               suma += matrix[i][i];
               sumb += matrix[i][s-i-1];
               //suma += matrix[i,i];
               //sumb += matrix[i,s-i-1];

           }
           System.Console.WriteLine(Math.Abs(suma-sumb)); 
        }

    }
}
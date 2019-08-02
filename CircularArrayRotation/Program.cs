using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            /*IEnumerable<int> n = Enumerable.Range(1, 100000);
            IEnumerable<int> a = Enumerable.Range(1, 100000);
            IEnumerable<int> k = Enumerable.Range(1, 100000);
            IEnumerable<int> q = Enumerable.Range(0, 500);*/
            int n,a,k,q;
            string[] nakq = Console.ReadLine().Split(' ');
            n = Int32.Parse(nakq[0]);
            n = ((n > 100000) || (n < 1)) ? 1 : 1;
            System.Console.WriteLine(n);
        }
    }
}

using System;
namespace LeetCode
{
    public static class Recursion
    {
        public static int Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("Parameter must be >= 0");
            if (n == 0) return 1;
            else return n * Factorial(n - 1);
        }

        public static int FactorialIterative(int n)
        {
			if (n < 0) throw new ArgumentException("Parameter must be >= 0");
            int result = n;
            for (int i = n - 1; i > 0; i--)
            {
                result *= i;
            }
            return result;
		}

        public static int Fibonacci(int n)
        {
			/*
             * fibn = fibn-1 + fibn-2 for n > 2
			fib2 = 1
			fib1 = 1 */

			if (n < 1) throw new ArgumentException("Parameter must be >= 0");

            if (n == 1 || n == 2) 
                return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);

		}

        public static int FibonacciIterative(int n)
        {
            /*
             * fibn = fibn-1 + fibn-2 for n > 2
            fib2 = 1
            fib1 = 1 */

            if (n < 1) throw new ArgumentException("Parameter must be >= 0");

            int result = 1;

            for (int i = n; i > 2; i--)
            {
                result += n - 1 + n - 2;
            }
            return result;
        }


		public static void Program()
		{
			Console.WriteLine("Factorial recursivo: " + Factorial(10));
			Console.WriteLine("Factorial iterativo: " + FactorialIterative(10));
            Console.WriteLine("Fibonacci recursivo: " + Fibonacci(20));
			Console.WriteLine("Fibonacci iterativo: " + Fibonacci(20));
		}
    }

   
}

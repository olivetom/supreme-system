using System;

namespace W1_01_Karatsuba_Multiplication
{
    //multiply numbers with 2^n digits by using Karatsuba MEthod and Gauss Trick to perform O(n log n)

    public readonly struct KaratsubaNumber
    {
        private readonly long Value,HighValue, LowValue;
        public readonly long NumberOfDigits;

        public KaratsubaNumber(long number)
        {
            long numberOfDigits = (long)Math.Log10(Math.Abs(number)) + 1;
            long half = (long)Math.Floor((decimal)numberOfDigits / 2);
            long divisor = (long)Math.Pow(10, half);

            Value = number;
            NumberOfDigits = numberOfDigits;

            if (numberOfDigits >= 2)
            {
                HighValue = (long)number / divisor;// discard decimal part of number;
                LowValue = number % divisor;
            } else
            {
                HighValue = 0;
                LowValue = Value;
            }
        }


        public static bool TryParse(long number, out KaratsubaNumber kn)
        {
            kn = new KaratsubaNumber(number);
            return kn.NumberOfDigits > 1;
        }

        public static (long, long) SplitAtHalf(long number)
        {
            var kn = new KaratsubaNumber(number);
            return (kn.HighValue, kn.LowValue);
        }

        public static long operator *(KaratsubaNumber operand1, KaratsubaNumber operand2)
        {
            return Multiplication(operand1.Value, operand2.Value);
        }

        private static long Multiplication(long operand1, long operand2)
        {
            if (operand1 < 10 || operand2 < 10)
                return operand1 * operand2;

            long numberOfDigits1 = (long)Math.Log10(operand1) + 1;
            long numberOfDigits2 = (long)Math.Log10(operand2) + 1;
            var minDigits = Math.Min(numberOfDigits1, numberOfDigits2);
            long half = (long)Math.Floor((decimal)minDigits / 2);
            var (a, b) = SplitAtHalf(operand1);
            var (c, d) = SplitAtHalf(operand2);

            // 10^n ac + 10^(n / 2) (ad + bc) + bd
            // (implies four distinct products without Gauss trick)

            // Apply Gauss trick reduce from 4 products to 3:
            // to calculate (ad+bc) = (a+b)(c+d) = ac + ad + bc + bd

            var ac = Multiplication(a, c);
            var bd = Multiplication(b, d);
            var abcd = Multiplication(a + b, c + d);
            var adbc = abcd - ac - bd;
            var result = (long) (Math.Pow(10, half * 2) * ac + Math.Pow(10, half) * adbc + bd);
            return result;
        }

        public static bool operator true(KaratsubaNumber kn) => kn.NumberOfDigits > 1;
        public static bool operator false(KaratsubaNumber kn) => kn.NumberOfDigits <= 1;
        public override string ToString() => Value.ToString();
        
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine(typeof(Program).Namespace);
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}",
            Environment.ProcessorCount);
            Console.WriteLine(".NET Version: {0}", Environment.Version);
            Console.WriteLine("C# Version: {0}", "who knows");
            Console.WriteLine("Exit with Control-C");

           
            long operand1, operand2;

            do
            {
                Console.Write("Enter integer operand1: ");
                while (!long.TryParse(Console.ReadLine(), out operand1))
                {
                    Console.Write("Error. Enter integer only (operand#1): ");
                }

                Console.Write("Enter integer operand2: ");
                while (!long.TryParse(Console.ReadLine(), out operand2))
                {
                    Console.Write("Error. Enter integer only (operand#1): ");
                }
                if (KaratsubaNumber.TryParse(operand1, out var kn1)
                    && KaratsubaNumber.TryParse(operand2, out var kn2)
                    && kn1.NumberOfDigits == kn2.NumberOfDigits)
                    Console.WriteLine("{0} times {1} = {2}",
                        operand1,
                        operand2,
                        kn1 * kn2);
                else Console.WriteLine("Operands must have same number of digits and be >= 10.");
            } while (Console.ReadKey().KeyChar != 0x03); //Control+C
        }
    }
}

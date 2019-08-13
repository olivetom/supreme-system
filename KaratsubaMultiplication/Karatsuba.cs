using System;
namespace KaratsubaMultiplication
{
    public class Karatsuba
    {
        public static Int64 Multiplication(Int64 op1, Int64 op2)
        {
            if (op1 < 10 || op2 < 10) return op1*op2;
           
            Int64 n1 = NumberOfDigits(op1);
            Int64 n2= NumberOfDigits(op2);
            Int64 hn = Math.Min(n1,n2)/2;

            Int64 a = Math.DivRem(op1, (Int64)Math.Pow(10, hn), out var b);
            Int64 c = Math.DivRem(op2, (Int64)Math.Pow(10, hn), out var d);

            System.Console.WriteLine("op1:{0} \n op2:{1}", op1, op2);
            System.Console.WriteLine("a:{0} \n b:{1}", a, b);
            System.Console.WriteLine("c:{0} \n d:{1}", c, d);
            System.Console.WriteLine("digits1 ={0}", n1);
            System.Console.WriteLine("digits2 ={0}", n2);
            System.Console.WriteLine("iMin={0}", Math.Min(n1,n2));
            System.Console.WriteLine("Half={0}", hn);
            System.Console.WriteLine();
            // Karatsuba: result = 10^n * a*c + 10^(n/2) * (a*d+b*c) + b*d
            // Gauss Trick: a*d + b*c = (a+b)*(c+d)-a*c-b*d

            Int64 ac = Multiplication(a, c); 
            Int64 bd = Multiplication(b, d);
            Int64 adbc = Multiplication(a+b, c+d) - ac - bd;

            return 
                (Int64)Math.Pow(10, hn*2) * ac 
                + (Int64)Math.Pow(10, hn) * adbc
                + bd;
        }

        static Int64 NumberOfDigits(Int64 operand) 
            => (Int64) (System.Math.Log10((double)operand) + 1);
    }
    
}

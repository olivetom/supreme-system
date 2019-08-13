using System;
using System.Threading.Tasks;

namespace KaratsubaMultiplication
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Karatsuba Multiplication");
            Console.WriteLine("Enter first integer operand:");
            Int64.TryParse(Console.ReadLine(), out var op1);

            Console.WriteLine("Enter second integer operand:");
            Int64.TryParse(Console.ReadLine(), out var op2);


            await Task.Run(() =>  
                {
                    Console.WriteLine("{0} * {1} = {2}", op1, op2, Karatsuba.Multiplication(op1, op2));
                    Console.WriteLine("{0} * {1} = {2}", op1, op2, op1*op2);
                });
            //return await Task.Run(() =>  
            //    Console.WriteLine("{0} * {1} = {2}", op1, op2, Karatsuba(op1, op2)));
        }
    }
}

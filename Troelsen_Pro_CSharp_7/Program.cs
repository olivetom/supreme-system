using System;

namespace W_00_Troelsen_Pro_CSharp_7
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello World!");
            ObjectFunctionality();
            DataTypeFunctionality();
            CharFunctionality();
            ParseFromStringsWithTryParse();
            ConditionalRefExpression();
            BinaryLiterals();
        }

        #region ObjectFunctionality
        static void ObjectFunctionality()
        {
            Console.WriteLine("=> System.Object Functionality:");
            // A C# int is really a shorthand for System.Int32,
            // which inherits the following members from System.Object.
            Console.WriteLine("12.GetHashCode() = {0}", 12.GetHashCode());
            Console.WriteLine("12.Equals(23) = {0}", 12.Equals(23));
            Console.WriteLine("12.ToString() = {0}", 12.ToString());
            Console.WriteLine("12.GetType() = {0}", 12.GetType());
            Console.WriteLine();
        }
        #endregion

        #region DataTypeFunctionality
        static void DataTypeFunctionality()
        {
            Console.WriteLine("=> Data type Functionality:");
            Console.WriteLine("Max of int: {0}", int.MaxValue);
            Console.WriteLine("Min of int: {0}", int.MinValue);
            Console.WriteLine("Max of double: {0}", double.MaxValue);
            Console.WriteLine("Min of double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfinity: {0}", double.PositiveInfinity);
            Console.WriteLine("double.NegativeInfinity: {0}", double.NegativeInfinity);
            Console.WriteLine("bool.FalseString: {0}", bool.FalseString);
            Console.WriteLine("bool.TrueString: {0}", bool.TrueString);
            Console.WriteLine();
        }
        #endregion

        #region CharFunctionality
        static void CharFunctionality()
        {
            Console.WriteLine("=> char type Functionality:");
            char myChar = 'a';
            Console.WriteLine("char.IsDigit('a'): {0}", char.IsDigit(myChar));
            Console.WriteLine("char.IsLetter('a'): {0}", char.IsLetter(myChar));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 5): {0}",
            char.IsWhiteSpace("Hello There", 5));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 6): {0}",
            char.IsWhiteSpace("Hello There", 6));
            Console.WriteLine("char.IsPunctuation('?'): {0}",
            char.IsPunctuation('?'));
            Console.WriteLine();
        }
        #endregion

        static void ParseFromStringsWithTryParse()
        {
            Console.WriteLine("=> Data type parsing with TryParse:");


            if (bool.TryParse("True", out bool b))
            {
                Console.WriteLine("Value of b: {0}", b);
            }
            string value = "Hello";
            if (double.TryParse(value, out double d))
            {
                Console.WriteLine("Value of d: {0}", d);
            }
            else
            {
                Console.WriteLine("Failed to convert the input ({0}) to a double", value);
            }

            Console.WriteLine();
        }

        #region C# 7?   ConditionalRefExpression
        static void ConditionalRefExpression()
        {
            Console.WriteLine("==> Conditional Ref Expression");
            var smallArray = new int[] { 1, 2, 3, 4, 5 };
            var largeArray = new int[] { 10, 20, 30, 40, 50 };

            int index = 7;
            ref int refValue = ref ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]);
            refValue = 0;

            index = 2;
            ((index < 5) ? ref smallArray[index] : ref largeArray[index - 5]) = 100;

            Console.WriteLine(string.Join(" ", smallArray));
            Console.WriteLine(string.Join(" ", largeArray));
            // Output:
            // 1 2 100 4 5
            // 10 20 0 40 50
        }
        #endregion


        private static void BinaryLiterals()
        {
            Console.WriteLine("=> Use Binary Literals:");
            Console.WriteLine("Sixteen: {0}", 0b0001_0000);
            Console.WriteLine("Thirty Two: {0}", 0b0010_0000);
            Console.WriteLine("Sixty Four: {0}", 0b0100_0000);
        }

    }
}

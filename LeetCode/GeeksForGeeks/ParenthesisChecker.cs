using System;
using System.Collections;

namespace LeetCode.GeeksForGeeks
{
    public static class ParenthesisChecker
    {
        static Stack Parenthesis;

        public static Boolean CheckParenthesis(String s)
        {
            Parenthesis = new Stack();

            foreach (var item in s)
            {
                if (item == '(')
                {
                    Parenthesis.Push(item);
                }
                else if (item == ')')
                {
                    if (Parenthesis.Count > 0 && Parenthesis.Peek().ToString() == "(")
                        Parenthesis.Pop();
                    else return false;
                }
            }
            if (Parenthesis.Count == 0) return true;
            return false;
        }

        public static void Program()
        {
            //Test case #1
            Console.WriteLine(ParenthesisChecker.CheckParenthesis("((***)))"));

            //Test case #2
            Console.WriteLine(ParenthesisChecker.CheckParenthesis("(((**))"));

            //Test case #3
            Console.WriteLine(ParenthesisChecker.CheckParenthesis(")))"));

            //Test case #4
            Console.WriteLine(ParenthesisChecker.CheckParenthesis("((("));

            //Test case #5
            Console.WriteLine(ParenthesisChecker.CheckParenthesis("****((())***)"));


        }
    }
}
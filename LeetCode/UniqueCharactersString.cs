using System;
using System.Text;
using System.Collections;

namespace LeetCode
{
    public static class UniqueCharactersStringAlgorithm
    {
        
        public static Boolean AlgorithmVersion1(String s)
		{
            StringBuilder sbAux = new StringBuilder(s);
            foreach (Char c in s)
            { // duplico el string. Loopeo sobre el original removiendo y buscando cada elemento en el duplicado.
                int pos = sbAux.ToString().IndexOf(c); 
                if (pos >= 0) sbAux.Remove(pos,1);
                int oo = sbAux.ToString().IndexOf(c);
                    if ( oo >= 0) return false;
            }
            return true;
		}

        public static Boolean AlgorithmVersion2(String s)
        {
            int i = 0;
            foreach (char c in s)
            {
                if ((i > 0) && (s.Substring(0, i).Contains(s[i].ToString())))
                    return false;
                if ((i < s.Length) && (s.Substring(i + 1, s.Length - i - 1).Contains(s[i].ToString())))
                    return false;

                i += 1;
            }
            return true;
        }
    }

    public static class UniqueCharStringExtensions
    {
        public static int LengthWithoutSpaces(this string s)
        {
            string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int aux = 0;
            foreach (String ss in words)
            {
                aux += ss.Length;
            }
            return aux;
        }

        public static int WordCount(this string s)
        {

			string[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			
            return words.Length;
        }

        //imposible overload de operadores de sealed class
        //public static string operator +(this string s, string s2)
        //{
        //    return s + s2;
        //}
    }
}

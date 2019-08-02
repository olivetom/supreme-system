using System;
using System.Linq;
//Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
namespace LeetCode
{
    public static class LongestPalindromicSubstring
    {
        public static string DynamicProgrammingLongestPalindrome(String s)
        {
            int largo = s.Length;
            bool[,] p = new bool[largo,largo];
            // length == 1 substrings
            for (int i = 0; i < largo; i++)
                p[i,i] = true;

            //length == 2 substrings
            for (int i = 0; i < largo - 2; i++)
                if ((s[i] == s[i + 1])) p[i, i + 1] = true;


            //length > 2 substrings
            int right_index;//, auxPalindromeLength;
            int palindromeLength = 0, palindromeStart = 0;
            for (int plength = 3; plength <= largo; plength++)
            {
                for (int left_index= 0; left_index < largo - plength + 1; left_index++)
                {
                    right_index = left_index + plength - 1;
                    if ((s[left_index] == s[right_index]) && (p[left_index+1, right_index-1] == true)) 
                    {
                        palindromeStart = left_index;
                        palindromeLength = plength;
                        p[left_index, right_index] = true;
                    }
                    
                }
            }

            //for (int i = 0; i < largo; i++)
            //{
            //    for (int j = 0; j < largo; j++)
            //    {
            //        if (j > i) Console.WriteLine(String.Format("{0},{1}:{2}", i,j,p[i,j]));
            //    }
            //}
            return s.Substring(palindromeStart, palindromeLength);
                              //String.Format("{0},{1}", s[0], s[3]));
        }

        public static string ManachersAlgorithm(String s)
		//  ManachersAlgorithm
		{
            if ((s.Length > 1000) || (string.IsNullOrEmpty(s))) return "";

            char[] s2 = AddBoundaries(s.ToCharArray());
            int[] p = new int[s2.Length];
            int c = 0, r = 0; // Here the first element in s2 has been processed.
            int m = 0, n = 0; // The walking indices to compare if two elements are the same
            for (int i = 1; i < s2.Length; i++)
            {
                if (i > r)
                {
                    p[i] = 0; m = i - 1; n = i + 1;
                }
                else
                {
                    int i2 = c * 2 - i;
                    if (p[i2] < (r - i - 1))
                    {
                        p[i] = p[i2];
                        m = -1; // This signals bypassing the while loop below. 
                    }
                    else
                    {
                        p[i] = r - i;
                        n = r + 1; m = i * 2 - n;
                    }
                }
                while (m >= 0 && n < s2.Length && s2[m] == s2[n])
                {
                    p[i]++; m--; n++;
                }
                if ((i + p[i]) > r)
                {
                    c = i; r = i + p[i];
                }
            }
            int len = 0; c = 0;
            for (int i = 1; i < s2.Length; i++)
            {
                if (len < p[i])
                {
                    len = p[i]; c = i;
                }
            }
            char[] ss = s2.Skip(c - len).Take(c + len + 1).ToArray();
            //char[] ss = Array.Copy()(s2, c - len, c + len + 1);
            return new String(RemoveBoundaries(ss));
        }

        private static char[] AddBoundaries(char[] cs)

        {
            if ((cs == null) || cs.Length == 0)
                return "||".ToCharArray();

            char[] cs2 = new char[cs.Length * 2 + 1];
            for (int i = 0; i < (cs2.Length - 1); i = i + 2)
            {
                cs2[i] = '|';
                cs2[i + 1] = cs[i / 2];
            }
            cs2[cs2.Length - 1] = '|';
            return cs2;
        }

        private static char[] RemoveBoundaries(char[] cs)
        {
            if (cs == null || cs.Length < 3)
                return "".ToCharArray();

            char[] cs2 = new char[(cs.Length - 1) / 2];
            for (int i = 0; i < cs2.Length; i++)
            {
                cs2[i] = cs[i * 2 + 1];
            }
            return cs2;
        }

		



	}


}



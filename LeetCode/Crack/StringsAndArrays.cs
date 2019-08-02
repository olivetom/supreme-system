using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Crack
{
    
    public static class StringsAndArrays
    {
        

        public static String ReplaceSpaces(String s)
      // Write a method to replace all spaces in a string with '%20'. 
     //   You may assume that the string has sufficient space at the end of the string to hold the additional characters,
      //  and that you are given the "true" length of the string. 
      //      Note: if implementing in Java, please usea character array so that you can perform this 
       // operation inplace.)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    sb.Append("%20");
                }
                else sb.Append(s[i]);
            }

            return sb.ToString();
        }

		/*Implement a method to perform basic string compression using the counts of repeated characters. 
		 * For example, the string a a b c c c c c a a a would become a2blc5a3. 
		 * If the "compressed" string would not become smaller than the original string, y
		 * our method should return the original string.

         */
        public static String Compress(String s)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];
                int count = 0;
                int j = i;
                for (; j < s.Length && s[j] == current; j++)
                {
                    count++;
                }
                sb.Append(current + count.ToString());
                i = j-1;
			}
            if (sb.Length < s.Length) return sb.ToString();
            return s;
        }

		/*
         * Given an image represented by an NxN matrix, where each pixel in the image is 4
            bytes, write a method to rotate the image by 90 degrees. Can you do this in place?
            */


		public static void Program()
		{
			Console.WriteLine(StringsAndArrays.ReplaceSpaces("mauricio dario raul oliveto suerteeeeee en amazon!!!"));
            Console.WriteLine(StringsAndArrays.Compress("maaaaaaaaaaaaaaaauriiiiiiiiiiiiiiiiiiiiiiiiiiiiicio darioooooooooooooooo      raul oliveto suerteeeeee en amazon!!!"));
			var a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 8 }.GroupBy(v => v)
			.OrderByDescending(g => g.Count())
			.First()
			.Key;
        }
    }


}

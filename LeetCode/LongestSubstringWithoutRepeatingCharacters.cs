using System;
namespace LeetCode
{
    public static class LongestSubstringWithoutRepeatingCharacters
    {
        public static int Solve(String s)
        {
			String aux = "";
			String longest = "";
            int i = 0;
			while (i < s.Length)
			{
				if (!aux.Contains(s[i].ToString()))
				{
					aux = aux.Insert(aux.Length, s[i].ToString());
				}
				else
				{ //letra repetida. ojo que la letra repetida debe comenza el nuevo substring
                    if (aux.Length > longest.Length)
                    {
                        longest = aux;

                    }
                    //posicion de la repetida
                    int posrep = aux.IndexOf(s[i]);
                    aux = aux.Substring(posrep + 1);
                    aux = aux.Insert(aux.Length, s[i].ToString());
				}
				i += 1;
			}

            if (longest.Length > aux.Length)
                return longest.Length;
            return aux.Length;
        }
    }
}

/*
 * Given a string, find the length of the longest substring without repeating characters.

Examples:

Given "abcabcbb", the answer is "abc", which the length is 3.

Given "bbbbb", the answer is "b", with the length of 1.

Given "pwwkew", the answer is "wke", with the length of 3. Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
*/


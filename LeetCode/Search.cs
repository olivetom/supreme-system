using System;
using System.Collections.Generic;

namespace LeetCode
{
    public static class Search
    {
        public static int IterativeBinarySearch(string a, char element)
        {
            int inicio = 0, fin = a.Length;
			while (inicio < fin)
			{
				int pos = (inicio + fin) / 2;
                if (element == a[pos]) return pos;
                if (element < a[pos])
                    fin = pos - 1;
                else
                    inicio = pos + 1;
			}
            return -1;
        }

        public static uint Mayoria(uint[] a)
        {
            Dictionary<uint, int> freq = new Dictionary<uint, int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (freq.ContainsKey(a[i]))
                    freq[a[i]]++;
                else freq.Add(a[i], 1);
            }
            int max = 0; uint key = 0;
            foreach (var keyValuePair in freq)
            {
                if (keyValuePair.Value > max)
                {
                    key = keyValuePair.Key;
                    max = keyValuePair.Value;
                }
            }
            if (max > (a.Length / 2)) return key;
            else return 0;
        }
		}
	}

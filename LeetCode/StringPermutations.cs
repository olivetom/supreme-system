using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class StringPermutations
    {

        public static List<String> Permutations(String s)
		{// Design an algorithm to print all permutations of a string. For simplicity, assume all characters are unique.
			List<String> perms = new List<String>();
            if (s.Length == 1)
			{
				perms.Add(s);
				return perms;
			}
			for (int i = 0; i < s.Length; i++)
			{
				char c = s[i];
                String remaining = s.Substring(0, i) + s.Substring(i + 1);
				List<String> subperms = Permutations(remaining);
				foreach (String sp in subperms)
					perms.Add(c + sp);
			}
			return perms;
		}


       
        public static Boolean IsPermutation(String o, String p)
        { // return true if p is permutation of o. otherwise return false.
            // this algorithm uses frequency of char to detect permutation

            if (o.Length != p.Length) return false;

			Dictionary<char,int> oFrequencyDict = new Dictionary<char, int>(o.Length);
			Dictionary<char,int> pFrequencyDict = new Dictionary<char, int>(o.Length);
            int oCharFreq, pCharFreq;
            Boolean identical = true;
            for (int i = 0; i < o.Length; i++)
            {
                identical &= o[i] == p[i];

                if (!oFrequencyDict.TryGetValue(o[i], out oCharFreq))
					oFrequencyDict.Add(o[i], 1);

                else oFrequencyDict.Add(o[i], ++oCharFreq);


                if (!pFrequencyDict.TryGetValue(p[i], out pCharFreq))
                    pFrequencyDict.Add(p[i], 1);
				else 
                 pFrequencyDict[p[i]] = ++pCharFreq;   

			}

            if (identical) return false;

            foreach (KeyValuePair<char,int> oKvp in oFrequencyDict)
            {
                if ((!pFrequencyDict.TryGetValue(oKvp.Key, out pCharFreq)) ||
                    (pCharFreq != oKvp.Value))
                    return false;
            }

            return true;

        }

    }
}

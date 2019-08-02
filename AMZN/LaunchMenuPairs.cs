using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AmazonExercise2
{

    class Program
    {
        // Return list of combinations as strings of format name + space + lunch option
        private static ArrayList Solve(string[][] lunchMenuPairs, string[][] cuisinePairs)
        {
            ArrayList list = new ArrayList();

            if (lunchMenuPairs == null) throw new ArgumentException("lunchMenuPairs should be not null");
            if (cuisinePairs == null) throw new ArgumentException("cuisinePairs should be not null");

            foreach (var cuisinePair in cuisinePairs)
            {
                if (cuisinePair == null || cuisinePair.Length < 2) continue;

                foreach (var lunchMenuPair in lunchMenuPairs)
                {
                    if (lunchMenuPair == null || lunchMenuPair.Length < 2) continue;

                    if ((cuisinePair[1].Equals("*") ||
                        cuisinePair[1].Equals(lunchMenuPair[1], StringComparison.CurrentCultureIgnoreCase)))
                    {
                        list.Add(String.Format("{0} {1}",
                            cuisinePair[0], lunchMenuPair[0]));
                    }
                }
            }

            // example output that works for default test to demonstrate the expected format
            //list.Add("ian lasagna");
            //list.Add("ian pizza");
            return list;
        }


        static void Main(string[] args)
        {


            //MOAlgorithm.ProgramStrings();
            //return;

            /* LINQ SOLUTION works if not repeating keys found */
            //Linq solution

            Dictionary<string, string> FoodCountryPairs = new Dictionary<string, string>();
            Dictionary<string, string> NameCountryPairs = new Dictionary<string, string>();

            int lunchMenuPairCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < lunchMenuPairCount; i++)
            {
                var aux = Console.ReadLine().Split(' ');
                FoodCountryPairs.Add(aux[0], aux[1]);
            }

            int cuisinePairCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < cuisinePairCount; i++)
            {
                var aux = Console.ReadLine().Split(' ');
                NameCountryPairs.Add(aux[0], aux[1]);
            }


            /*       var EnjoyableCombos = 
                       NameCountryPairs.Where(nameCountry => FoodCountryPairs.Where(
                           foodCountry => { foodCountry.Value equals nameCountry.Value; }));
                                                      // .ToDictionary(x => x.Key, x => x.Value + CuisineMenuPairs[x.Key]);
                   return;*/


            /* Another Solution *//*
			string[][] lunchMenuPairs;
			string[][] cuisinePairs;

			try 
            {
				int lunchMenuPairCount = Convert.ToInt32(Console.ReadLine());
				lunchMenuPairs = new string[lunchMenuPairCount][];
				for (int i = 0; i < lunchMenuPairCount; i++)
				{
					lunchMenuPairs[i] = Console.ReadLine().Split(' ');
				}

				int cuisinePairCount = Convert.ToInt32(Console.ReadLine());
				cuisinePairs = new string[cuisinePairCount][];
				for (int i = 0; i < cuisinePairCount; i++)
				{
					cuisinePairs[i] = Console.ReadLine().Split(' ');
				}
				


				ArrayList enjoyableCombos = Solve(lunchMenuPairs, cuisinePairs);
				enjoyableCombos.Sort();
				for (int i = 0; i < enjoyableCombos.Count; i++)
					Console.WriteLine(enjoyableCombos[i]);
            } catch (Exception)
            {
                Console.WriteLine("Bad input");
            }
			
*/


        }
    }
}

/*
 *
 3 
Pizza Italian
Curry Indian
Masala Indian

4  Jose Italian
John Indian Sarah Thai
Mary *
*/

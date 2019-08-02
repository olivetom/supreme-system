using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonExercise2
{/*Question 2
Edward is organizing a meeting and has to order lunch for everyone in the team. To make his task simpler he has prepared two lists. 
The first list has pairs of team members and their preferred cuisine types. 
Each team member either has a preference for a particular cuisine or does not have any particular preference and likes all cuisines. 
The second one contains a list of lunch options along with the cuisine type to which it belongs. 
Each lunch option belongs to only one cuisine type.

Write an algorithm that outputs a list of all possible pairs of team members along with lunch option they would enjoy. 
There can be no, one or more entries for a team member in the output list depending on how many lunch options satisfy their choice of cuisine(s). 

Input The input to the function/method consists of four arguments – lunchMenuPairs, representing a list containing pairs of lunch option and its 
associated cuisine type; 
teamCuisinePreference, representing a list containing pairs of team members and their cuisine preferences. 

Output Return a list representing all possible pairs of team members and lunch options they would enjoy.

Note If a team member does not have a particular preference and likes all cuisines, then the preference is specified as a "*" in the teamCuisinePreference list.  Order of rows in the returned list does not matter.
Example Input: 3  Pizza Italian  Curry Indian  Masala Indian 

4:  Jose Italian  John Indian Sarah Thai  Mary *

Output:  [[John, Curry],  [John,Masala],  [Jose, Pizza],  [Mary, Curry],  [Mary, Masala],  [Mary, Pizza]]
*/
    public static class MOAlgorithm
    {
        private static ArrayList Solve(string[][] FoodAndCountry, string[][] PersonAndCountry)
        {

            //IEnumerable<string[]> intersection = FoodAndCountry.Intersect(PersonAndCountry);

            ArrayList result = new ArrayList();

            for (int person = 0; person < PersonAndCountry.Length; person++)
            {
                if (PersonAndCountry[person][1] == "*")
                {
                    for (int i = 0; i < FoodAndCountry.Length; i++)
                    {
                        result.Add(PersonAndCountry[person][0] + "," + FoodAndCountry[i][0]);
                    }
                }
                else
                    for (int food = 0; food < FoodAndCountry.Length; food++)
                    {
                        if (PersonAndCountry[person][1] == FoodAndCountry[food][1])
                        {
                            result.Add(PersonAndCountry[person][0] + "," + FoodAndCountry[food][0]);
                        }
                    }
            }


            return result;
        }

        private static ArrayList SolveForEach(string[][] FoodAndCountry, string[][] PersonAndCountry)
        {

            //IEnumerable<string[]> intersection = FoodAndCountry.Intersect(PersonAndCountry);

            ArrayList result = new ArrayList();

            //for (int person = 0; person < PersonAndCountry.Length; person++)
            //{
            //    //string[] p = PersonAndCountry[person];
            //    if (PersonAndCountry[person][1] == "*")
            //    {
            //        for (int i = 0; i < FoodAndCountry.Length; i++)
            //        {
            //            result.Add(PersonAndCountry[person][0] + "," + FoodAndCountry[i][0]);
            //        }
            //    }
            //    else
            //    for (int food = 0; food < FoodAndCountry.Length; food++)
            //    {
            //        if (PersonAndCountry[person][1] == FoodAndCountry[food][1])
            //        {
            //            result.Add(PersonAndCountry[person][0] + "," + FoodAndCountry[food][0]);
            //        }
            //    }
            //}
            foreach (var personCountryPair in PersonAndCountry)
            {
                foreach (var foodCountryPair in FoodAndCountry)
                {
                    if (personCountryPair[1] == "*" || personCountryPair[1] == foodCountryPair[1])
                        result.Add(String.Format("{0},{1}", personCountryPair[0], foodCountryPair[0]));

                }

            }

            return result;
        }

        public static void ProgramStrings()
        {

            Console.WriteLine("Enter food-country pairs size:");
            Int16.TryParse(Console.ReadLine(), out var foodAndCountrySize);

            Console.WriteLine("Enter menu pairs food country pairs:");

            string[][] FoodAndCountry = new string[foodAndCountrySize][];

            for (int i = 0; i < foodAndCountrySize; i++)
            {
                FoodAndCountry[i] = Console.ReadLine().Split(' ');
            }

            Console.WriteLine("Enter person-country pairs size:");
            Int16.TryParse(Console.ReadLine(), out var personCountrySize);
            string[][] PersonAndCountry = new string[personCountrySize][];


            Console.WriteLine("Enter  person-country pairs:");
            for (int i = 0; i < personCountrySize; i++)
            {
                PersonAndCountry[i] = Console.ReadLine().Split(' ');
            }

            foreach (var combination in Solve(FoodAndCountry, PersonAndCountry))
            {

                Console.WriteLine(combination);

            }

        }

        public static void ProgramGenerics()
        {
            //cuisineType, FoodName
            Dictionary<string, List<string>> FoodAndCountry = new Dictionary<string, List<string>>();

            //person, cuisineType
            Dictionary<string, List<string>> PersonAndCountry = new Dictionary<string, List<string>>();

            //person, list of food
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();


            Console.WriteLine("Enter menu pairs size:");
            Int16.TryParse(Console.ReadLine(), out var menuPairsSize);

            Console.WriteLine("Enter menu pairs food country pairs:");
            for (int i = 0; i < menuPairsSize; i++)
            {
                string[] aux = Console.ReadLine().Split(' ');
                if (!FoodAndCountry.ContainsKey(aux[1]))
                    FoodAndCountry.Add(aux[1], new List<string>());
                FoodAndCountry[aux[1]].Add(aux[0]); //country -> list of food
            }


            Console.WriteLine("Enter team pairs size:");
            Int16.TryParse(Console.ReadLine(), out var teamPairsSize);

            Console.WriteLine("Enter menu pairs person cuisinetype pairs:");
            for (int i = 0; i < teamPairsSize; i++)
            {
                string[] aux = Console.ReadLine().Split(' ');
                if (!PersonAndCountry.ContainsKey(aux[0]))
                    PersonAndCountry.Add(aux[0], new List<string>());
                PersonAndCountry[aux[0]].Add(aux[1]); //person -> list of countries
            }


            Console.WriteLine("Result person food pairs:");

            foreach (var person in PersonAndCountry.Keys)
            {

                if (!result.ContainsKey(person))
                    result.Add(person, new List<string>());

                if (PersonAndCountry[person].Contains("*"))
                {
                    foreach (var cuisineType in FoodAndCountry.Keys)
                    {
                        result[person].AddRange(FoodAndCountry[cuisineType]);
                    }
                }
                else
                {
                    PersonAndCountry[person].ForEach(country =>
                    {
                        result[person].AddRange(FoodAndCountry[country]);
                    });
                }
            }

            foreach (var resultPair in result)
            {
                resultPair.Value.ForEach(food =>
                {
                    Console.WriteLine("{0},{1}", resultPair.Key, food);
                });
            }
        }
    }
}

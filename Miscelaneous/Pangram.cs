using System;
using System.Collections.Specialized;

namespace MS_01.Miscelaneous
{
    public static class Pangram
    {

        public static void DemoMain()
        {

            // Creates and initializes a BitVector32 with all bit flags set to FALSE.
            int[] pangram = new int[32];
            //pangram[0] = BitVector32.CreateMask();
            int i;
            //for ( i = 1; i < 32; i++)
            for (i = 0; i < 32; i++)
                {
                //pangram[i] = BitVector32.CreateMask(pangram[i - 1]);
                pangram[i] = (int)Math.Pow(2,i);// BitVector32.CreateMask(i);
                //Console.WriteLine(i + " " + Convert.ToString(pangram[i]));
            }

            BitVector32 v = new BitVector32();


            string Alphabet = "abcdefghijklmnopqrstuvwxyz";

            do
            {
                Console.WriteLine("Enter string: ");

                string input = Console.ReadLine().ToLower();

                foreach (char c in input)
                {
                    
                    if (Alphabet.IndexOf(c) != -1)
                        v[pangram[Alphabet.IndexOf(c)]] = true;
                }
                //Console.WriteLine("bitVector32:" + v.Data);
                if (v.Data == 67108863)
                    Console.WriteLine("Pangram");
                else Console.WriteLine("Not Pangram");
            } while (Console.ReadKey().KeyChar != 0x03);

        }
    }
}

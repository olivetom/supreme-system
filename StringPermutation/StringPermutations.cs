using System;
using System.Collections.Generic;
using System.Linq;

namespace Variables
{
    struct Time {
        private int hours, minutes, seconds;
        public Time(int hh, int mm, int ss)
        {
            this.hours = hh % 24;
            this.minutes = mm % 60;
            this.seconds = ss % 60;
        }
       public int Hours()
        {
            return this.hours;
        }
    }
    /*class WrappedInt {
            public int Number;
    }
    class Pass {
            public static void Value(int param) { 
                param = 42; 
            }
            public static void Reference(WrappedInt param)
            {
                param.Number = 42;
            }
            
    }*/

    class Program {
       /* public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Converter<TInput, TOutput> converter)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (converter == null)
            {
                throw new ArgumentNullException("converter");
            }

            TOutput[] localArray = new TOutput[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                localArray[i] = converter(array[i]);
            }

            return localArray;
        }*/
    static void doWork() {
        Time t;
    }
    /*static void doWork() {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = arr_temp.Select(Int32.Parse).ToArray();
        //int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        int[] arr = Program.ConvertAll<char,int>(arr_temp,Int32.Parse);
        int sum=0;
        for (int i = 0; i < n; i++) {
            sum += arr[i];
        }
        Console.WriteLine(sum);
    }*/

        /*static void doWork() {
            int i = 55;
            Console.WriteLine(i.ToString());
            Console.WriteLine(55.ToString());
            float f = 98.765F;
            Console.WriteLine(f.ToString());
            Console.WriteLine(98.765F.ToString());
        }*/
        /*enum Month : byte {
               January, February, March, April,
               May, June, July, August,
               September, October, November, December
        }

        static void doWork() {
            Month first = Month.January;
            Console.WriteLine(first); 
            first+=2; 
            Console.WriteLine(first);
        }*/
        /*static void doWork()
            {
                //int i = 0;
                //Console.WriteLine(i);
                //Pass.Value(i);
                //Console.WriteLine(i);
                WrappedInt wi = new WrappedInt();
                Console.WriteLine(wi.Number);
                Pass.Reference(wi);
                Console.WriteLine(wi.Number);
            }
        static void increment(ref int param)
        { param++; }*/
        static void Main(string[] args) {

            doWork();
            return;
            /*--------
            //int i = 44;
            object o = (int)i;
            System.Console.WriteLine("object={0}, int i={1}",o,i);
            o = (int)o+1;
            i+=1;
            System.Console.WriteLine("object={0}, int i={1}",o,i);
            //increment(ref i);
            // Deep copy vs shallow copy. Default shallow copy.
            return;*/
            //private actually means “private to the class” rather than “private to an object.”
            // However, don’t confuse private with static. If you simply declare a field as 
            // private, each instance of the class gets its own data. If a field is declared as
            // static, each instance of the class shares the same data.
            //---- camelCase private. PascalCase public.
            // -----float f = 1/0.0F;
            //System.Console.WriteLine(f);
            //System.Console.WriteLine(f*0);
            //-------
            //----
            // var myAnonymousObject = new { Name = "John", Age = 47 };
            //Console.WriteLine("Name: {0} Age: {1}", myAnonymousObject.Name, myAnonymousObject.Age);
            //-----


            return;
            String entrada = null;
            Console.WriteLine("Ingrese string a permutar:");
            entrada = Console.ReadLine();
            Program p = new Program();
            System.Console.WriteLine(p.permutaciones(entrada));
        }

        void swapChars(int pos1, int pos2, char[] s) {
            Char tc = s[pos2];
            s[pos2] = s[pos1];
            s[pos1] = tc;
        }

        int permutaciones(String s) {
            int cuenta = 0;
            if (s.Length <= 1) {
                return cuenta;   
            }
            if (s.Length == 2) 
            {
                //swapChars(0,1,result);
                return 2;
            }
            char[] modifiableString  = s.ToCharArray(); 

           for (int pos = s.Length-1; pos >= 0; pos--) {

                //System.Console.WriteLine("Permutaciones a izquierda letra:"+s[pos]);
                char[] si = s.ToCharArray();
                for (int d = pos; d > 0 ; d--) {
                    swapChars(d,d-1, si);
                    System.Console.WriteLine(si);
                    cuenta += 1;
                }

                //System.Console.WriteLine("Permutaciones a derecha letra:"+s[pos]);
                char[] sd = s.ToCharArray();
                for (int i = pos; i < s.Length-1; i++) {
                    swapChars(i,i+1, sd);
                    System.Console.WriteLine(sd);
                    cuenta += 1;
                }
                
                modifiableString = s.ToCharArray(); 
           }
           return cuenta;
        }

    }
}
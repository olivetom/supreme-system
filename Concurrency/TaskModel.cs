using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deadlock
{
    public class TaskModel
    {
        /*// Old procedural, blocking and single threaded way.
        // Cant' make 2 breakfast at the same time.
        // Sequence of 5 ordered steps.
        //_________________________________________________
        public TaskModel()
        {
            

            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");
            //Egg eggs = FryEggs(2);
            //Console.WriteLine("eggs are ready");
            //Bacon bacon = FryBacon(3);
            //Console.WriteLine("bacon is ready");
            //Toast toast = ToastBread(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toast is ready");
            //Juice oj = PourOJ();
            //Console.WriteLine("oj is ready");

            //Console.WriteLine("Breakfast is ready!");
        }*/

        /*// Procedural, but non-blocking and multi-threaded way.
        // CAN make 2+ breakfast at the same time.
        // Sequence of 5 steps, yet. Juice is always poured at the end.
        //_________________________________________________

        static async Task Main(string[] args)
        {
           

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            Egg eggs = await FryEggs(2);
            Console.WriteLine("eggs are ready");
            Bacon bacon = await FryBacon(3);
            Console.WriteLine("bacon is ready");
            Toast toast = await ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");

            Console.WriteLine("Breakfast is ready!");
        }*/


        /*// Procedural, but non-blocking and multi-threaded way.
        // CAN make 2+ breakfast at the same time.
        // Sequence of 5 steps, yet. Juice is always poured at the end.
        //_________________________________________________


        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var eggs = await eggsTask;
            Console.WriteLine("eggs are ready");
            var bacon = await baconTask;
            Console.WriteLine("bacon is ready");
            var toast = await toastTask;
            Console.WriteLine("toast is ready");
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");

            Console.WriteLine("Breakfast is ready!");

            async Task<Toast> MakeToastWithButterAndJamAsync(int number)
            {
                var toast = await ToastBreadAsync(number);
                ApplyButter(toast);
                ApplyJam(toast);
                return toast;
            }
        }*/


        public static async Task Main(string[] args)
        {
            Coffee cup = Coffee.PourCoffee();
            Console.WriteLine("coffee is ready");
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var allTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finished == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if (finished == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                allTasks.Remove(finished);
            }
            Console.WriteLine("Breakfast is ready!");

            async Task<Toast> MakeToastWithButterAndJamAsync(int number)
            {
                var toast = await ToastBreadAsync(number);
                ApplyButter(toast);
                ApplyJam(toast);
                return toast;
            }

            async Task<Toast> ToastBreadAsync(int howManySlices)
            {
                return await Task.Run(() => new Toast());
            }

            async Task<Egg> FryEggsAsync(int howManyEggs)
            {
                return await Task.Run(() => new Egg());
            }

            async Task<Bacon> FryBaconAsync(int howManyBacon)
            {
                return await Task.Run(() => new Bacon());
            }
            void ApplyButter(Toast toast)
            {
                Console.WriteLine("ApplyButter");
            }

            void ApplyJam(Toast toast)
            {
                System.Console.WriteLine("ApplyJam");

            }


        }

        internal struct Toast
        {
        }

        internal struct Coffee
        {
            public static Coffee PourCoffee()
            {
                return new Coffee();
            }
        }

        internal struct Egg
        {
        }
        
        internal struct Bacon
        {
        }
        

    }

    
}

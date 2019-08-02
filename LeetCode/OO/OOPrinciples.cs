using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;


namespace LeetCode.OO
{
      
    public class OOPrinciples
    {

        /*
         * INHERITANCE
         * ENCAPSULATION
         * POLIMORPHISM
         * 
        

			// SINGLETON PATTERN
			/* In this strategy, the instance is created the first time any member of the class is referenced. 
			 * The common language runtime takes care of the variable INITIALIZATION. 
			 * The class is marked SEALED to prevent derivation, which could add instances. 
			 * In addition, the variable is marked READONLY, which means that it can be assigned 
			 * only during static initialization (which is shown here) or in a class constructor. 
			 * Constructor is PRIVATE so it only can be called from this class.
        */

        public sealed class Singleton
        {
            private static readonly Singleton instance = new Singleton();

            private Singleton() { }

            public static Singleton Instance
            {
                get
                {
                    return instance;
                }
            }
        }


        // FACTORY PATTERN
        /* To decouple objects with creation relationship.
		 * */
        abstract class Factory
        {
            public abstract Product GetProduct();
        }

        abstract class Product
        {
            public abstract int Feature { get; }

        }

        class Client
        {
            void GetProduct()
            {
                var _myFactory = new ConcreteComputerFactory();
                var _myComputer = _myFactory.GetProduct();
                _myComputer.Feature.ToString();
            }
        }
                


        class ConcreteComputerProduct : Product
        {

            int _mhz = 500;

            public override int Feature
            {
                get { return _mhz; }
            }//Mhz

        }//ConcreteComputerProduct


        class ConcreteComputerFactory : Factory
        {

            public override Product GetProduct()
            {
                return new ConcreteComputerProduct();

            }//GetProduct

        }//ConcreteComputerFactory





        public static void Program()
        {
			Console.WriteLine("Pythagorean Triples");

            Enumerable.Range(2, 10)
           .Select(c => new
           {
               Length = 2 * c,
               Height = c * c - 1,
               Hypotenuse = c * c + 1
            }).ToList().ForEach(w => Console.WriteLine());


            Thread.CurrentThread.Name = "Main";


            // Create a task and supply a user delegate by using a lambda expression. 
            Task taskA = new Task(() => Console.WriteLine("Hello from taskA."));
            // Start the task.
            taskA.Start();

            // Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'.", Thread.CurrentThread.Name);
            //taskA.Wait();
        }

    // The example displays output like the following:
    //       Hello from thread 'Main'.
    //       Hello from taskA.

    }


	/* OBJECT RELATIONSHIPS
     * For two objects, Foo and Bar the relationships can be defined

		ASSOCIATION - I have a relationship with an object. Foo uses Bar

		public class Foo { 
		void Baz(Bar bar) {
		}  };

        AGGREGATION - I have an object which I've borrowed from someone else. When Foo dies, Bar may live on.

        public class Foo { 
        private Bar bar; 
        Foo(Bar bar) { 
           this.bar = bar; 


        COMPOSITION - I own an object and I am responsible for its lifetime, when Foo dies, so does Bar

		public class Foo {
		private Bar bar = new Bar();  }

       
		} } */


}
 
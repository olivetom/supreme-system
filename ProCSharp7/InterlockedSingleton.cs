using System;
using System.Threading;

namespace MS_01
{
    public class InterlockedSingleton
    {
        private static readonly Lazy<InterlockedSingleton> instance = new Lazy<InterlockedSingleton>(() => new InterlockedSingleton());

        private static int instanceCount;

        public static int InstanceCountGetter
        {
            get
            {
                return instanceCount;
            }
        }

        InterlockedSingleton()
        {
            _ = Interlocked.Increment(ref instanceCount);

        }

        ~InterlockedSingleton()
        {
            _ = Interlocked.Decrement(ref instanceCount);
        }

        public static InterlockedSingleton GetInstance => instance.Value;


    }

    public class InterlockedSingletonDemo
    {
        public static void InterlockedSingletonDemoMain()
        {
            InterlockedSingleton obj1 = InterlockedSingleton.GetInstance;
            InterlockedSingleton obj2 = InterlockedSingleton.GetInstance;
            InterlockedSingleton obj3 = InterlockedSingleton.GetInstance;
            Console.WriteLine(InterlockedSingleton.InstanceCountGetter);
        }
    }
}


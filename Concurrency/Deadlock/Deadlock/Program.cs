using System;
using System.Threading.Tasks;

namespace Deadlock
{
    class Program
    {
        static void Main()
        {
            // Start the delay.
            Task task = Deadlock();

            // Synchronously block, waiting for the async method to complete.
            task.Wait();

        }

        static async Task Deadlock()
        {
            
            // This await will capture the current context ...
            await Task.Delay(TimeSpan.FromSeconds(1));
            // ... and will attempt to resume the method here in that context.
        }
    }
}

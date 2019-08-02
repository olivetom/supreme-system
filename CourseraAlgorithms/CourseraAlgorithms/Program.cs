using System;
using System.Threading.Tasks;

namespace CourseraAlgorithms
{
    class Program
    {
//           public static void Main();
//public static int Main();
//public static void Main(string[] args);
//public static int Main(string[] args);
//public static Task Main();
//public static Task<int> Main();
//public static Task Main(string[] args);
//public static Task<int> Main(string[] args);
//        static void Main(string[] args)
public static async Task<int> Main(string[] args)
        {
            return await AsyncConsoleWork();
        }

    private static async Task<int> AsyncConsoleWork()
    {
        // Main body here
        Console.WriteLine("Hello World!");
        return 0;
    }
}
}

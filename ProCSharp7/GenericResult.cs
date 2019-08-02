using System;
namespace MS_01
{
    public class GenericResult<T>
    { 
        public bool Success { get; set; }
        public T Data { get; set; }
    }


    public class GenericResultMain
    {
        public static String GenericResultPrinter<T>(GenericResult<T> genericResult)
        {
            return genericResult.ToString();
        }

        public static void DemoMain()
        {
            GenericResult<int> IntegerGenericResult = new GenericResult<int> { Success = true, Data = 6 };
            Console.WriteLine(IntegerGenericResult.Data.ToString(), IntegerGenericResult.Success);

            GenericResult<string> StringGenericResult = new GenericResult<String> { Success = true, Data = "6" };
            Console.WriteLine(StringGenericResult.Data.ToString(), StringGenericResult.Success);

            GenericResultPrinter(IntegerGenericResult);
            GenericResultPrinter(StringGenericResult);

        }
    }
}

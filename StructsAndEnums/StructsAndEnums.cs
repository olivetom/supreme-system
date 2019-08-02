using System;

namespace StructsAndEnums
{

    enum Month
    { 
         January, February, March,April,May,June,July,August,September,October,November,December 
    }
    struct Date {
           private int year; //1900 = 0
           private Month month; // enero = 0
           private int day; //domingo = 0
            public Date(int ccyy, Month mm, int dd) 
            {
                this.year = ccyy - 1900;
                this.month = mm;
                this.day = dd - 1;
            }

            public override string ToString()
            {
                return (day++)+"/"+month.ToString()+'/'+(year+1900);
            }
    }

    class Program 
    {
        public static void Main(string[] args)
        {
            Date d;
            System.Console.WriteLine(new Date());
            System.Console.WriteLine(new Date(1996, Month.December, 4));
        }
    }
}
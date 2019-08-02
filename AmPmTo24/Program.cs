using System;
using System.Text;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            String ampm = "01:00:00AM";
            StringBuilder s24h = new StringBuilder();
            byte hh;
            switch (ampm[8])
            {
                case 'A':
                    Byte.TryParse(ampm.Substring(0,2), out hh);
                    if ((hh+12)%24 == 0) s24h.Append("00");
                    else {
                        s24h.Append(ampm[0]);
                        s24h.Append(ampm[1]);
                    }
                    break;
                case 'P':
                    Byte.TryParse(ampm.Substring(0,2), out hh);
                    if ((hh+12)%24 == 0) s24h.Append("12");
                    else s24h.Append((hh+12)%24);
                    break;
                default:
                    throw new Exception("Parsing error"); 
            }
            s24h.Append(ampm.Substring(2));
            s24h.Remove(s24h.Length-2,2);
            System.Console.WriteLine(ampm + "->" + s24h);
        }
    }
}

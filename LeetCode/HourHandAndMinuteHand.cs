using System;
using System.Text;

namespace LeetCode
{
    public static class HourHandAndMinuteHand
    {
        public static string HourHandAndMinuteHand180()
        {//what time is it when hour hand and clock hands are opossite?
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                { // h -> 1/2 grado x min. ******  minutero -> 6 grados x min   ***** segundero ---> 1 grado x 10 segs
                    for (int k = 0; k < 60; k += 10)
                    {
						int gradosManecillaHora = (int)(i * 30 + j * 0.5);
						int gradosMinutero = j * 6 + k/10;
                        int diferencia = Math.Abs(gradosMinutero - gradosManecillaHora);
                        bool aproxCientoOchenta = diferencia == 180; //diferencia > 179 && diferencia < 181;
						if (aproxCientoOchenta)
						{
                            result.AppendLine(String.Format("{0}:{1:D2}:{2:D2}", i, j, k));
						}
					}
                                       
                }

            }
            return result.ToString();
        }
    }
}

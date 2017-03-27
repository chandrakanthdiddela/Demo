using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    public static string convertTime(string pstrAMorPM, string[] ptimearr)
    {
        String lstrHour = Solution.ConvertHours(ptimearr[0], pstrAMorPM);
        String lstrMinutes = Solution.convertMinutes(ptimearr[1]);
        String lstrSeconds = Solution.convertMinutes(ptimearr[2].Substring(0, ptimearr[2].Length - 2));

        return lstrHour + ":" + lstrMinutes + ":" + lstrSeconds;
    }

    public static string convertMinutes(string pminutes)
    {

        if (Convert.ToInt16(pminutes) >= 0 && Convert.ToInt16(pminutes) <= 59)
        {
            return pminutes;
        }
        return "";
    }
    public static string ConvertHours(string phour, string pstrAMorPM)
    {
        if (Convert.ToInt16(phour) >= 01 && Convert.ToInt16(phour) <= 12)
        {
            if (pstrAMorPM == "AM" && Convert.ToInt16(phour) == 12)
            {
                return "00";

            }
            if (pstrAMorPM == "PM" && Convert.ToInt16(phour) == 12)
            {
                return "12";

            }
            if (pstrAMorPM == "AM")
            {

                return phour;


            }
            
            else if (pstrAMorPM == "PM")
            {
                string updatedHourvalue = Convert.ToString((Convert.ToInt16(phour) + 12));

                if (Convert.ToInt16(updatedHourvalue) >= 00 && Convert.ToInt16(updatedHourvalue) <= 23)
                {
                    return updatedHourvalue;
                }


            }

        }
        return "";

    }
    static void Main(String[] args)
    {
        string time = Console.ReadLine();
        string lstrAMorPM = time.Substring(time.Length - 2);
        //Console.WriteLine(lstrAMorPM);
        string[] timesplit = time.Split(':');
        String convertedTime = Solution.convertTime(lstrAMorPM, timesplit);
        Console.WriteLine(convertedTime);
        Console.ReadLine();
    }
}

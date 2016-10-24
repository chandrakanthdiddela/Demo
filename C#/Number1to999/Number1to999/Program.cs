using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Number1to999
{
    class Program
    {
        static void Main(string[] args)
        {
        
            string[] s = new string[]{"one","two","three","four","five","six","seven","eight","nine","ten","eleven","twelve","thirtten","fourteen","fifteen","sixteen","seventeen","ninetten"};
            string[] tens= new string[]{"ten","twenty","thirty","forty","fifty","sixty","seventy","eighty","ninety"};
            string s1 = "";
            Console.WriteLine("enter a no");
           string no= Console.ReadLine();
           int n = int.Parse(no);
           int i = 0;
           if (n > 99 && n < 1000)
           {
               i = n / 100;
               s1 = s[i - 1] +"hundered";
               n = n % 10;

           }
           if (n > 19 && n < 100)
           {
               i = n / 100;
               s1 = s1+tens[i - 1];
               n = n % 10;

           }
           if (n > 0 && n < 200)
           {
               s1 = s1 + s[n - 1];

           }
           Console.WriteLine(s1);
           Console.ReadLine();
                


        }
    }
}

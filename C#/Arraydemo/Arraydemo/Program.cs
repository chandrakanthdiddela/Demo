using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arraydemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[5];
            DateTime[] d = new DateTime[3];
            Console.WriteLine(d.Length);
            for (int i = 0; i < d.Length; i++)
            {
                Console.WriteLine(d[i]);

            }
           

            Console.WriteLine(x.Length);
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i]);

            }
            Console.ReadKey();

        }
    }
}

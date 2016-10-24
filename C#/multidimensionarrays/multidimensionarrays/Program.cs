using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace multidimensionarrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] d = new int[,]
            {
                {101,99,98,97},
                {102,87,76,12},
                {103,24,23,21}
            };
            Console.WriteLine("enter a no");
            string s=Console.ReadLine();
            int no = int.Parse(s);
            Console.WriteLine("total"+ d.Length);
            Console.WriteLine("rows"+d.GetLength(0));
            Console.WriteLine("cols"+ d.GetLength(1));
            Console.ReadLine();

             

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaggedArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            object[][] x = new object[3][];
            x[0] = new object[] { "sai", "12", "12.5" };
            x[1] = new object[] { "chandu", "23", "13.5" };
            x[2] = new object[] { "chintu", "25", "14.5" };
            Console.WriteLine(x.GetLength(0));
          //  Console.WriteLine(x.GetLength(1));
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x[i].Length; j++)
                {
                    s = s + x[i][j] +" ";
                 }
                s = s + "\n";
               
            }
            Console.WriteLine(s);
            Console.ReadKey();



        }
    }
}

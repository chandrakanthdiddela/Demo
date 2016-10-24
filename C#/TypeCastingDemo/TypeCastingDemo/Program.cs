using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeCastingDemo
{
    class Program
    {
        static void Main(string[] args)
        
        {
            int i = 25;
            byte sal =(byte) i;
            Console.WriteLine("salary is:" + sal);
            byte b = 20;
            float f = 4.5f;
            double d = 4.55555d;
            byte x = Convert.ToByte(f);
//char z = Convert.ToChar(d);
           // char y = Convert.ToChar(System.DateTime.Now);
            Console.ReadKey();

         }
    }
}

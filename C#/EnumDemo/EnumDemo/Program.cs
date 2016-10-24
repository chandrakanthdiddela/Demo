using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnumDemo
{
    class Program
    {
        enum GTB :int
        {
            sa=20,
            ja=30,
            ca
        }
        static void Main(string[] args)
        {
            int a = (int)GTB.sa;
            int b = (int)GTB.ja;
            int c = (int)GTB.ca;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.ReadLine();
        }
    }
}

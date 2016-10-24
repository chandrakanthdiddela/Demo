using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPsdemo
{
    class Program
    {

        class test
        {
            public int x, y;
            public void add(int a, int b)
            {
                x = a;
                y = b;
                int c = x + y;
                Console.WriteLine(c);
            }
        }
        static void Main(string[] args)
        {
            test t = new test();
            t.add(10, 20);
            test t1=t;
            t1.add(20, 30);
            Console.ReadKey();

        }
    }
}

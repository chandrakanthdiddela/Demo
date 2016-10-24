using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thisdemo
{
    class Program
    {
        int sal = 5000;
        public void print( int sal)
        {
            sal = sal + this.sal;
            Console.WriteLine("total" + sal);
           
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.print(3000);
            Console.ReadKey();
        }
        //Console.ReadKey();
    }
}

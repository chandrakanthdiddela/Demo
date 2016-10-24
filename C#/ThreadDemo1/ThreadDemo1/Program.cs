using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadDemo1
{
    class Threadtest
    {
        bool done;
        static void Main(string[] args)
        {
            //Thread t = new Thread(print);
            //t.Start();
            //for (int i = 0; i < 15; i++)
            //    Console.WriteLine("main method");

            Threadtest t = new Threadtest();
            new Thread(t.print).Start(); // create a thread passing a method and calling start method
           t. print(); // main thread

            Console.Read();
        }
       void print()
        {
            //for ( int i=0;i<15;i++)
            if (!done)
            {
                done = true;
                Console.WriteLine("print method");
            }
        }
    }
}

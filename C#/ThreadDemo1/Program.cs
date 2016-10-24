using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadDemo1
{
    class Program
    {
        // CLR calls Main using a Thread - Main Thread
        static void Main(string[] args)
        {
            // Q: What is Thread?
            // A: Thread is a unit of execution

            Thread t1 = new Thread( F1 );
            t1.IsBackground = true;
            t1.Start(); // start the secondary thread 1

            Thread t2 = new Thread( F2 );
            t2.IsBackground = true;
            t2.Start(); // start the secondary thread 2

            Thread.SpinWait(500000000);

            //while (true)
            //{
            //    Console.WriteLine("Main");
            //    Thread.SpinWait(50000000);
            //}
        }

        static void F1()
        {
            while (true)
            {
                Console.WriteLine("F1");
                Thread.SpinWait(50000000);
            }
        }

        static void F2()
        {
            while (true)
            {
                Console.WriteLine("F2");
                Thread.SpinWait(50000000);
            }
        }
    }
}




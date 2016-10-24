using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ReadLine();

                // ThreadPool is the thread manager which reuses the threads if there
                // are free threads in the pool otherwise creates new threads
                ThreadPool.QueueUserWorkItem(F1);
            }
        }

        static void F1(object o)
        {
            Thread.SpinWait(900000000);
            Console.WriteLine("F1 ended. " + Thread.CurrentThread.ManagedThreadId);
        }

        //static void F1(object o)
        //{
        //    while (true)
        //    {
        //        Console.WriteLine("F1");
        //        Thread.SpinWait(5000000);
        //    }
        //}
        
        //static void F2(object o)
        //{
        //    while (true)
        //    {
        //        Console.WriteLine("F2");
        //        Thread.SpinWait(5000000);
        //    }
        //}
    }
}






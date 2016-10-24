using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo3
{
    class Program
    {
        static CancellationTokenSource cts = new CancellationTokenSource();

        static void Main(string[] args)
        {
            Task t1 = new Task(F1, cts.Token);
            t1.Start();

//            Thread.SpinWait(50000000);
            while (true)
            {
                if (Console.ReadLine() == "c")
                    cts.Cancel();
            }
        }

        static void F1()
        {
            while (true)
            {
                if (cts.IsCancellationRequested) break;
                Thread.SpinWait(5000000);
                Console.WriteLine("F1");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StoreDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example 2
            Task<int> t1 = Task<int>.Factory.StartNew ( ()  => 1 );
            Console.WriteLine(t1.Result);

            // Return an array produced by a PLINQ query
            Task<string[]> task3 = Task<string[]>.Factory.StartNew(() =>
            {
                string path = @"C:\users\public\pictures\";
                string[] files = System.IO.Directory.GetFiles(path);

                var result = (from file in files.AsParallel()
                              let info = new System.IO.FileInfo(file)
                              where info.Extension == ".jpg"
                              select file).ToArray();

                return result;
            });

            foreach (var name in task3.Result)
                Console.WriteLine(name);
            // Example 1
            //CancellationTokenSource cts = new CancellationTokenSource();
            //Task.Factory.StartNew(() =>
            //    {
            //        while (true)
            //        {
            //            Console.WriteLine("New Task");
            //            if (cts.Token.IsCancellationRequested)
            //            {
            //                break;
            //            }
            //        }
            //    }, cts.Token);
            //while (true)
            //{
            //    Console.Write("Enter c to cancel: ");
            //    if (Console.ReadLine() == "c")
            //        cts.Cancel();
            //    Console.ReadLine();
            //}
        }
    }
}

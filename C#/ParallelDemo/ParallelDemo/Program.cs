using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ParallelDemo
{
    class Program
    {
        public int add(int[] arr)
        {
            return arr.Sum();
        }

        public int addparallel(int[] arr)
        {
            return arr.AsParallel().Sum();
        }

        static void Main(string[] args)
        {
            int[] array = Enumerable.Range(0, short.MaxValue).ToArray();

            Program p = new Program();
            Console.WriteLine(p.add(array));
            Console.WriteLine(p.addparallel(array));

            var stop1 = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                p.add(array);
            }

            stop1.Stop();
            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
               p. addparallel(array);
            }
            s2.Stop();
            Console.WriteLine(((double)(stop1.Elapsed.TotalMilliseconds * 1000000) /
                1000).ToString("0.00 ns"));
            Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) /
                1000).ToString("0.00 ns"));

            //
            // concat
            //
            int[] array1 = new int[] { 0, 1, 2, 3, 4 };
            string[] array2 = new string[] { "abc", "cde", "xyz" };
            var result = array1.Concat(array);
            foreach( var r in result)
                Console.WriteLine(r);
            Console.Read();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadiDemo4
{
    class Program
    {
        static int count;

        static object o = new object(); // any reference type object

        static void F1()
        {
            lock (o) // Monitor.Enter ( o ) 
            {
                count++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("F1: " + count);

                Thread.SpinWait(1000000);

                count++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("F1: " + count);
            } // Monitor.Exit(o)
        }

        static void F2()
        {
            lock (o)
            {
                count++;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("F2: " + count);

                Thread.SpinWait(1000000);

                count++;
                 Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("F2: " + count);
            }
        }

        class Stack
        {
            private int[] arr = new int[10];
            private int top = 0;
            public void Push(int item)
            {
                arr[top] = item;
                Thread.SpinWait(10000000);
                top++;
            }

            public int Pop()
            {
                return arr[--top];
            }
        }

        class StackConcurrent
        {
            private int[] arr = new int[10];
            private int top = 0;

            //private object lck = new object();
            public void Push(int item)
            {
                lock (arr)
                {
                    arr[top] = item;
                    Thread.SpinWait(10000000);
                    top++;
                }
            }
            
            public int Pop()
            {
                lock (arr)
                {
                    return arr[--top];
                }
            }
        }

        static void Main(string[] args)
        {
            Stack s = new Stack();

            Task t1 = Task.Factory.StartNew( () =>
                {
                    s.Push(10);
                });

            Task t2 = Task.Factory.StartNew( () =>
                {
                    s.Push(20);
                });

            t1.Wait();
            t2.Wait();

            Console.WriteLine(s.Pop());
        }
    }
}

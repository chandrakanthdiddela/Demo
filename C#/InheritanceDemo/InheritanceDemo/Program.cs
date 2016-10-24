using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceDemo
{

    class A
    {
        private int a ;
        protected double y;
        public double z;
        public void Print(int x)
        {
            a = x;
            Console.WriteLine("value is"+a);
        }
        public int get()
        {
            Console.WriteLine(a);
            return a;
        }
    }
    class B : A
    {
        public int get1()
        { 
            int x;
            Console.WriteLine(x = get());
            return x;
        }

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            A aobj = new A();
            aobj.Print(5);
            B boj = new B();
           // boj = aobj;
            aobj.get();
            boj.get1();
            
            
            

        }
    }
}

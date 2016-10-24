using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datatypesdemo
{
    class Program
    {
        int lstructint= 10;
        uint lustructint = 20;
        short lshort = 30;
        byte lbyte = 40;
        float lfloat = 4.5f;
       //decimal ldecimal = 4.99999999999;
        double ldouble = 4.44442d;
        bool b = true;
        bool? b1 = null;
        string s = "chandrakanth";
        char c = 'c';
      
        static void Main(string[] args)
        {
            Console.WriteLine("hello C## world");

            Program p = new Program();

            Console.WriteLine(p.lstructint);
            Console.WriteLine(p.lustructint);
            Console.WriteLine(p.lshort);
            Console.WriteLine(p.lbyte);
            Console.WriteLine(p.s);
            Console.WriteLine(p.ldouble);
            Console.WriteLine(p.c);
            Console.WriteLine(p.b);
            p.b1 = false;
            Console.WriteLine(p.b1);


            int lint = 125;
            object obj = lint; //this is boxing. that is we can place any datatype in object type 
            object obj1 = 12;
            int lint1 = (int)obj1;
            Console.WriteLine(lint);
            Console.ReadLine();
            string s2 = lint.ToString();
            Console.WriteLine(s2);
            Convert.ToInt32(p.b);
        }
    }
}

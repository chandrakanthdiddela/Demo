using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo1
{

    class LivingBeing
    {
        public LivingBeing()
        {
            Console.WriteLine("Base constructor");
        }



        public  void printmessage1()
        {
            Console.WriteLine("base class print message");
        }

    }


    class human : LivingBeing
    {

        int humancount;
        public human()
        {
            Console.WriteLine("human constructor");
        }

        public void printmessage(object obj)
        {

            human h2 = (human)obj;
            h2.humancount = 10;
            
            Console.WriteLine("human being print message is called" + h2.humancount);
        }

    }

    class animal : LivingBeing
    {
        int animalcount;



        public animal()
        {
            Console.WriteLine("animal const");
        }

        public void printmessage(object obj)
        {


            Console.WriteLine("animal class print message is called");
        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            human h = new human();
            human h1 = new human();
            h.printmessage(h1);

            LivingBeing lobjlivingbase = h1;
             lobjlivingbase.printmessage1();
            

            Console.ReadKey();
        }
    }
}

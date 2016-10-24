using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionImp
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFile(@"c:\ReflectionEx.dll");
          /// Type t= asm.GetType();


            Console.WriteLine("FullName: " + asm.FullName + "\n");
        Console.WriteLine("Location(path): " + asm.Location + "\n");

            Type[] types = asm.GetTypes();

                foreach (Type t in types)

            {

            Console.WriteLine(" Type: " + t + "\n");

            MethodInfo[] lobjmethod = t.GetMethods();
            foreach ( var lobjmethod1 in lobjmethod)
            Console.WriteLine("lobjmethod" + lobjmethod1);
             MemberInfo[] lobjprop = t.GetMembers();
             FieldInfo[] lobjfield = t.GetFields();
             foreach (var lobmem in lobjfield)
                 Console.WriteLine("lmemberinfo" + lobjfield);

            }
   
            Console.ReadKey();
        }
    }
}

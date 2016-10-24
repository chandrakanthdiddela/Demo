using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReflectionDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the DLL path from the user
            Console.Write("Enter the DLL path: ");
            string dllPath = Console.ReadLine();

            // Load the DLL explicitly
            Assembly asm = Assembly.LoadFile(dllPath);

            // List all the classes available in the DLL
            Type[] types = asm.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine("{0}: {1}", (i+1), types[i].Name);
            }

            // Ask the user to select 1 class
            Console.Write("Select a type: ");
            int typeChoice = Convert.ToInt32(Console.ReadLine());

            // List all the methods of that class
            MethodInfo[] methods = types[typeChoice - 1].GetMethods();
            for (int i = 0; i < methods.Length; i++)
            {
                Console.WriteLine("{0}: {1}", (i+1), methods[i]);
            }

            // Ask the user to select a method
            Console.Write("Select a method: ");
            int methodChoice = Convert.ToInt32(Console.ReadLine());

            // start listing 1 parameter at a time with the type and 
            ParameterInfo[] parameters = methods[methodChoice - 1].GetParameters();
            object[] values = new object[parameters.Length];
            for (int i = 0; i < parameters.Length ; i++)
            {
                // get the value for the parameter from the user
                Console.Write("{0}: ", parameters[i]); 
                string value = Console.ReadLine();

                // converts a string to the actual type specified as the second parameter
                values[i] = Convert.ChangeType(value, parameters[i].ParameterType);
            }

            // Once all the values are collected, call the method
            object obj = Activator.CreateInstance(types[typeChoice - 1]);
            object result = methods[methodChoice - 1].Invoke(obj, values);

            // Display the result of the method
            Console.WriteLine(result);
        }
    }
}

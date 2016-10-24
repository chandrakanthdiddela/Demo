using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Linqbasic1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello linq world");

            Employee e = new Employee();

            e.pEmpid = 1828;
            e.pempname = "chandrakanth";
            e.pempdept = empdept.ppm;

            List<Employee> lemp = new List<Employee>();
            lemp.Add(e);

            foreach (Employee e1 in lemp)
            {
                Console.WriteLine(e1.pempname +" " +e1.pEmpid + " " +e1.pempdept);
            }


            
            
            Console.ReadLine();


            
        }
    }
}

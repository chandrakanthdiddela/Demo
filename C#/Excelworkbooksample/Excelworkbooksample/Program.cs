using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace Excelworkbooksample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> llstemp = new List<Employee>();
                llstemp.Add(new Employee { empnamep = "chandra", empdivsionp = "ppm", companynaemp = "intergraph" });

            llstemp.Add(new Employee { empnamep = "chandrakanth", empdivsionp = "ppm",  companynaemp = "intergraph1" }); 


        }
    }
}

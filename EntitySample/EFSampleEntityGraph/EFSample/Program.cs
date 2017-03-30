using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student newStudent = new Student() { StudentName = "Ganesh" };

              Console.WriteLine("*** DynamicProxyDemo Start ***");
              //QueryStudent.SearchStudentID(1);
              //QueryStudent.GetStudents();
              //QueryStudent.NestedQueryEx();
             // TestDBEntry.DBEntryTest();
             // ConnectedScenario.PreformCRUD();
             // DisconnectedScenario.DisconnectedAdd();
             // DisconnectedScenario.DisconnectedUpdate();
             // DisconnectedScenario.DisconnectedDelete();
              ConcurrencyEx.OptimisticConcurrencyDemo();
              Console.ReadKey();
        }
    }
}

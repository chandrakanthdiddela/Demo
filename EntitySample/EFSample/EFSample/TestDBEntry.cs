using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
{
    class TestDBEntry
    {

        public static void DBEntryTest()
        {
            using(var context= new SchoolDBEntities())
            {
                var student = context.Students.Find(1);

                student.StudentName = "Anil Kumble";
                var entry = context.Entry(student);

                Console.WriteLine("Entity Name: {0} ", entry.Entity.GetType().FullName );

                Console.WriteLine("Entity state {0}", entry.State);

                Console.WriteLine("********Property Values********");

                foreach (var propertyName in entry.CurrentValues.PropertyNames)
                {
                    Console.WriteLine("Property Name: {0}", propertyName);

                    //get original value
                    var orgVal = entry.OriginalValues[propertyName];
                    Console.WriteLine("     Original Value: {0}", orgVal);

                    //get current values
                    var curVal = entry.CurrentValues[propertyName];
                    Console.WriteLine("     Current Value: {0}", curVal);
                }
            }
        }
    }
}

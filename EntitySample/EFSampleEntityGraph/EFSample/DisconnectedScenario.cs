using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
{
    class DisconnectedScenario
    {

        public static void DisconnectedAdd()
        {
            Student disconnectedstudent = new Student() { StudentName = "New student" };
            disconnectedstudent.StudentAddress = new StudentAddress()
            {
                Address1 = "15",
                Address2 = "Ruden street",
                City = "West Haven",
                State = "CT"
            };

            using (var context = new SchoolDBEntities())
            {
                //var studentList = context.Students.ToList<Student>();
                context.Students.Add(disconnectedstudent);

                var studentEntry = context.Entry(disconnectedstudent);
                var addressentry = context.Entry(disconnectedstudent.StudentAddress);
                Console.WriteLine("Student Entity state {0}", studentEntry.State);
                Console.WriteLine("Student Address entity state {0}", addressentry.State);
                context.SaveChanges();


            }
        }

        public static void DisconnectedUpdate()
        {
            Student stud;
            // get the object from database

            using (var context = new SchoolDBEntities())
            {
                stud = context.Students.Where(s => s.StudentName == "SaiRam").FirstOrDefault<Student>();

                Console.WriteLine("student object is found for updating");
            }

            // check whether passed object exist or not
            if(stud!=null)
            {
                stud.StudentName = "Varnith";
                Console.WriteLine("student object is updated");
            }

            // create new context object and push the new object into the context and modifiy the data
            using(var context= new SchoolDBEntities())
            {
                context.Entry(stud).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                Console.WriteLine("changes have been saved to database");
            }
        }


        public static void DisconnectedDelete()
        {
            Student stud;
            // get the object from database

            using (var context = new SchoolDBEntities())
            {
                stud = context.Students.Where(s => s.StudentName == "Ganesh").FirstOrDefault<Student>();

                Console.WriteLine("student object is found for updating");
            }

         

            // create new context object and push the new object into the context and modifiy the data
            using (var context = new SchoolDBEntities())
            {
                context.Entry(stud).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                Console.WriteLine("Delete operation has been performed on the database");
            }
        }
    }
}

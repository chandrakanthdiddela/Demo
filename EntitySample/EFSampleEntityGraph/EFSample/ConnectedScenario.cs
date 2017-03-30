using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
{
    class ConnectedScenario
    {
        public static void PreformCRUD()
        {
            // insert and delete student doesn't work on in memory collection only update operation works..
            // always perform insert,delete on context object
            using(var context = new SchoolDBEntities())
            {
                
                var studentList=context.Students.ToList<Student>();
                context.Students.Add(new Student() { StudentName = "Bhanu", StandardId = 6 });

                Student lobjstudentUpdate = studentList.Where(s => s.StudentName == "Rahane").FirstOrDefault<Student>();
                lobjstudentUpdate.StudentName = "AjinkyaRahane";
                context.Students.Remove(studentList.ElementAt<Student>(0));
                context.SaveChanges();


            }
        }
    }
}

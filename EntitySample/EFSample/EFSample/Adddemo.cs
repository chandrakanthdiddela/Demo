using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
{
    class Adddemo
    {
        public static void AddSingleEntity()
        {
            Console.WriteLine("****Starting AddSingleEntity****");

            Student newStudent = new Student() { StudentName = "Virat Kohil" ,StandardId=9};
            using (var context = new SchoolDBEntities())
            {
                context.Students.Add(newStudent);
                context.SaveChanges();

                Console.WriteLine("New Student Entity has been added with new StudentId= " + newStudent.StudentID.ToString());
            }
            Console.WriteLine("****Finished AddSingleEntity****");

        }




    }
}

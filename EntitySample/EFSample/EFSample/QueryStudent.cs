using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
{
    class QueryStudent
    {

        public static Student SearchStudentID(int id)
        {
            using (var context = new SchoolDBEntities())
            {
                var lobjstudent = context.Students.Where(s => s.StudentID == id).FirstOrDefault(); 
                Console.WriteLine("Student ID " + lobjstudent.StudentID);
                Console.WriteLine("Student StandardID " + lobjstudent.StandardId);
                Console.WriteLine("Student name " + lobjstudent.StudentName);
                Console.WriteLine("end of the query");
                return lobjstudent;
            }


           
        }

        public static void GrpbyStudentStandardID()
        {
            using (var context = new SchoolDBEntities())
            {
             var lobjGrpstuden = from s in context.Students group s by s.StandardId into studentsByStandard select studentsByStandard;
            }
        }
       
        public static void OrderStudentByName()
        {
            using(var context = new SchoolDBEntities())
            {

                var lobjOrderstudent = from s in context.Students orderby s.StudentName ascending select s; 
            }
        }

        public static void GetStudents()
        {
            using (var context = new SchoolDBEntities())
            {

                var lobjOrderstudent = from s in context.Students
                                       where s.StudentName.Equals("Virat")
                                       select new
                                       {
                                           s.StudentName,
                                           s.StandardId,
                                           s.StudentID
                                       };
                                       
            }

        }

        public static void NestedQueryEx()
        {
            using (var context = new SchoolDBEntities())
            {

                var lobjOrderstudent = from s in context.Students
                                       from c in s.Courses
                                       where s.StandardId==6
                                       select new
                                       {
                                           s.StudentName,
                                           s.StandardId,
                                           s.StudentID
                                           ,c
                                       };
                var result = lobjOrderstudent.ToList();

            }
        }
}
    }


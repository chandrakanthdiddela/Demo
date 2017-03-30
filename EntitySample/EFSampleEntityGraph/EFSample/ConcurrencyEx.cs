using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
{
    class ConcurrencyEx
    {
        public static void OptimisticConcurrencyDemo()
        {
            Console.WriteLine("*** OptimisticConcurrencyDemo Start ***");
           
            Student student1WithUser1 = null;
            Student student1WithUser2 = null;

            //User 1 gets student
            using (var context = new SchoolDBEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;
                student1WithUser1 = context.Students.Where(s => s.StudentID == 2).Single();
                context.Database.Log = Console.Write;
            }
            //User 2 also get the same student
            using (var context = new SchoolDBEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;
                student1WithUser2 = context.Students.Where(s => s.StudentID == 2).Single();
            }
            //User 1 updates Student name
            student1WithUser1.StudentName = "Edited from user1";

            //User 2 updates Student name
            student1WithUser2.StudentName = "Edited from user2";

            //User 1 saves changes first
            using (var context = new SchoolDBEntities())
            {
                try
                {
                    context.Entry(student1WithUser1).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("Optimistic Concurrency exception occured");
                }
            }

            //User 2 saves changes after User 1. 
            //User 2 will get concurrency exection because CreateOrModifiedDate is different in the database 
            using (var context = new SchoolDBEntities())
            {
                try
                {
                    context.Entry(student1WithUser2).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("Optimistic Concurrency exception occured");
                }
            }
            Console.WriteLine("*** OptimisticConcurrencyDemo Finished ***");
        }
    }
}

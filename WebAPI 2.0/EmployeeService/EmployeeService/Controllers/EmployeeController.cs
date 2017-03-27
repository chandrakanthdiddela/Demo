using EmployeeDataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeService.Controllers
{
    public class EmployeeController : ApiController
    {
        // API controller is base class . API controller is found system.web.http namespace
       // [EnableCorsAttribute("*", "*", "*")]
        [BasicAuthentication]
        public HttpResponseMessage Get( string gender="All")
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            using(EmployeeDBEntities entities= new EmployeeDBEntities())
            {
                //return entities.Employees.ToList();
                switch (username.ToLower())
                {
                    case"all":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.ToList());
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e=>e.Gender=="male").ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e => e.Gender == "female").ToList());
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }


            }
        }

        public Employee Get(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Employees.FirstOrDefault(e=>e.ID==id);
            }
        }

        public HttpResponseMessage Post([FromBody] Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    entities.Employees.Add(employee);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
                    return message;
                }

            }

            catch(Exception exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception);

            }
           
        }


        public HttpResponseMessage Delete(int id)
        {
            try
            {


                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var entity = entities.Employees.Remove(entities.Employees.FirstOrDefault(e => e.ID == id));

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID= " + id.ToString());

                    }
                    else
                    {
                        entities.Employees.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);

                    }

                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }





        //public HttpResponseMessage Put(int id,[FromUri] Employee employee)
        //{
        //    try { 
        //    using(EmployeeDBEntities entities= new EmployeeDBEntities())
        //    {
        //        var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
        //        if(entity==null)
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID= " + id.ToString() + "not found to update");
        //        }
        //        else
        //        {
        //            entity.FirstName = employee.FirstName;
        //            entity.LastName = employee.LastName;
        //            entity.Salary = employee.Salary;
        //            entity.Gender = employee.Gender;
        //            entities.SaveChanges();
        //            return Request.CreateResponse(HttpStatusCode.OK, entity);

        //        }
               
        //    }
        //        }

        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }

        //}

        public HttpResponseMessage Put(int id, [FromBody] Employee employee)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID= " + id.ToString() + "not found to update");
                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Salary = employee.Salary;
                        entity.Gender = employee.Gender;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);

                    }

                }
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }



    }
}

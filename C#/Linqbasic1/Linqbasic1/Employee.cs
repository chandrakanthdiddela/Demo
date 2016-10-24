using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linqbasic1
{

  public  enum empdept 
    {
      ppm,
      sgi,
      wilcox,
      novtel

    }
    class Employee
    {

        private int empid;
        private string empname;
        private  empdept empdepartment;
        //public Employee(int pobjempid, string pobjname, string pobjdept)
        //{

        //}
        public int pEmpid
        {
            set
            {

                empid = value;
            }


            get
            {
                return empid;
            }
        }

        public string pempname
        {
            set
            {

                empname = value;
            }

            get
            {
                return empname;
            }
        }
        public empdept pempdept
        {
            set
            {

                empdepartment = value;
            }

            get
            {
                return empdepartment;
            }

        }
    }
}

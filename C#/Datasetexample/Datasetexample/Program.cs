using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Datasetexample
{
    class Program
    { 
        static void run()
        {
            for ( int i=0; i<100;i++)
                Console.WriteLine("run method");
        }
        static void Main(string[] args)
        {

            System.Threading.Thread t = new System.Threading.Thread(run);
            t.Start();
           // DataSet ds = new DataSet("office");
           // DataTable dt = new DataTable("employee");
           // dt.Columns.Add("empid");
           // dt.Columns.Add("ename");
           // dt.Columns.Add("teamname");
           // dt.Columns.Add("division");
           // string[] dtrow= {"1828","chandra","leo","ppm"}; 
           // dt.Rows.Add(dtrow);
           // ds.Tables.Add(dt);
           //string str= ds.GetXml();
           // Console.WriteLine(str);
            t.Join();
            Console.WriteLine("method thread termina");
            Console.ReadKey();
        }
    }
}

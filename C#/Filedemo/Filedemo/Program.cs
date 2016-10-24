using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Filedemo
{
    class Program
    {

        public void filecreate()
        {
            FileInfo lobjfileinfo = new FileInfo("c:\\abc.txt");
            DateTime ldate = lobjfileinfo.CreationTime;
            Console.WriteLine(lobjfileinfo.Name);
        }
        static void Main(string[] args)
        {
            Program lobjP = new Program();
            lobjP.filecreate();
            Console.ReadLine();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace filecopy
{
    class Program
    {

        static void Main(string[] args)
        {
            string path = Path.GetTempPath();
            StreamWriter sw;
            StreamReader sr;
            FileInfo f = new FileInfo(path);
            sw = f.CreateText();
            sw.Write("hello");
            sw.Write("file");
            sw.Write("world");
        }
    }
}

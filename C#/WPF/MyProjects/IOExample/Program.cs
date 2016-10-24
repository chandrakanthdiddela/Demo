using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOExample
{
    class Program
    {
        static void Main(string[] args)
        {
             string destinationpath = @"c:\sampletest\1.txt";
             string directorypath = @"C:\dell";
            string sourcepath = @"c:\temp\MyTest.txt";
            string[] arr={"abc","bcd","cde","def","efg"};
            TextFileexample lobjtext = new TextFileexample();
            lobjtext.textfilecreate(arr,sourcepath);
            lobjtext.createfolderandcopytext(directorypath, destinationpath);


            lobjtext.getalldirectories(directorypath);
        }
    }
}

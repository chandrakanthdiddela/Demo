using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using System.IO;

namespace IOExample
{
    class TextFileexample
    {
        List<string> lstr= new List<string>();

        public void createfolderandcopytext(string sourcepath,string destinationpath)
        {
           
            System.IO.DirectoryInfo lobjdir = Directory.CreateDirectory(destinationpath);

            string[] llistdirectory = Directory.GetDirectories(sourcepath);

            Console.ReadKey();
                //foreach( string lstr
       //  File.Copy(sourcepath, destinationpath);
        }
        public void textfilecreate(string[] lstrarr,string path)
        {
           
            try
            {
                StreamWriter lobjfilestream;

                if (!File.Exists(path))
                {
           lobjfilestream = File.CreateText(path);
                }
            TextWriter lobjtextwriter=null;
           
            StreamWriter lobjwriter= File.AppendText(path);
            if (lobjwriter != null)
            {
                foreach(string lstr in lstrarr)
                    lobjwriter.WriteLine(lstr);

                DateTime lobjdatetime = File.GetCreationTime(path);
                lobjwriter.WriteLine(lobjdatetime);

              FileAttributes lobjfileattr=  File.GetAttributes(path);
              lobjwriter.WriteLine(lobjfileattr);
              lobjwriter.Close();
            }

            Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void getalldirectories(string path)
        {
            lstr.Add(path);
            try
            {
                if (path.Length > 0)
                {
                    string[] lstrdirectory = Directory.GetDirectories(path);
                    foreach (string lstrdirecot in lstrdirectory)
                    {
                        getalldirectories(lstrdirecot);
                    }
                }



                else
                {
                    printlistofname(lstr);
                }
              
             
                
                
                
                // List<string> listofdirectory = new List<string>();
               //string[] lstrdirectory = Directory.GetDirectories(path);

               //foreach (string lstr in lstrdirectory)
               //{
               //    string[] lstrinnerdirectory = Directory.GetDirectories(lstr);
               //    foreach (string lstinner in lstrinnerdirectory)
               //    {
               //        Console.WriteLine(lstinner);
               //        listofdirectory.Add(lstinner);
               //    }
               //}
               //Console.ReadKey();
            }
            catch (Exception e)
            {
            }
             Console.ReadKey();
        }

        void printlistofname(List<string> lstr)
        {

            foreach( string lstr1 in lstr)
            Console.WriteLine(lstr1);
            Console.ReadKey();
        }
    }
}

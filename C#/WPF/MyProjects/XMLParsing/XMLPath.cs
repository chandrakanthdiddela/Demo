using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace XMLParsing
{
    class XMLPath
    {
        public void xmldoc(string path)
        {
            //XmlDocument xdoc1 = new XmlDocument();
            //xdoc1.Load(path);
            //xdoc1.SelectSingleNode("Container/SPOTAGEQUIPMENT/ITAGEQUIPMENT[@EQTYPE='0']").InnerText ;

          string[] listofdire = Directory.GetFiles(path);
       //   List<DateTime> lobjlist = new List<DateTime>();

          Dictionary<string, DateTime> dict = new Dictionary<string, DateTime>();
          foreach (string file in listofdire)
          {
              FileInfo fi = new FileInfo(file);
           //  DateTime lastacess= fi.LastAccessTime;
             // DateTime lastacess = fi.CreationTime;
              DateTime lastacess = fi.LastWriteTime;

              dict.Add(file, lastacess);


          }
        //  lobjlist.Sort();

          foreach ( KeyValuePair<string,DateTime> ket in dict)

            {
                Console.WriteLine(ket.Key + "" + ket.Value);
            }
        }
    }
}

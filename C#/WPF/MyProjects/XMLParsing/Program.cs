using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLParsing
{
    class Program
    {
        static void Main(string[] args)
        {
           // XDocument lobDocument = new XDocument();
          //  string lstrdocumentpath = @"C:/Users/sai/Desktop/SAMPLE.xml";

            string lstrdocumentpath = @" C:\Users\sai\Desktop\samplefiles";

            XMLPath xpath = new XMLPath();
            xpath.xmldoc(lstrdocumentpath);
      // // XDocument lobDocument =   XDocument.Load(lstrdocumentpath);
      // XElement lobDocument=XElement.Load(lstrdocumentpath);

      ////  IEnumerable<XElement> lobelement=  lobDocument.Element("Container").Elements();
      //  IEnumerable<XElement> lobelement = lobDocument.Elements();

      //  foreach (XElement xe in lobelement)
      //  {
      //      IEnumerable<XElement> lobsubelements = xe.Elements();
      //           foreach (XElement xse in lobsubelements)
      //           {

      //           IEnumerable <XAttribute> lobxattr=    xse.Attributes();

      //           foreach (XAttribute xa in lobxattr)
      //           {
      //               string value =xa.Value;
      //               Console.WriteLine(xa.Name +" " +value);
      //           }


      //               //IEnumerable<XElement> lobe = xse.Elements();
      //           }

      //  }

            Console.ReadLine();
        }
    }
}

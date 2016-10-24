using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using System.IO;

using System.Xml.Linq;
namespace XMLDEMO2
{
    class Program
    {
        static void Main(string[] args)
        {

            //string lstr =""
            //XElement lobjxelement = new XElement("contacts", new XElement("contact"), new XElement("name", new XAttribute("at", "intergraph"), "chandrakanth"),
            //    new XElement("phone", "9966"), new XElement("contact", new XElement("street", "lal"), new XElement("city", "hyderabad")));
            //Console.WriteLine(lobjxelement);
            //var name = lobjxelement.Element("name").Attribute("at").Value;
            //Console.WriteLine(name); d
            //Console.ReadLine();

          //  XDocument doc = XDocument.Load("C:\\Book1.xml");
          //IEnumerable<XElement>  ele=  doc.Elements();

            
          //  Console.WriteLine(doc);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<book ISBN='1-861001-57-5'>" +
                        "<title>Pride And Prejudice</title>" +
                        "<price>19.95</price>" +
                        "</book>");

            XmlNode root = doc.FirstChild;
        XmlElement el=    doc.GetElementById("price");

            Console.WriteLine("Display the title element...");
            Console.WriteLine(root.FirstChild.OuterXml);
            Console.WriteLine(root.LastChild.InnerText);


            Console.ReadLine();

     
        
         
          
          

           
        }
    }
}

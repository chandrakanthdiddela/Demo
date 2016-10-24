using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlWritersample
{
public class Sample
{

    public static void Main()
    {
        XmlDocument lobjDocument = new XmlDocument();

        lobjDocument.Load(@"D:\sample\new  2.xml");
        //lobjDocument.Loadxml("<Classdef>"+
        //    "<Iobject name =document uid=123></Iobject>" +
        //        "<Ischemaobj> container=tag></Ischemaobj>" +
        //       "</Classdef>");
        XmlNode lobjnode = lobjDocument.CreateNode("element","Ireldef","");
        lobjnode.InnerText="123";

        XmlElement lobjelement = lobjDocument.DocumentElement;
        lobjelement.AppendChild(lobjnode);
         Console.WriteLine("Display the modified XML document...");
         Console.WriteLine(lobjDocument.OuterXml);
        Console.Read();
    


        //XmlDocument doc = new XmlDocument();
        //doc.LoadXml("<book>" +
        //            "  <title>Oberon's Legacy</title>" +
        //            "  <price>5.95</price>" +
        //            "</book>");

        //// Create a new element node.
        //XmlNode newElem = doc.CreateNode("element", "pages", "");
        //newElem.InnerText = "290";

        //Console.WriteLine("Add the new element to the document...");
        //XmlElement root = doc.DocumentElement;
        //root.AppendChild(newElem);

        //Console.WriteLine("Display the modified XML document...");
        //Console.WriteLine(doc.OuterXml);
        //Console.Read();
    }
}
}

//namespace XmlWritersample
//{
////    class Employee
//    {
//        XmlDocument
//        int _empid;
//        string _empname;
//        string _empdeptname;
//        string _empdesignation;
//        public Employee(int pobjempid, string pobjempname, string pobjempdeptname,string pobjempdesgination)
//        {
//            _empname = pobjempname;
//            _empid = pobjempid;
//            _empdesignation = pobjempdesgination;
//            _empdeptname = pobjempdeptname;
//        }

//        public int empid
//        {
//            get
//            {
//                return _empid;
//            }
//        }

//        public string empname
//        {
//            get
//            {
//                return _empname;
//            }
//        }
//        public string empdeptname
//        {
//            get
//            {
//                return _empdeptname;
//            }
//        }
//        public string empdesignation
//        {
//            get
//            {
//                return _empdesignation;
//            }
//        }   
//    }
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            List<Employee> llstemp = new List<Employee>();
//            llstemp.Add(new Employee(1, "David Warner", "SRH", "opener"));
//            llstemp.Add(new Employee(2, "Finch", "SRH", "Middle"));
//            llstemp.Add(new Employee(3, "Ojha", "SRH", "wicketkeeper"));
//            llstemp.Add(new Employee(4, "Steyen", "SRH", "Bowler"));
//            XmlWriterSettings settings = new XmlWriterSettings();
//            settings.OmitXmlDeclaration = true;
//            StringWriter sw = new StringWriter();
//            using (System.Xml.XmlWriter lobjwriter = System.Xml.XmlWriter.Create(sw,settings))
//            {

//                lobjwriter.WriteStartDocument();
               
//                lobjwriter.WriteStartElement("Players");
//                    foreach( Employee lobjemp in llstemp)
//                    {
//                        lobjwriter.WriteStartElement("player");
//                        lobjwriter.WriteElementString("Id",lobjemp.empid.ToString());
//                        lobjwriter.WriteElementString("Empname",lobjemp.empname);
//                        lobjwriter.WriteElementString("Empdept",lobjemp.empdeptname);
//                        lobjwriter.WriteElementString("Empdesignation",lobjemp.empdesignation);
//                        lobjwriter.WriteEndElement();

//                    }
//                lobjwriter.WriteEndElement();
//                lobjwriter.WriteEndDocument();
//                lobjwriter.Flush();
//                string output = sw.ToString();

//                Console.WriteLine(output);
//                Console.Read();
//            }

//        }
//    }
//}

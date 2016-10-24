using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace SampleXmlDifference
{
    class helper
    {
        public void generatedeleteinstruction(IEnumerable<string> lstr)
        {
            XmlDocument lobjxmldoc = new XmlDocument();

            foreach (string lobjstr in lstr)
            {
                string lstrdelete ="Delete_"+lobjstr;
                XElement srctree = new XElement("DeleteInstruction", new XElement("IObject", new XAttribute("UID", lobjstr), new XAttribute("Name", "Delete_" + lobjstr)), new XElement("IRefObject", new XAttribute("RefClass", "Rel"), new XAttribute("RefUID", lobjstr), new XAttribute("RefName", lobjstr))
  
  ,new XElement("IDeleteInstruction", new XAttribute("DeleteTransition","Terminated")) );
                    Console.WriteLine(srctree);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string>  llst1 = new List<string>();
            List<string> llst2 = new List<string>();
            XmlDocument lobjFristxml1 = new XmlDocument();
            lobjFristxml1.Load(@"D:\SPO Adapter observations\Common-1.xml");

           XmlNodeList lobjxmlnodelist= lobjFristxml1.SelectNodes("//Container/Rel/IObject/@UID");

           foreach (XmlNode lobjnode in lobjxmlnodelist)
               llst1.Add(lobjnode.InnerText.ToString());
         
            XmlDocument lobjSecondxml2 = new XmlDocument();
            lobjSecondxml2.Load(@"D:\SPO Adapter observations\CommonRels-2.xml");
            XmlNodeList lobjxmlnodelist2 = lobjSecondxml2.SelectNodes("//Container/Rel/IObject/@UID");
            foreach (XmlNode lobjnode in lobjxmlnodelist2)
                llst2.Add(lobjnode.InnerText.ToString());
            IEnumerable<string> differenceQuery =
            llst1.Except(llst2);

            var abc = from xmlobj in lobjSecondxml2.GetElementsByTagName("Rel")

                      select (XmlNode) xmlobj.SelectNodes("//Container/Rel/IObject/@UID");
         
            // Execute the query.
            Console.WriteLine("The following lines are in names1.txt but not names2.txt");
            foreach (string s in differenceQuery)
                Console.WriteLine(s);

            helper lobjhelper = new helper();
            lobjhelper.generatedeleteinstruction(differenceQuery);
            

            Console.ReadKey();

        }
    }
}

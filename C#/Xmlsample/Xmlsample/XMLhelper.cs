using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Xmlsample
{
    class XMLhelper
    {
        public void Createxml()
        {
            XmlWriter lobjxmlWriter = XmlWriter.Create("D:\\Products.xml");
            lobjxmlWriter.WriteStartDocument(true);
            lobjxmlWriter.WriteStartElement("Container");
            createnode(lobjxmlWriter);

        }
        public void createnode(XmlWriter pobjxmlWriter)
        {
            pobjxmlWriter.WriteStartElement("classdef");
            pobjxmlWriter.WriteStartElement("Iobject");
            pobjxmlWriter.WriteString("name");
            pobjxmlWriter.WriteEndElement();
            pobjxmlWriter.WriteStartElement("Ischema");
            pobjxmlWriter.WriteString("uid");
            pobjxmlWriter.WriteEndElement();
            pobjxmlWriter.WriteEndElement();
           
          
        }


    }
}
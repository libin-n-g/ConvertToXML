using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConvertToXML
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length <= 0)
            {
                throw new ArgumentException("The File Name should be given as Argument");
            }
            if ( ! System.IO.File.Exists(args[0]))
            {
                throw new ArgumentException("The File does not Exists. Make sure you have given file exists! ");
            }
            ConvertToXML(args[0]);
        }
        static void ConvertToXML(string InputFileName = @"C:\Users\LIBIN-PC\Desktop\books.csv", string OutputFileName = "Test.xml")
        {
            var filelines = System.IO.File.ReadLines(InputFileName);
            using (XmlWriter writer = XmlWriter.Create(OutputFileName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("note");
                int i = 0;
                foreach (var line in filelines)
                {
                    writer.WriteStartElement("line");
                    writer.WriteAttributeString("seq", i.ToString());
                    writer.WriteString(line);
                    writer.WriteEndElement();
                    i++;
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }
        }
    }
}

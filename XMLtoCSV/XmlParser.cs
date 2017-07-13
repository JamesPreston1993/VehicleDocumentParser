using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XMLtoCSV.PropertyParsers;

namespace XMLtoCSV
{
    public class XmlParser
    {
        public IList<IPropertyParser> Parsers { get; set; }

        public XmlParser(string[] properties)
        {
            this.Parsers = new List<IPropertyParser>();

            foreach (var property in properties)
            {
                var parser = PropertyParserFactory.Create(property);
                if (parser != null)
                {
                    this.Parsers.Add(parser);
                }
            }
        }

        public string Parse(XDocument xDoc)
        {
            var data = string.Empty;

            foreach (var parser in this.Parsers)
            {
                data += parser.Get(xDoc) + ",";
            }

            return data.Substring(0, data.Length - 1);
        }
    }
}

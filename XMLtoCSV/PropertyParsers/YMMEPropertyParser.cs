using System.Linq;
using System.Xml.Linq;

namespace XMLtoCSV.PropertyParsers
{
    public class YMMEPropertyParser : IPropertyParser
    {
        private string elementName;

        public string Name { get; private set; }

        public YMMEPropertyParser(string element)
        {
            elementName = element;
            this.Name = element;
        }

        public string Get(XDocument doc)
        {
            var element = doc.Descendants(elementName).First();

            var attribute = element.Attribute("SHOP");

            return attribute != null ? attribute.Value : string.Empty;
        }
    }
}

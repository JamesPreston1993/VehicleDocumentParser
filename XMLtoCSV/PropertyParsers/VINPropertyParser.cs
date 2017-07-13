using System.Linq;
using System.Xml.Linq;

namespace XMLtoCSV.PropertyParsers
{
    public class VINPropertyParser : IPropertyParser
    {
        public string Name
        {
            get
            {
                return "VIN";
            }
        }

        public string Get(XDocument doc)
        {
            var element = doc.Descendants("Vehicle").First();

            var VIN = element.Attribute("VIN");

            return VIN != null ? VIN.Value : string.Empty;
        }
    }
}

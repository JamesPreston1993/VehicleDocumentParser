using System.Linq;
using System.Xml.Linq;

namespace XMLtoCSV.PropertyParsers
{
    public class BENPropertyParser :IPropertyParser
    {
        public string Name
        {
            get
            {
                return "BEN";
            }
        }

        public string Get(XDocument doc)
        {
            var BEN = string.Empty;

            var element = doc.Descendants("DataElement")
                                .Where(x => x.Attribute("AttributeName") != null
                                        && x.Attribute("AttributeName").Value == "BEN")
                                .FirstOrDefault();

            if (element != null)
            {
                var dataValue = element.Attribute("DataValue");
                if (dataValue != null)
                    BEN = dataValue.Value;
            }

            return BEN;
        }
    }
}

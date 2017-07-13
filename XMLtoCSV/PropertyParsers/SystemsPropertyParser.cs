using System.Linq;
using System.Xml.Linq;

namespace XMLtoCSV.PropertyParsers
{
    public class SystemsPropertyParser : IPropertyParser
    {
        public string Name
        {
            get
            {
                return "Systems";
            }
        }

        public string Get(XDocument doc)
        {
            var returnValue = string.Empty;

            var element = doc.Descendants()
                            .FirstOrDefault(x =>
                                x.Attribute("Name") != null
                                && x.Attribute("Name").Value == "COMPONENTDATA");

            if (element != null)
            {
                var systems = element.Descendants("DataItems")
                                .Where(x => x.Attribute("systemName") != null)
                                .Select(x => x.Attribute("systemName").Value);

                foreach (var system in systems)
                {
                    if (!string.IsNullOrEmpty(system))
                        returnValue += system + ",";
                }
            }

            return returnValue;
        }
    }
}

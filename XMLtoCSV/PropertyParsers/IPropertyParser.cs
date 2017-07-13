using System.Xml.Linq;

namespace XMLtoCSV.PropertyParsers
{
    public interface IPropertyParser
    {
        string Name { get; }

        string Get(XDocument doc);
    }
}

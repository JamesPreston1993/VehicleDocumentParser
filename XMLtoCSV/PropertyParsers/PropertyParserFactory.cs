namespace XMLtoCSV.PropertyParsers
{
    public class PropertyParserFactory
    {
        public static IPropertyParser Create(string type)
        {
            switch (type)
            {                
                case "Year":
                case "Make":
                case "Model":
                case "Engine":
                    return new YMMEPropertyParser(type);
                case "Systems":
                    return new SystemsPropertyParser();
                case "VIN":
                    return new VINPropertyParser();
                case "BEN":
                    return new BENPropertyParser();
                default: return null;
            }
        }
    }
}
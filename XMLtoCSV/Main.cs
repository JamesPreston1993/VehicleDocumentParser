using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace XMLtoCSV
{
    class Runner
    {
        static void Main(string[] args)
        {
            string specifiedPath = string.Empty;

            // If path is passed down use it, otherwise use current directory
            if (args.Length != 0)
                specifiedPath = args[0];

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), specifiedPath);

            IList<string> csvRows = new List<string>();
            
            var xmlParser = new XmlParser(new string[]
            {
                "VIN",
                "Year",
                "Make",
                "Model",
                "Engine",
                "BEN",
                "Systems"
            });

            // Build contents
            foreach (string file in Directory.GetFiles(filePath))
            {
                if (file.EndsWith(".xml"))
                {
                    var xDoc = XDocument.Load(file);
                    var data = xmlParser.Parse(xDoc);
                    csvRows.Add(data);
                }
            }

            // Write to CSV file
            var timestamp = DateTime.Now.ToString("dd-MM-yy_HH-mm-ss");
            var fileName = "output_" + timestamp + ".csv";

            var outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), fileName));

            var header = string.Empty;

            foreach (var property in xmlParser.Parsers)
            {
                header += property.Name + ",";
            }            
            
            outputFile.WriteLine(header.Substring(0, header.Length - 1));

            foreach (var line in csvRows)
            {
                outputFile.WriteLine(line);
            }

            outputFile.Close();
        }
    }
}

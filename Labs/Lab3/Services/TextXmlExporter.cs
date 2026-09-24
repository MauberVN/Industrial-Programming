using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Lab3.TextModel;

namespace Lab3.Services
{
    public class TextXmlExporter
    {
        public static void Export(Text text, string filePath)
        {
            var serializer = new XmlSerializer(typeof(Text));
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                Encoding = new UTF8Encoding()
            };
            
            using var writer = XmlWriter.Create(filePath, settings);
            
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(writer, text, namespaces);
        }
    }
}

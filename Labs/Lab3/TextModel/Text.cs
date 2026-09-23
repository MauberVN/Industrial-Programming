using System.Text;
using System.Xml.Serialization;
using Lab3.Tokens;

namespace Lab3.TextModel
{
    [XmlRoot("text")]
    public class Text
    {
        [XmlElement("sentence")]
        public List<Sentence> Sentences { get; set; } = [];

        public Text()
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var sentence in Sentences)
            {
                sb.Append(sentence);
                sb.Append(' ');
            }
            return sb.ToString().TrimEnd();
        }
        
    }
}
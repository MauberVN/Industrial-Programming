using System.Xml.Serialization;

namespace Lab3.Tokens
{
    [Serializable]
    public class Punctuation : Token
    {
        private static readonly HashSet<string> Terminators = [".", "!", "?", "…"];

        public Punctuation()
        {
        }

        public Punctuation(string value) : base(value)
        {
        }
        
        [XmlIgnore]
        public bool IsSentenceTerminator => Terminators.Contains(Value);
        
        [XmlIgnore]
        public bool IsQuestionMark => Value == "?";
    }
}

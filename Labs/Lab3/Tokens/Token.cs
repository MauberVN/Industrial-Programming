using System.Xml.Serialization;

namespace Lab3.Tokens
{
    [Serializable]
    public abstract class Token
    {
        [XmlText]
        public string Value { get; set; } = string.Empty;

        protected Token()
        {
        }

        protected Token(string value)
        {
            Value = value;
        }
        
        public override string ToString() => Value;
    }
}
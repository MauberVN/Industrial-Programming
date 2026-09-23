using System.Text;
using System.Xml.Serialization;

namespace Lab3.Tokens
{
    [XmlRoot("sentence")]
    public class Sentence
    {
        [XmlElement("word", typeof(Word))]
        [XmlElement("punctuation", typeof(Punctuation))]
        public List<Token> Tokens { get; set; } = [];

        public Sentence()
        {
        }

        public Sentence(IEnumerable<Token> tokens)
        {
            Tokens = [.. tokens];
        }
            
        [XmlIgnore]
        public IEnumerable<Word> Words => Tokens.OfType<Word>();
            
        [XmlIgnore]
        public IEnumerable<Punctuation> Punctuations => Tokens.OfType<Punctuation>();
            
        [XmlIgnore]
        public int WordCount => Words.Count();
            
        [XmlIgnore]
        public int Length => ToString()!.Length;

        public bool IsQuestion()
        {
            var lastPunctuation = Punctuations.LastOrDefault();
            return lastPunctuation is { IsQuestionMark: true };
        }
            
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var token in Tokens)
            {
                if (token is not Punctuation && sb.Length > 0 && !char.IsWhiteSpace(sb[^1])) 
                    sb.Append(' ');

                sb.Append(token.Value);
            }
            return sb.ToString();
        }
    }
}
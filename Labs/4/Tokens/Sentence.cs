using System.Text;

namespace _4.Tokens
{
    public class Sentence
    {
        public List<Token> Tokens { get; }

        public Sentence(IEnumerable<Token> tokens)
        {
            Tokens = [.. tokens];
        }

        public IEnumerable<Word> Words => Tokens.OfType<Word>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var token in Tokens)
            {
                if (token is not Punctuation && sb.Length > 0)
                    sb.Append(' ');

                sb.Append(token.Value);
            }
            return sb.ToString();
        }
    }
}

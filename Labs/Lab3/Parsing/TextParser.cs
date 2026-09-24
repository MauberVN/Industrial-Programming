using System.Text.RegularExpressions;
using Lab3.TextModel;
using Lab3.Tokens;

namespace Lab3.Parsing
{
    public partial class TextParser
    {
        private static readonly Regex TokenRegex = MyRegex();

        private static readonly HashSet<string> SentenceTerminators = [".", "!", "?", "…"];

        public Text Parse(string rawText)
        {
            ArgumentNullException.ThrowIfNull(rawText);

            var text = new Text();
            var currentSentenceTokens = new List<Token>();

            foreach (Match match in TokenRegex.Matches(rawText))
            {
                if (match.Groups["word"].Success)
                {
                    currentSentenceTokens.Add(new Word(match.Groups["word"].Value));
                }
                else if (match.Groups["punct"].Success)
                {
                    var mark = match.Groups["punct"].Value;
                    currentSentenceTokens.Add(new Punctuation(mark));

                    if (SentenceTerminators.Contains(mark))
                        FlushSentence(text, currentSentenceTokens);
                }
            }

            FlushSentence(text, currentSentenceTokens);

            return text;
        }

        private static void FlushSentence(Text text, List<Token> tokens)
        {
            if (tokens.Count == 0)
                return;

            text.Sentences.Add(new Sentence(tokens));
            tokens.Clear();
        }

        [GeneratedRegex(@"(?<word>[\p{L}\p{Nd}]+(?:['’\-][\p{L}\p{Nd}]+)*)|(?<punct>[^\s\p{L}\p{Nd}])", RegexOptions.Compiled)]
        private static partial Regex MyRegex();
    }
}
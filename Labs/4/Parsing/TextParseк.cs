using System.Text.RegularExpressions;
using _4.TextModel;
using _4.Tokens;

namespace _4.Parsing
{
    public class TextParser
    {
        private static readonly Regex TokenRegex = new Regex(
                @"(?<word>[\p{L}\p{Nd}]+(?:['’\-][\p{L}\p{Nd}]+)*)|(?<punct>[^\s\p{L}\p{Nd}])",
            RegexOptions.Compiled);

        private static readonly HashSet<string> SentenceTerminators = [".", "!", "?", "…"];

        public Text Parse(string rawText)
        {
            ArgumentNullException.ThrowIfNull(rawText);

            var text = new Text();
            var currentSentenceTokens = new List<Token>();
            var lineNumber = 0;

            using var reader = new StringReader(rawText);
            while (reader.ReadLine() is { } line)
            {
                lineNumber++;

                foreach (Match match in TokenRegex.Matches(line))
                {
                    if (match.Groups["word"].Success)
                    {
                        currentSentenceTokens.Add(new Word(match.Value, lineNumber));
                    }
                    else
                    {
                        currentSentenceTokens.Add(new Punctuation(match.Value, lineNumber));

                        if (SentenceTerminators.Contains(match.Value))
                            FlushSentence(text, currentSentenceTokens);
                    }
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
    }
}

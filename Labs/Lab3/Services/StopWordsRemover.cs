using Lab3.TextModel;
using Lab3.Tokens;

namespace Lab3.Services
{
    public class StopWordsRemover
    {
        private readonly HashSet<string> _stopWords;
        
        public StopWordsRemover(IEnumerable<string> stopWords)
        {
            _stopWords =
            [
                .. stopWords.Select(w => w.Trim().ToLowerInvariant()).Where(w => w.Length > 0)
            ];
        }

        public static StopWordsRemover FromFile(string filePath)
        {
            return  new StopWordsRemover(File.ReadAllLines(filePath));
        }

        public int RemoveStopWords(Text text)
        {
            int removed = 0;
            foreach (var sentence in text.Sentences)
            {
                removed += sentence.Tokens.RemoveAll(token =>
                    token is Word word && _stopWords.Contains(word.Value.ToLowerInvariant()));
            }
            return removed;
        }
    }
}

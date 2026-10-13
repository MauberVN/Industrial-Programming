using System.Globalization;
using System.Text;

namespace _4.Services
{
    public class Concordance
    {
        private static readonly StringComparer WordComparer =
            StringComparer.Create(CultureInfo.InvariantCulture, ignoreCase: true);

        private readonly Dictionary<string, ConcordanceEntry> _entries = new(WordComparer);

        public void Add(string word, int line)
        {
            if (string.IsNullOrWhiteSpace(word))
                return;

            var key = word.ToLowerInvariant();
            if (!_entries.TryGetValue(key, out var entry))
            {
                entry = new ConcordanceEntry();
                _entries[key] = entry;
            }

            entry.Add(line);
        }
        
        public IEnumerable<string> Format()
        {
            if (_entries.Count == 0)
                yield break;

            var width = _entries.Keys.Max(k => k.Length) + 5;

            foreach (var (word, entry) in _entries.OrderBy(p => p.Key, WordComparer))
            {
                var sb = new StringBuilder();
                sb.Append(word);

                var countText = entry.Count.ToString(CultureInfo.InvariantCulture);
                var dots = Math.Max(1, width - word.Length - countText.Length);
                sb.Append('.', dots);

                sb.Append(countText).Append(": ").Append(string.Join(' ', entry.Lines));
                yield return sb.ToString();
            }
        }
    }
}
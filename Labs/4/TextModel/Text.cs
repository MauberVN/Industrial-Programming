using _4.Services;
using _4.Tokens;

namespace _4.TextModel
{
    public class Text
    {
        public List<Sentence> Sentences { get; } = [];
        
        public Concordance BuildConcordance()
        {
            var concordance = new Concordance();

            foreach (var sentence in Sentences)
                foreach (var word in sentence.Words)
                    concordance.Add(word.Value, word.Line);

            return concordance;
        }
    }
}

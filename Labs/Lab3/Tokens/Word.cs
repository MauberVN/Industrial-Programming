using System.Xml.Serialization;

namespace Lab3.Tokens
{
    [Serializable]
    public class Word : Token
    {
        private static readonly HashSet<char> Vowels =
        [
            'a', 'e', 'i', 'o', 'u', 'y',
            'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я'
        ];

        public Word()
        {
        }

        public Word(string value) : base(value)
        {
        }
        
        [XmlIgnore]
        public int Length => Value.Length;

        public bool StartsWithConsonant()
        {
            if (string.IsNullOrEmpty(Value))
                return false;
            
            char first = char.ToLower(Value[0]);
            if (!char.IsLetter(first))
                return false;
            
            return !Vowels.Contains(first);
        }
    }
}

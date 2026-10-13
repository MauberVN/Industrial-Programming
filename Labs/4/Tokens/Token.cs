namespace _4.Tokens
{
    public abstract class Token
    {
        public string Value { get; }

        public int Line { get; }

        protected Token(string value, int line)
        {
            Value = value;
            Line = line;
        }

        public override string ToString() => Value;
    }
}
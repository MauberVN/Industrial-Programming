namespace Lab3.Tokens
{
    [Serializable]
    public abstract class Token
    {
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
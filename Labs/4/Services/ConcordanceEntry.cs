namespace _4.Services
{
    public class ConcordanceEntry
    {
        public int Count { get; private set; }

        public SortedSet<int> Lines { get; } = [];

        public void Add(int line)
        {
            Count++;
            Lines.Add(line);
        }
    }
}

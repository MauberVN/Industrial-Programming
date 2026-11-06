using System.Collections;
using _5.Models.Interfaces;
using _5.Models.Sweets.Abstract;

namespace _5.Models;

public class Gift : IWeighable, IEnumerable<Sweet>
{
    private readonly List<Sweet> _sweets = [];

    public Gift(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }

    public string Name { get; }

    public int Count => _sweets.Count;

    public double WeightGrams => _sweets.Sum(s => s.WeightGrams);

    public void Add(Sweet sweet) =>
        _sweets.Add(sweet ?? throw new ArgumentNullException(nameof(sweet)));

    public void AddRange(IEnumerable<Sweet> sweets)
    {
        foreach (var sweet in sweets)
            Add(sweet);
    }

    public bool Remove(Sweet sweet) => _sweets.Remove(sweet);

    public void Sort(IComparer<Sweet> comparer)
    {
        var sorted = _sweets.OrderBy(s => s, comparer).ToList();
        _sweets.Clear();
        _sweets.AddRange(sorted);
    }

    public IEnumerable<Sweet> FindBySugarRange(double min, double max)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(min, max);
        return _sweets.Where(s => s.SugarGrams >= min && s.SugarGrams <= max);
    }

    public IEnumerator<Sweet> GetEnumerator() => _sweets.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
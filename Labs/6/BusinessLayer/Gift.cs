using System.Collections;
using BusinessLayer.Interfaces;
using BusinessLayer.Sweets;
using BusinessLayer.Validation;

namespace BusinessLayer;

public class Gift : BusinessObject, IWeighable, ISugarContaining, IEnumerable<Sweet>
{
    public const double MaxWeightGrams = 3000;

    private readonly List<Sweet> _sweets = [];

    public Gift(string name)
    {
        Name = name?.Trim() ?? string.Empty;
    }

    public string Name { get; set; }

    public int Count => _sweets.Count;
    public double WeightGrams => _sweets.Sum(s => s.WeightGrams);
    public double SugarGrams => _sweets.Sum(s => s.SugarGrams);
    public double Calories => _sweets.Sum(s => s.Calories);
    
    public void Add(Sweet sweet)
    {
        ArgumentNullException.ThrowIfNull(sweet);
        sweet.EnsureValid();

        if (WeightGrams + sweet.WeightGrams > MaxWeightGrams)
            throw new BusinessValidationException([
                new BusinessRule(nameof(WeightGrams),
                    $"Вес подарка не может превышать {MaxWeightGrams:F0} г.")
            ]);

        _sweets.Add(sweet);
    }

    public void AddRange(IEnumerable<Sweet> sweets)
    {
        foreach (var sweet in sweets)
            Add(sweet);
    }

    public bool Remove(Sweet sweet) => _sweets.Remove(sweet);

    public void Clear() => _sweets.Clear();

    public void Sort(IComparer<Sweet> comparer)
    {
        var sorted = _sweets.OrderBy(s => s, comparer).ToList();
        _sweets.Clear();
        _sweets.AddRange(sorted);
    }

    public IEnumerable<Sweet> FindBySugarRange(double min, double max)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(min);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(max);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(min, max);
        return _sweets.Where(s => s.SugarGrams >= min && s.SugarGrams <= max);
    }

    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            AddBrokenRule(nameof(Name), "Название подарка не может быть пустым.");

        if (WeightGrams > MaxWeightGrams)
            AddBrokenRule(nameof(WeightGrams), $"Вес подарка не может превышать {MaxWeightGrams:F0} г.");

        if (_sweets.Any(s => !s.IsValid))
            AddBrokenRule(nameof(Gift), "В подарке есть некорректные сладости.");
    }

    public IEnumerator<Sweet> GetEnumerator() => _sweets.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
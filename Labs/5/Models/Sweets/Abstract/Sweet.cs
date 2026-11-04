using _5.Models.Interfaces;

namespace _5.Models.Sweets.Abstract;

public abstract class Sweet : IWeighable, ISugarContaining
{
    protected Sweet(string name, double weightGrams, double sugarGrams, double caloriesPer100G)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegative(weightGrams);
        ArgumentOutOfRangeException.ThrowIfNegative(sugarGrams);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(sugarGrams, weightGrams);
        ArgumentOutOfRangeException.ThrowIfNegative(caloriesPer100G);

        Name = name;
        WeightGrams = weightGrams;
        SugarGrams = sugarGrams;
        CaloriesPer100G = caloriesPer100G;
    }

    public string Name { get; }
    public double WeightGrams { get; }
    public double SugarGrams { get; }
    public double CaloriesPer100G { get; }

    public abstract string Category { get; }

    protected virtual string Details => string.Empty;

    public override string ToString()
    {
        string details = string.IsNullOrEmpty(Details) ? string.Empty : $", {Details}";
        return $"[{Category}] {Name}: {WeightGrams:F1} г, сахар {SugarGrams:F2} г, " +
               $"{CaloriesPer100G:F0} ккал/100г{details}";
    }
}
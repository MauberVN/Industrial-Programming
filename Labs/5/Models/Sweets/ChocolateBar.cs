using _5.Models.Sweets.Abstract;

namespace _5.Models.Sweets;

public class ChocolateBar : Sweet
{
    public ChocolateBar(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, double cocoaPercent)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(cocoaPercent);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cocoaPercent, 100);
        CocoaPercent = cocoaPercent;
    }

    public double CocoaPercent { get; }

    public override string Category => "Шоколад";
    protected override string Details => $"какао {CocoaPercent:F0}%";
}
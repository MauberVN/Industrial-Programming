using _5.Models.Sweets.Abstract;

namespace _5.Models.Sweets;

public class ChocolateCandy : Candy
{
    public ChocolateCandy(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, double cocoaPercent, string filling)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(cocoaPercent);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cocoaPercent, 100);
        CocoaPercent = cocoaPercent;
        Filling = filling;
    }

    public double CocoaPercent { get; }
    public string Filling { get; }

    public override string Category => "Шоколадная конфета";
    protected override string Details => $"какао {CocoaPercent:F0}%, начинка: {Filling}";
}
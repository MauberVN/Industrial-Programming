namespace BusinessLayer.Sweets;

public class ChocolateCandy : Candy
{
    public ChocolateCandy(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, double cocoaPercent, string filling)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        CocoaPercent = cocoaPercent;
        Filling = filling?.Trim() ?? string.Empty;
    }

    public double CocoaPercent { get; }
    public string Filling { get; }

    public override string Category => SweetCategories.ChocolateCandy;
    public override string Details => string.IsNullOrEmpty(Filling)
        ? $"какао {CocoaPercent:F0}%"
        : $"какао {CocoaPercent:F0}%, начинка: {Filling}";

    protected override void Validate()
    {
        base.Validate();
        if (double.IsNaN(CocoaPercent) || CocoaPercent < 0 || CocoaPercent > 100)
            AddBrokenRule(nameof(CocoaPercent), "Содержание какао должно быть от 0 до 100 %.");
    }
}
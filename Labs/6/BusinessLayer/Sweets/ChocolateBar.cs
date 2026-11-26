namespace BusinessLayer.Sweets;

public class ChocolateBar : Sweet
{
    public ChocolateBar(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, double cocoaPercent)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        CocoaPercent = cocoaPercent;
    }

    public double CocoaPercent { get; }

    public override string Category => SweetCategories.ChocolateBar;
    public override string Details => $"какао {CocoaPercent:F0}%";

    protected override void Validate()
    {
        base.Validate();
        if (double.IsNaN(CocoaPercent) || CocoaPercent < 0 || CocoaPercent > 100)
            AddBrokenRule(nameof(CocoaPercent), "Содержание какао должно быть от 0 до 100 %.");
    }
}
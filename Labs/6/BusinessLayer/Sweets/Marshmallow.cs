namespace BusinessLayer.Sweets;

public class Marshmallow : Sweet
{
    public Marshmallow(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, string color)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        Color = color?.Trim() ?? string.Empty;
    }

    public string Color { get; }

    public override string Category => SweetCategories.Marshmallow;
    public override string Details => $"цвет: {Color}";

    protected override void Validate()
    {
        base.Validate();
        if (string.IsNullOrWhiteSpace(Color))
            AddBrokenRule(nameof(Color), "Укажите цвет зефира.");
    }
}
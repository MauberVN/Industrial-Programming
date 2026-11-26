namespace BusinessLayer.Sweets;

public class JellyCandy : Candy
{
    public JellyCandy(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, string fruitBase)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        FruitBase = fruitBase?.Trim() ?? string.Empty;
    }

    public string FruitBase { get; }

    public override string Category => SweetCategories.JellyCandy;
    public override string Details => $"основа: {FruitBase}";

    protected override void Validate()
    {
        base.Validate();
        if (string.IsNullOrWhiteSpace(FruitBase))
            AddBrokenRule(nameof(FruitBase), "Укажите фруктовую основу желейной конфеты.");
    }
}
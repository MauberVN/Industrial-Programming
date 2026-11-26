namespace BusinessLayer.Sweets;

public class Lollipop : Candy
{
    public Lollipop(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, string flavor)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        Flavor = flavor?.Trim() ?? string.Empty;
    }

    public string Flavor { get; }

    public override string Category => SweetCategories.Lollipop;
    public override string Details => $"вкус: {Flavor}";

    protected override void Validate()
    {
        base.Validate();
        if (string.IsNullOrWhiteSpace(Flavor))
            AddBrokenRule(nameof(Flavor), "Укажите вкус леденца.");
    }
}

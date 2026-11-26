namespace BusinessLayer.Sweets;

public class Cookie : Sweet
{
    public Cookie(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, bool hasNuts)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        HasNuts = hasNuts;
    }

    public bool HasNuts { get; }

    public override string Category => SweetCategories.Cookie;
    public override string Details => HasNuts ? "с орехами" : "без орехов";
}
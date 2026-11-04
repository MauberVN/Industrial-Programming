using _5.Models.Sweets.Abstract;

namespace _5.Models.Sweets;

public class Cookie : Sweet
{
    public Cookie(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, bool hasNuts)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        HasNuts = hasNuts;
    }

    public bool HasNuts { get; }

    public override string Category => "Печенье";
    protected override string Details => HasNuts ? "с орехами" : "без орехов";
}
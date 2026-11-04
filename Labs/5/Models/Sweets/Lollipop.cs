using _5.Models.Sweets.Abstract;

namespace _5.Models.Sweets;

public class Lollipop : Candy
{
    public Lollipop(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, string flavor)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        Flavor = flavor;
    }

    public string Flavor { get; }

    public override string Category => "Леденец";
    protected override string Details => $"вкус: {Flavor}";
}
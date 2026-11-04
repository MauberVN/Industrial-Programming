using _5.Models.Sweets.Abstract;

namespace _5.Models.Sweets;

public class JellyCandy : Candy
{
    public JellyCandy(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, string fruitBase)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        FruitBase = fruitBase;
    }

    public string FruitBase { get; }

    public override string Category => "Желейная конфета";
    protected override string Details => $"основа: {FruitBase}";
}
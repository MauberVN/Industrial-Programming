using _5.Models.Sweets.Abstract;

namespace _5.Models.Sweets;

public class Marshmallow : Sweet
{
    public Marshmallow(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, string color)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        Color = color;
    }

    public string Color { get; }

    public override string Category => "Зефир";
    protected override string Details => $"цвет: {Color}";
}
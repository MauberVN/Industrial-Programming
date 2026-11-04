using _5.Models.Sweets.Abstract;

namespace _5.Models.Sweets;

public class Caramel : Candy
{
    public Caramel(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, bool hasFilling)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        HasFilling = hasFilling;
    }

    public bool HasFilling { get; }

    public override string Category => "Карамель";
    protected override string Details => HasFilling ? "с начинкой" : "без начинки";
}
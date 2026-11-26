namespace BusinessLayer.Sweets;

public class Caramel : Candy
{
    public Caramel(string name, double weightGrams, double sugarGrams,
        double caloriesPer100G, bool hasFilling)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
        HasFilling = hasFilling;
    }

    public bool HasFilling { get; }

    public override string Category => SweetCategories.Caramel;
    public override string Details => HasFilling ? "с начинкой" : "без начинки";
}
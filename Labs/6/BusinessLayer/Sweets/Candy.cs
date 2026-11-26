namespace BusinessLayer.Sweets;

public abstract class Candy : Sweet
{
    protected Candy(string name, double weightGrams, double sugarGrams, double caloriesPer100G)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
    }
}
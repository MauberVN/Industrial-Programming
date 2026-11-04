namespace _5.Models.Sweets.Abstract;

public abstract class Candy : Sweet
{
    protected Candy(string name, double weightGrams, double sugarGrams, double caloriesPer100G)
        : base(name, weightGrams, sugarGrams, caloriesPer100G)
    {
    }
}
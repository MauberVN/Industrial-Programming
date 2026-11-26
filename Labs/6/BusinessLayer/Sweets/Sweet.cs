using BusinessLayer.Interfaces;
using BusinessLayer.Validation;

namespace BusinessLayer.Sweets;

public abstract class Sweet : BusinessObject, IWeighable, ISugarContaining
{
    public const double MaxCaloriesPer100G = 900;

    protected Sweet(string name, double weightGrams, double sugarGrams, double caloriesPer100G)
    {
        Name = name?.Trim() ?? string.Empty;
        WeightGrams = weightGrams;
        SugarGrams = sugarGrams;
        CaloriesPer100G = caloriesPer100G;
    }

    public string Name { get; }
    public double WeightGrams { get; }
    public double SugarGrams { get; }
    public double CaloriesPer100G { get; }

    public double Calories => WeightGrams * CaloriesPer100G / 100;

    public abstract string Category { get; }

    public virtual string Details => string.Empty;

    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            AddBrokenRule(nameof(Name), "Название не может быть пустым.");

        if (double.IsNaN(WeightGrams) || WeightGrams <= 0)
            AddBrokenRule(nameof(WeightGrams), "Вес должен быть больше нуля.");

        if (double.IsNaN(SugarGrams) || SugarGrams < 0)
            AddBrokenRule(nameof(SugarGrams), "Содержание сахара не может быть отрицательным.");
        else if (SugarGrams > WeightGrams)
            AddBrokenRule(nameof(SugarGrams), "Сахара не может быть больше, чем вес сладости.");

        if (double.IsNaN(CaloriesPer100G) || CaloriesPer100G < 0 || CaloriesPer100G > MaxCaloriesPer100G)
            AddBrokenRule(nameof(CaloriesPer100G),
                $"Калорийность должна быть в диапазоне 0..{MaxCaloriesPer100G:F0} ккал на 100 г.");
    }

    public override string ToString()
    {
        var details = string.IsNullOrEmpty(Details) ? string.Empty : $", {Details}";
        return $"[{Category}] {Name}: {WeightGrams:F1} г, сахар {SugarGrams:F2} г, " +
               $"{CaloriesPer100G:F0} ккал/100г{details}";
    }
}
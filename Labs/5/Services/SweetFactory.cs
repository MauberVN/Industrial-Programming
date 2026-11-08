using _5.Models.Sweets;
using _5.Models.Sweets.Abstract;

namespace _5.Services;

public static class SweetFactory
{
    public static Sweet Create(SweetDto d) => d.Type switch
    {
        nameof(ChocolateCandy) => new ChocolateCandy(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.CocoaPercent ?? 0, d.Filling ?? string.Empty),
        nameof(Lollipop) => new Lollipop(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.Flavor ?? string.Empty),
        nameof(Caramel) => new Caramel(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.HasFilling ?? false),
        nameof(JellyCandy) => new JellyCandy(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.FruitBase ?? string.Empty),
        nameof(Cookie) => new Cookie(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.HasNuts ?? false),
        nameof(ChocolateBar) => new ChocolateBar(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.CocoaPercent ?? 0),
        nameof(Marshmallow) => new Marshmallow(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.Color ?? string.Empty),
        _ => throw new NotSupportedException($"Неизвестный тип сладости: '{d.Type}'.")
    };
}
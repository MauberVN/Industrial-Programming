using _5.Models.Sweets;
using _5.Models.Sweets.Abstract;

namespace _5.Services;

public static class SweetFactory
{
    public static Sweet Create(SweetDto d) => d.Type.ToLowerInvariant() switch
    {
        "chocolatecandy" => new ChocolateCandy(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.CocoaPercent ?? 0, d.Filling ?? string.Empty),
        "lollipop" => new Lollipop(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.Flavor ?? string.Empty),
        "caramel" => new Caramel(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.HasFilling ?? false),
        "jellycandy" => new JellyCandy(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.FruitBase ?? string.Empty),
        "cookie" => new Cookie(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.HasNuts ?? false),
        "chocolatebar" => new ChocolateBar(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.CocoaPercent ?? 0),
        "marshmallow" => new Marshmallow(d.Name, d.WeightGrams, d.SugarGrams,
            d.CaloriesPer100G, d.Color ?? string.Empty),
        _ => throw new NotSupportedException($"Неизвестный тип сладости: '{d.Type}'.")
    };
}
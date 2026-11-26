using BusinessLayer.Sweets;
using DataAccessLayer.Dto;

namespace DataAccessLayer;

public static class SweetDtoMapper
{
    public static Sweet ToBusiness(SweetDto d) => d.Type switch
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
        _ => throw new DataAccessException($"Неизвестный тип сладости в файле данных: '{d.Type}'.")
    };

    public static SweetDto ToDto(Sweet sweet)
    {
        var dto = new SweetDto
        {
            Name = sweet.Name,
            WeightGrams = sweet.WeightGrams,
            SugarGrams = sweet.SugarGrams,
            CaloriesPer100G = sweet.CaloriesPer100G
        };

        switch (sweet)
        {
            case ChocolateCandy candy:
                dto.Type = nameof(ChocolateCandy);
                dto.CocoaPercent = candy.CocoaPercent;
                dto.Filling = candy.Filling;
                break;
            case Lollipop lollipop:
                dto.Type = nameof(Lollipop);
                dto.Flavor = lollipop.Flavor;
                break;
            case Caramel caramel:
                dto.Type = nameof(Caramel);
                dto.HasFilling = caramel.HasFilling;
                break;
            case JellyCandy jelly:
                dto.Type = nameof(JellyCandy);
                dto.FruitBase = jelly.FruitBase;
                break;
            case Cookie cookie:
                dto.Type = nameof(Cookie);
                dto.HasNuts = cookie.HasNuts;
                break;
            case ChocolateBar bar:
                dto.Type = nameof(ChocolateBar);
                dto.CocoaPercent = bar.CocoaPercent;
                break;
            case Marshmallow marshmallow:
                dto.Type = nameof(Marshmallow);
                dto.Color = marshmallow.Color;
                break;
            default:
                throw new DataAccessException($"Сохранение типа {sweet.GetType().Name} не поддерживается.");
        }

        return dto;
    }
}
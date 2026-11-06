using _5.Models.Sweets;
using _5.Models.Sweets.Abstract;

namespace _5.Services;

public static class SweetDtoMapper
{
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
                throw new NotSupportedException($"Экспорт типа {sweet.GetType().Name} не поддерживается.");
        }

        return dto;
    }
}
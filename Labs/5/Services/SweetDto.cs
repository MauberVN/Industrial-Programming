namespace _5.Services;

public class SweetDto
{
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double WeightGrams { get; set; }
    public double SugarGrams { get; set; }
    public double CaloriesPer100G { get; set; }

    public int? Count { get; set; }

    public double? CocoaPercent { get; set; }
    public string? Filling { get; set; }
    public string? Flavor { get; set; }
    public bool? HasFilling { get; set; }
    public string? FruitBase { get; set; }
    public bool? HasNuts { get; set; }
    public string? Color { get; set; }
}
using BusinessLayer.Sweets;

namespace ServiceLayer;

public class SweetDraft
{
    public SweetKind Kind { get; set; }
    public string Name { get; set; } = string.Empty;
    public double WeightGrams { get; set; }
    public double SugarGrams { get; set; }
    public double CaloriesPer100G { get; set; }

    public double CocoaPercent { get; set; }
    public string Filling { get; set; } = string.Empty;
    public string Flavor { get; set; } = string.Empty;
    public bool HasFilling { get; set; }
    public string FruitBase { get; set; } = string.Empty;
    public bool HasNuts { get; set; }
    public string Color { get; set; } = string.Empty;
}
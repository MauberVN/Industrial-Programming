using BusinessLayer.Sweets;

namespace BusinessLayer;

public static class SweetComparer
{
    public static IComparer<Sweet> ByName { get; } =
        Comparer<Sweet>.Create((x, y) => string.Compare(x?.Name, y?.Name, StringComparison.CurrentCultureIgnoreCase));

    public static IComparer<Sweet> ByCalories { get; } =
        Comparer<Sweet>.Create((x, y) => Nullable.Compare(x?.CaloriesPer100G, y?.CaloriesPer100G));

    public static IComparer<Sweet> BySugar { get; } =
        Comparer<Sweet>.Create((x, y) => Nullable.Compare(x?.SugarGrams, y?.SugarGrams));

    public static IComparer<Sweet> ByWeight { get; } =
        Comparer<Sweet>.Create((x, y) => Nullable.Compare(x?.WeightGrams, y?.WeightGrams));

    public static IComparer<Sweet> Reverse(IComparer<Sweet> comparer) =>
        Comparer<Sweet>.Create((x, y) => comparer.Compare(y, x));
}
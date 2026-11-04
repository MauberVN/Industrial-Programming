using _5.Models.Sweets.Abstract;

namespace _5.Comparers;

public static class SweetComparer
{
    public static IComparer<Sweet> ByCalories { get; } =
        Comparer<Sweet>.Create((x, y) => Nullable.Compare(x?.CaloriesPer100G, y?.CaloriesPer100G));

    public static IComparer<Sweet> BySugar { get; } =
        Comparer<Sweet>.Create((x, y) => Nullable.Compare(x?.SugarGrams, y?.SugarGrams));

    public static IComparer<Sweet> ByWeight { get; } =
        Comparer<Sweet>.Create((x, y) => Nullable.Compare(x?.WeightGrams, y?.WeightGrams));
}
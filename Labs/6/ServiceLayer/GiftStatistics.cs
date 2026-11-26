namespace ServiceLayer;

public sealed record GiftStatistics(
    int Count,
    double WeightGrams,
    double SugarGrams,
    double Calories,
    IReadOnlyDictionary<string, int> CountByCategory);
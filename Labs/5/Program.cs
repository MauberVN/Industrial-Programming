using _5.Comparers;
using _5.Models;
using _5.Models.Sweets.Abstract;
using _5.Services;

namespace _5;

public static class Program
{
    private const string DataFile = "Data/sweets.json";
    private const string ExportFile = "Export/gift.json";

    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var dataPath = Path.Combine(AppContext.BaseDirectory, DataFile);
        var gift = new Gift("Детский новогодний подарок");
        gift.AddRange(SweetsRepository.Load(dataPath));

        Console.WriteLine($"=== {gift.Name} ===");
        Print(gift);
        Console.WriteLine($"\nОбщий вес подарка: {gift.WeightGrams:F1} г");

        Console.WriteLine("\n--- Сортировка по каллориям (по возрастанию) ---");
        gift.Sort(SweetComparer.ByCalories);
        Print(gift);

        Console.WriteLine("\n--- Сортировка по содержанию сахара (по возрастанию) ---");
        gift.Sort(SweetComparer.BySugar);
        Print(gift);

        Console.WriteLine("\n--- Сортировка по весу (по возрастанию) ---");
        gift.Sort(SweetComparer.ByWeight);
        Print(gift);

        const double minSugar = 5, maxSugar = 10;
        Console.WriteLine($"\n--- Сладости с содержанием сахара {minSugar}..{maxSugar} г ---");
        foreach (var sweet in gift.FindBySugarRange(minSugar, maxSugar))
            Console.WriteLine(sweet);

        var exportPath = Path.Combine(AppContext.BaseDirectory, ExportFile);
        SweetsRepository.Save(gift, exportPath);
        Console.WriteLine($"\nПодарок экспортирован в файл: {exportPath}");
    }

    private static void Print(IEnumerable<Sweet> sweets)
    {
        foreach (var sweet in sweets)
            Console.WriteLine(sweet);
    }
}
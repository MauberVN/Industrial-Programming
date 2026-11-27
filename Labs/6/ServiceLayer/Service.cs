using System.Text;
using BusinessLayer;
using BusinessLayer.Sweets;
using BusinessLayer.Validation;
using DataAccessLayer;
using DataAccessLayer.Interfaces;

namespace ServiceLayer;

public class Service
{
    public const string DefaultGiftName = "Новогодний подарок";

    private readonly ISweetDao _sweetDao;
    private readonly IGiftDao _giftDao;

    public Service(ISweetDao sweetDao, IGiftDao giftDao)
    {
        _sweetDao = sweetDao ?? throw new ArgumentNullException(nameof(sweetDao));
        _giftDao = giftDao ?? throw new ArgumentNullException(nameof(giftDao));
        CurrentGift = new Gift(DefaultGiftName);
    }

    public static Service CreateDefault(string dataDirectory) =>
        new(new SweetDao(Path.Combine(dataDirectory, "catalog.json")), new GiftDao());

    public Gift CurrentGift { get; private set; }

    // ---------- Каталог ----------

    public IReadOnlyList<string> GetCategories() => SweetCategories.All;

    public OperationResult<IReadOnlyList<Sweet>> GetCatalog(string? category = null) =>
        Run<IReadOnlyList<Sweet>>(() =>
        {
            var all = _sweetDao.GetAll();
            return string.IsNullOrEmpty(category)
                ? all
                : all.Where(s => s.Category == category).ToList();
        });

    public OperationResult<Sweet> CreateSweet(SweetDraft draft) => Run(() =>
    {
        ArgumentNullException.ThrowIfNull(draft);

        Sweet sweet = draft.Kind switch
        {
            SweetKind.ChocolateCandy => new ChocolateCandy(draft.Name, draft.WeightGrams, draft.SugarGrams,
                draft.CaloriesPer100G, draft.CocoaPercent, draft.Filling),
            SweetKind.Lollipop => new Lollipop(draft.Name, draft.WeightGrams, draft.SugarGrams,
                draft.CaloriesPer100G, draft.Flavor),
            SweetKind.Caramel => new Caramel(draft.Name, draft.WeightGrams, draft.SugarGrams,
                draft.CaloriesPer100G, draft.HasFilling),
            SweetKind.JellyCandy => new JellyCandy(draft.Name, draft.WeightGrams, draft.SugarGrams,
                draft.CaloriesPer100G, draft.FruitBase),
            SweetKind.Cookie => new Cookie(draft.Name, draft.WeightGrams, draft.SugarGrams,
                draft.CaloriesPer100G, draft.HasNuts),
            SweetKind.ChocolateBar => new ChocolateBar(draft.Name, draft.WeightGrams, draft.SugarGrams,
                draft.CaloriesPer100G, draft.CocoaPercent),
            SweetKind.Marshmallow => new Marshmallow(draft.Name, draft.WeightGrams, draft.SugarGrams,
                draft.CaloriesPer100G, draft.Color),
            _ => throw new ArgumentOutOfRangeException(nameof(draft), "Неизвестный вид сладости.")
        };

        sweet.EnsureValid();
        return sweet;
    });

    public OperationResult AddSweetToCatalog(Sweet sweet) => Run(() =>
    {
        ArgumentNullException.ThrowIfNull(sweet);
        sweet.EnsureValid();

        var duplicate = _sweetDao.GetAll().Any(s =>
            s.Category == sweet.Category &&
            string.Equals(s.Name, sweet.Name, StringComparison.CurrentCultureIgnoreCase));
        if (duplicate)
            throw new BusinessValidationException([
                new BusinessRule(nameof(Sweet.Name), $"В каталоге уже есть «{sweet.Name}» ({sweet.Category}).")
            ]);

        _sweetDao.Add(sweet);
    });

    // ---------- Подарок ----------

    public OperationResult NewGift(string name) => Run(() =>
    {
        var gift = new Gift(name);
        gift.EnsureValid();
        CurrentGift = gift;
    });

    public OperationResult RenameGift(string name) => Run(() =>
    {
        var trimmed = name?.Trim() ?? string.Empty;
        if (trimmed.Length == 0)
            throw new BusinessValidationException([
                new BusinessRule(nameof(Gift.Name), "Название подарка не может быть пустым.")
            ]);
        CurrentGift.Name = trimmed;
    });

    public OperationResult AddToGift(Sweet sweet) => Run(() => CurrentGift.Add(sweet));

    public bool RemoveFromGift(Sweet sweet) => CurrentGift.Remove(sweet);

    public void ClearGift() => CurrentGift.Clear();

    public void SortGift(SortCriterion criterion, bool descending = false)
    {
        var comparer = criterion switch
        {
            SortCriterion.Name => SweetComparer.ByName,
            SortCriterion.Weight => SweetComparer.ByWeight,
            SortCriterion.Sugar => SweetComparer.BySugar,
            SortCriterion.Calories => SweetComparer.ByCalories,
            _ => throw new ArgumentOutOfRangeException(nameof(criterion), criterion, null)
        };

        CurrentGift.Sort(descending ? SweetComparer.Reverse(comparer) : comparer);
    }

    public OperationResult<IReadOnlyList<Sweet>> FindBySugarRange(double minGrams, double maxGrams) =>
        Run<IReadOnlyList<Sweet>>(() => CurrentGift.FindBySugarRange(minGrams, maxGrams).ToList());

    public GiftStatistics GetStatistics() => new(
        CurrentGift.Count,
        CurrentGift.WeightGrams,
        CurrentGift.SugarGrams,
        CurrentGift.Calories,
        CurrentGift.GroupBy(s => s.Category).ToDictionary(g => g.Key, g => g.Count()));

    // ---------- Файлы ----------

    public OperationResult SaveGift(string path) => Run(() => _giftDao.Save(CurrentGift, path));

    public OperationResult LoadGift(string path) => Run(() => CurrentGift = _giftDao.Load(path));

    public string BuildReport()
    {
        var stats = GetStatistics();
        var sb = new StringBuilder();
        sb.AppendLine($"Подарок: {CurrentGift.Name}");
        sb.AppendLine($"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}");
        sb.AppendLine();
        sb.AppendLine("Состав подарка:");

        var number = 1;
        foreach (var sweet in CurrentGift)
            sb.AppendLine($"{number++,3}. {sweet}");

        if (stats.Count == 0)
            sb.AppendLine("  (пусто)");

        sb.AppendLine();
        sb.AppendLine($"Всего сладостей: {stats.Count}");
        sb.AppendLine($"Общий вес: {stats.WeightGrams:F1} г");
        sb.AppendLine($"Сахар: {stats.SugarGrams:F2} г");
        sb.AppendLine($"Калорийность: {stats.Calories:F0} ккал");
        return sb.ToString();
    }

    public OperationResult ExportReport(string path) => Run(() => _giftDao.SaveReport(path, BuildReport()));

    // ---------- Обработка ошибок нижних уровней ----------

    private static OperationResult Run(Action action)
    {
        try
        {
            action();
            return OperationResult.Ok();
        }
        catch (BusinessValidationException ex)
        {
            return OperationResult.Fail(ex.BrokenRules.Select(r => r.Description));
        }
        catch (DataAccessException ex)
        {
            return OperationResult.Fail(ex.Message);
        }
    }

    private static OperationResult<T> Run<T>(Func<T> func)
    {
        try
        {
            return OperationResult<T>.Ok(func());
        }
        catch (BusinessValidationException ex)
        {
            return OperationResult<T>.Fail(ex.BrokenRules.Select(r => r.Description));
        }
        catch (DataAccessException ex)
        {
            return OperationResult<T>.Fail(ex.Message);
        }
    }
}
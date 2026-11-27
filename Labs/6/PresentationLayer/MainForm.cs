using BusinessLayer;
using BusinessLayer.Sweets;
using DataLayer;
using ServiceLayer;

namespace PresentationLayer;

public sealed partial class MainForm : Form
{
    private const string AllCategories = "Все категории";
    private const string JsonFilter = "Подарок (*.json)|*.json|Все файлы (*.*)|*.*";

    private static readonly SortCriterion[] SortOrder =
    {
        SortCriterion.Name, SortCriterion.Weight, SortCriterion.Sugar, SortCriterion.Calories
    };

    private readonly Service _service;

    private (double Min, double Max)? _sugarFilter;

    public MainForm(Service service)
    {
        _service = service;

        InitializeComponent();

        categoryCombo.Items.Add(AllCategories);
        categoryCombo.Items.AddRange(_service.GetCategories().Cast<object>().ToArray());
        sortCombo.SelectedIndex = 0;
    }

    // ---------- Загрузка формы ----------

    private void MainForm_Load(object? sender, EventArgs e)
    {
        categoryCombo.SelectedIndex = 0;
        ShowGiftName();
        RefreshGift();
    }

    // ---------- Каталог ----------

    private void categoryCombo_SelectedIndexChanged(object? sender, EventArgs e) => LoadCatalog();

    private void newSweetButton_Click(object? sender, EventArgs e) => AddSweetToCatalog();

    private void addSweetItem_Click(object? sender, EventArgs e) => AddSweetToCatalog();

    private void LoadCatalog()
    {
        var category = categoryCombo.SelectedIndex > 0 ? categoryCombo.SelectedItem as string : null;
        var result = _service.GetCatalog(category);

        catalogList.BeginUpdate();
        catalogList.Items.Clear();
        if (result.Success)
        {
            foreach (var sweet in result.Value!)
                catalogList.Items.Add(SweetListView.ToItem(sweet));
        }
        catalogList.EndUpdate();

        if (result.Success)
            SetStatus($"В каталоге сладостей: {catalogList.Items.Count}");
        else
            ShowError(result.ErrorMessage);
    }

    private void AddSweetToCatalog()
    {
        using var dialog = new AddSweetForm(_service);
        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        LoadCatalog();
        SetStatus($"Сладость «{dialog.CreatedSweet?.Name}» добавлена в каталог");
    }

    // ---------- Подарок ----------

    private void addButton_Click(object? sender, EventArgs e)
    {
        var sweet = SweetListView.Selected(catalogList);
        if (sweet is null)
        {
            SetStatus("Выберите сладость в каталоге");
            return;
        }

        var result = _service.AddToGift(sweet);
        if (!result.Success)
        {
            ShowError(result.ErrorMessage);
            return;
        }

        RefreshGift();
        SetStatus($"Добавлено в подарок: {sweet.Name}");
    }

    private void removeButton_Click(object? sender, EventArgs e)
    {
        var sweet = SweetListView.Selected(giftList);
        if (sweet is null)
        {
            SetStatus("Выберите сладость в подарке");
            return;
        }

        _service.RemoveFromGift(sweet);
        RefreshGift();
        SetStatus($"Убрано из подарка: {sweet.Name}");
    }

    private void clearButton_Click(object? sender, EventArgs e)
    {
        if (_service.CurrentGift.Count == 0)
            return;

        if (MessageBox.Show(this, "Убрать из подарка все сладости?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        _service.ClearGift();
        RefreshGift();
        SetStatus("Подарок очищен");
    }

    private void renameButton_Click(object? sender, EventArgs e)
    {
        var result = _service.RenameGift(giftNameBox.Text);
        if (!result.Success)
        {
            ShowError(result.ErrorMessage);
            ShowGiftName();
            return;
        }

        ShowGiftName();
        SetStatus("Подарок переименован");
    }

    private void sortButton_Click(object? sender, EventArgs e)
    {
        _service.SortGift(SortOrder[sortCombo.SelectedIndex], descendingCheck.Checked);
        RefreshGift();
        SetStatus($"Отсортировано: {sortCombo.SelectedItem}{(descendingCheck.Checked ? ", по убыванию" : string.Empty)}");
    }

    private void findButton_Click(object? sender, EventArgs e)
    {
        var min = (double)sugarMin.Value;
        var max = (double)sugarMax.Value;

        var result = _service.FindBySugarRange(min, max);
        if (!result.Success)
        {
            ShowError(result.ErrorMessage);
            return;
        }

        _sugarFilter = (min, max);
        RefreshGift();
        SetStatus($"Найдено сладостей: {result.Value!.Count}");
    }

    private void resetButton_Click(object? sender, EventArgs e)
    {
        _sugarFilter = null;
        RefreshGift();
        SetStatus("Показаны все сладости подарка");
    }

    private void ShowGiftName()
    {
        giftNameBox.Text = _service.CurrentGift.Name;
        giftGroup.Text = $"Подарок: {_service.CurrentGift.Name}";
    }

    private void RefreshGift()
    {
        IReadOnlyList<Sweet> shown = _service.CurrentGift.ToList();
        filterInfo.Text = string.Empty;

        if (_sugarFilter is { } filter)
        {
            var result = _service.FindBySugarRange(filter.Min, filter.Max);
            if (result.Success)
            {
                shown = result.Value!;
                filterInfo.Text = $"Фильтр: сахар {filter.Min:F1}–{filter.Max:F1} г " +
                                  $"(показано {shown.Count} из {_service.CurrentGift.Count})";
            }
        }

        giftList.BeginUpdate();
        giftList.Items.Clear();
        foreach (var sweet in shown)
            giftList.Items.Add(SweetListView.ToItem(sweet));
        giftList.EndUpdate();

        var stats = _service.GetStatistics();
        var composition = stats.Count == 0
            ? "подарок пуст"
            : string.Join(", ", stats.CountByCategory.Select(p => $"{p.Key}: {p.Value}"));
        statsLabel.Text =
            $"Сладостей: {stats.Count}   Вес: {stats.WeightGrams:F1} г (максимум {Gift.MaxWeightGrams:F0} г)   " +
            $"Калорийность: {stats.Calories:F0} ккал   Сахар: {stats.SugarGrams:F1} г" +
            Environment.NewLine + "Состав: " + composition;
    }

    // ---------- Меню «Файл» ----------

    private void newItem_Click(object? sender, EventArgs e)
    {
        if (_service.CurrentGift.Count > 0 &&
            MessageBox.Show(this, "Текущий подарок будет заменён пустым. Продолжить?", "Новый подарок",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        var result = _service.NewGift(Service.DefaultGiftName);
        if (!result.Success)
        {
            ShowError(result.ErrorMessage);
            return;
        }

        _sugarFilter = null;
        ShowGiftName();
        RefreshGift();
        SetStatus("Создан новый подарок");
    }

    private void openItem_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Title = "Открыть подарок",
            Filter = JsonFilter,
            InitialDirectory = Path.Combine(AppContext.BaseDirectory, "Data")
        };
        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        var result = _service.LoadGift(dialog.FileName);
        if (!result.Success)
        {
            ShowError(result.ErrorMessage);
            return;
        }

        _sugarFilter = null;
        ShowGiftName();
        RefreshGift();
        SetStatus($"Загружен подарок: {Path.GetFileName(dialog.FileName)}");
    }

    private void saveItem_Click(object? sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog
        {
            Title = "Сохранить подарок",
            Filter = JsonFilter,
            FileName = "gift.json",
            DefaultExt = "json",
            InitialDirectory = Path.Combine(AppContext.BaseDirectory, "Export")
        };
        if (!Directory.Exists(dialog.InitialDirectory))
            dialog.InitialDirectory = AppContext.BaseDirectory;
        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        var result = _service.SaveGift(dialog.FileName);
        if (!result.Success)
        {
            ShowError(result.ErrorMessage);
            return;
        }

        SetStatus($"Подарок сохранён: {dialog.FileName}");
    }

    private void exportItem_Click(object? sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog
        {
            Title = "Экспорт отчёта",
            Filter = "Текстовый файл (*.txt)|*.txt",
            FileName = "gift_report.txt",
            DefaultExt = "txt"
        };
        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        var result = _service.ExportReport(dialog.FileName);
        if (!result.Success)
        {
            ShowError(result.ErrorMessage);
            return;
        }

        SetStatus($"Отчёт сохранён: {dialog.FileName}");
    }

    private void exitItem_Click(object? sender, EventArgs e) => Close();

    // ---------- Сообщения ----------

    private void SetStatus(string text) => statusLabel.Text = text;

    private void ShowError(string message) =>
        MessageBox.Show(this, message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
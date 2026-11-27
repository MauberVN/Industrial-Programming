using System.Globalization;
using BusinessLayer.Sweets;

namespace DataLayer;

internal static class SweetListView
{
    public static ListView Create()
    {
        var list = new ListView
        {
            Dock = DockStyle.Fill,
            View = View.Details,
            FullRowSelect = true,
            GridLines = true,
            HideSelection = false,
            MultiSelect = false
        };

        list.Columns.Add("Категория", 130);
        list.Columns.Add("Название", 170);
        list.Columns.Add("Вес, г", 60, HorizontalAlignment.Right);
        list.Columns.Add("Сахар, г", 70, HorizontalAlignment.Right);
        list.Columns.Add("ккал/100 г", 80, HorizontalAlignment.Right);
        list.Columns.Add("ккал (шт.)", 75, HorizontalAlignment.Right);
        list.Columns.Add("Особенности", 200);
        return list;
    }

    public static ListViewItem ToItem(Sweet sweet)
    {
        var culture = CultureInfo.CurrentCulture;
        var item = new ListViewItem(sweet.Category) { Tag = sweet };
        item.SubItems.Add(sweet.Name);
        item.SubItems.Add(sweet.WeightGrams.ToString("F1", culture));
        item.SubItems.Add(sweet.SugarGrams.ToString("F2", culture));
        item.SubItems.Add(sweet.CaloriesPer100G.ToString("F0", culture));
        item.SubItems.Add(sweet.Calories.ToString("F0", culture));
        item.SubItems.Add(sweet.Details);
        return item;
    }

    public static Sweet? Selected(ListView list) =>
        list.SelectedItems.Count > 0 ? list.SelectedItems[0].Tag as Sweet : null;
}
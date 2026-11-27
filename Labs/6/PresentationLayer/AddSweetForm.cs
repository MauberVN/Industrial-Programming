using BusinessLayer.Sweets;
using ServiceLayer;

namespace PresentationLayer;

public sealed partial class AddSweetForm : Form
{
    private readonly Service _service;

    private readonly List<(SweetKind[] Kinds, Control[] Controls)> _kindRows = [];

    public AddSweetForm(Service service)
    {
        _service = service;

        InitializeComponent();

        kindCombo.Items.AddRange(_service.GetCategories().Cast<object>().ToArray());

        Bind(new Control[] { cocoaLabel, cocoaBox }, SweetKind.ChocolateCandy, SweetKind.ChocolateBar);
        Bind(new Control[] { fillingLabel, fillingBox }, SweetKind.ChocolateCandy);
        Bind(new Control[] { flavorLabel, flavorBox }, SweetKind.Lollipop);
        Bind(new Control[] { hasFillingLabel, hasFillingCheck }, SweetKind.Caramel);
        Bind(new Control[] { fruitBaseLabel, fruitBaseBox }, SweetKind.JellyCandy);
        Bind(new Control[] { hasNutsLabel, hasNutsCheck }, SweetKind.Cookie);
        Bind(new Control[] { colorLabel, colorBox }, SweetKind.Marshmallow);

        kindCombo.SelectedIndex = 0;
    }

    public Sweet? CreatedSweet { get; private set; }

    private SweetKind SelectedKind => Enum.GetValues<SweetKind>()[kindCombo.SelectedIndex];

    private void Bind(Control[] controls, params SweetKind[] kinds) => _kindRows.Add((kinds, controls));

    private void kindCombo_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var kind = SelectedKind;
        foreach (var (kinds, controls) in _kindRows)
        {
            var visible = kinds.Contains(kind);
            foreach (var control in controls)
                control.Visible = visible;
        }
    }

    private void okButton_Click(object? sender, EventArgs e)
    {
        var draft = new SweetDraft
        {
            Kind = SelectedKind,
            Name = nameBox.Text,
            WeightGrams = (double)weightBox.Value,
            SugarGrams = (double)sugarBox.Value,
            CaloriesPer100G = (double)caloriesBox.Value,
            CocoaPercent = (double)cocoaBox.Value,
            Filling = fillingBox.Text,
            Flavor = flavorBox.Text,
            HasFilling = hasFillingCheck.Checked,
            FruitBase = fruitBaseBox.Text,
            HasNuts = hasNutsCheck.Checked,
            Color = colorBox.Text
        };

        var created = _service.CreateSweet(draft);
        if (!created.Success)
        {
            ShowErrors(created);
            return;
        }

        var added = _service.AddSweetToCatalog(created.Value!);
        if (!added.Success)
        {
            ShowErrors(added);
            return;
        }

        CreatedSweet = created.Value;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void ShowErrors(OperationResult result) =>
        MessageBox.Show(this, result.ErrorMessage, "Проверьте введённые данные",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
}
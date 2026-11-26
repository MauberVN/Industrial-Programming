namespace BusinessLayer.Sweets;

public enum SweetKind
{
    ChocolateCandy,
    Lollipop,
    Caramel,
    JellyCandy,
    Cookie,
    ChocolateBar,
    Marshmallow
}

public static class SweetCategories
{
    public const string ChocolateCandy = "Шоколадная конфета";
    public const string Lollipop = "Леденец";
    public const string Caramel = "Карамель";
    public const string JellyCandy = "Желейная конфета";
    public const string Cookie = "Печенье";
    public const string ChocolateBar = "Шоколад";
    public const string Marshmallow = "Зефир";

    public static string Of(SweetKind kind) => kind switch
    {
        SweetKind.ChocolateCandy => ChocolateCandy,
        SweetKind.Lollipop => Lollipop,
        SweetKind.Caramel => Caramel,
        SweetKind.JellyCandy => JellyCandy,
        SweetKind.Cookie => Cookie,
        SweetKind.ChocolateBar => ChocolateBar,
        SweetKind.Marshmallow => Marshmallow,
        _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, null)
    };

    public static IReadOnlyList<string> All { get; } =
        Enum.GetValues<SweetKind>().Select(Of).ToArray();
}
namespace BusinessLayer.Validation;

public sealed class BusinessRule
{
    public BusinessRule(string propertyName, string description)
    {
        PropertyName = propertyName;
        Description = description;
    }

    public string PropertyName { get; }
    public string Description { get; }

    public override string ToString() => $"{PropertyName}: {Description}";
}
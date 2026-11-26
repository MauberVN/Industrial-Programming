namespace BusinessLayer.Validation;

public abstract class BusinessObject
{
    private readonly List<BusinessRule> _brokenRules = [];

    public IReadOnlyList<BusinessRule> BrokenRules
    {
        get
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules.ToArray();
        }
    }

    public bool IsValid => BrokenRules.Count == 0;

    public void EnsureValid()
    {
        var rules = BrokenRules;
        if (rules.Count > 0)
            throw new BusinessValidationException(rules);
    }

    protected abstract void Validate();

    protected void AddBrokenRule(string propertyName, string description) =>
        _brokenRules.Add(new BusinessRule(propertyName, description));
}
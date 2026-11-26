namespace BusinessLayer.Validation;

public class BusinessValidationException : Exception
{
    public BusinessValidationException(IEnumerable<BusinessRule> brokenRules)
        : this(brokenRules.ToArray())
    {
    }

    private BusinessValidationException(BusinessRule[] brokenRules)
        : base(string.Join(" ", brokenRules.Select(r => r.Description)))
    {
        BrokenRules = brokenRules;
    }

    public IReadOnlyList<BusinessRule> BrokenRules { get; }
}
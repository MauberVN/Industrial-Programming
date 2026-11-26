namespace ServiceLayer;

public class OperationResult
{
    protected OperationResult(IReadOnlyList<string> errors)
    {
        Errors = errors;
    }

    public IReadOnlyList<string> Errors { get; }
    public bool Success => Errors.Count == 0;
    public string ErrorMessage => string.Join(Environment.NewLine, Errors);

    public static OperationResult Ok() => new([]);
    public static OperationResult Fail(params string[] errors) => new(errors);
    public static OperationResult Fail(IEnumerable<string> errors) => new(errors.ToArray());
}

public sealed class OperationResult<T> : OperationResult
{
    private OperationResult(T? value, IReadOnlyList<string> errors) : base(errors)
    {
        Value = value;
    }

    public T? Value { get; }

    public static OperationResult<T> Ok(T value) => new(value, []);
    public new static OperationResult<T> Fail(params string[] errors) => new(default, errors);
    public new static OperationResult<T> Fail(IEnumerable<string> errors) => new(default, errors.ToArray());
}
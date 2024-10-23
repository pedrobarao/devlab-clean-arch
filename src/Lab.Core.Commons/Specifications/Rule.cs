namespace Lab.Core.Commons.Specifications;

public class Rule<T>
{
    private readonly Specification<T> _specificationSpec;

    public Rule(Specification<T> spec, string errorMessage)
    {
        _specificationSpec = spec;
        ErrorMessage = errorMessage;
    }

    public string ErrorMessage { get; private set; }

    public bool Validate(T obj)
    {
        return _specificationSpec.IsSatisfiedBy(obj);
    }
}
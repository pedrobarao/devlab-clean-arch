namespace Lab.Core.Commons.Specifications;

public abstract class SpecificationValidator<T> where T : class
{
    private readonly Dictionary<string, Rule<T>> _validationRules = new();

    public ValidationResult Validate(T obj)
    {
        ValidationResult validationResult = new();

        foreach (var validationRule in _validationRules)
        {
            var validation = validationRule.Value;

            if (!validation.Validate(obj))
                validationResult.Errors.Add(new Failure
                (
                    validation.ErrorMessage,
                    validationRule.Key,
                    obj.GetType().Name
                ));
        }

        return validationResult;
    }

    protected void Add(string name, Rule<T> rule)
    {
        _validationRules.Add(name, rule);
    }

    protected void Remove(string name)
    {
        _validationRules.Remove(name);
    }

    protected Rule<T> GetRule(string name)
    {
        _validationRules.TryGetValue(name, out var rule);
        return rule;
    }
}
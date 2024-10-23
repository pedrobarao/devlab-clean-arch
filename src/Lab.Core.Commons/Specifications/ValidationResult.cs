namespace Lab.Core.Commons.Specifications;

public class ValidationResult
{
    public List<Failure> Errors { get; } = new();
    public bool IsValid => !Errors.Any();
}
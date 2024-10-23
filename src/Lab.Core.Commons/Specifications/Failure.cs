namespace Lab.Core.Commons.Specifications;

public class Failure
{
    public Failure(string errorMessage, string ruleName = null!, string entityName = null!)
    {
        ErrorMessage = errorMessage;
        RuleName = ruleName;
        EntityName = entityName;
    }

    public string ErrorMessage { get; set; }
    public string RuleName { get; set; }
    public string? EntityName { get; set; }
}
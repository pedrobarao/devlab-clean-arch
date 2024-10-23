namespace Lab.Customers.Domain.ValueObjects;

public record Name
{
    protected Name()
    {
    }

    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
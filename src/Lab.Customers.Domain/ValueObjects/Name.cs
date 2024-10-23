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

    public string FirstName { get; init; }
    public string LastName { get; init; }

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
using Lab.Core.Commons.Specifications;

namespace Lab.Core.Commons.Communication;

public class Result
{
    public Result()
    {
    }

    protected Result(string? error = null)
    {
        if (error is not null) Errors.Add(error);
    }

    public bool IsSuccess => !Errors.Any();
    public IList<string> Errors { get; } = [];

    public static Result Ok()
    {
        return new Result();
    }

    public static Result Fail(string error)
    {
        return new Result(error);
    }

    public void AddError(string error)
    {
        Errors.Add(error);
    }

    public void ClearErrors()
    {
        Errors.Clear();
    }

    public void AddErrors(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors) Errors.Add(error.ErrorMessage);
    }

    public void AddErrors(IEnumerable<string> errors)
    {
        foreach (var error in errors) Errors.Add(error);
    }
}

public class Result<TData> : Result
{
    public Result()
    {
    }

    private Result(TData data, string? error = null) : base(error)
    {
        Data = data;

        if (error is not null) Errors.Add(error);
    }

    public TData Data { get; private set; }

    public static Result<TData> Ok(TData data)
    {
        return new Result<TData>(data);
    }

    public static Result<TData> Fail(string error)
    {
        return new Result<TData>(default!, error);
    }

    public void SetData(TData data)
    {
        Data = data;
    }
}
namespace Lab.Core.Commons.Specifications;

public abstract class Specification<T>
{
    public abstract bool IsSatisfiedBy(T entity);
}
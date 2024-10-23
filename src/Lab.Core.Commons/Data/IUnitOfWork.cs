namespace Lab.Core.Commons.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
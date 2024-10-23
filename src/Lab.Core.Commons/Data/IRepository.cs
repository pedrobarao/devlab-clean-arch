using Lab.Core.Commons.Entities;

namespace Lab.Core.Commons.Data;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}
using Ardalis.Specification;

namespace Oyster.ApplicationCore.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}

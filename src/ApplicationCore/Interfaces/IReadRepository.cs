using Ardalis.Specification;

namespace Oyster.ApplicationCore.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}

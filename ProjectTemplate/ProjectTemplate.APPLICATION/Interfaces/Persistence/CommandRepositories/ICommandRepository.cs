using ProjectTemplate.DOMAIN.SeedWork;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTemplate.APPLICATION.Interfaces.Persistence.CommandRepositories
{
    public interface ICommandRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        void Add(T item);
        T Remove(T item);
    }
}

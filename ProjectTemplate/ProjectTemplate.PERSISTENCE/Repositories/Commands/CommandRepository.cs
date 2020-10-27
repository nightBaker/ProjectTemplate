using Microsoft.EntityFrameworkCore;
using ProjectTemplate.APPLICATION.Interfaces.Persistence;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.CommandRepositories;
using ProjectTemplate.DOMAIN.AggregatesModel.SomeAggregate;
using ProjectTemplate.DOMAIN.SeedWork;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTemplate.PERSISTENCE.Repositories.Commands
{
    public class CommandRepository<T> : ICommandRepository<T> where T : class, IAggregateRoot
    {
        private readonly SomeDbContext _context;
        private readonly DbSet<T> _dbSet;

        public CommandRepository(SomeDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            UnitOfWork = unitOfWork;
            this._dbSet = _context.Set<T>();
        }

        public IUnitOfWork UnitOfWork { get; }

        public void Add(T item) => _dbSet.Add(item);

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate) =>
            _dbSet.FirstOrDefaultAsync(predicate);

        public T Remove(T item) => _dbSet.Remove(item).Entity;
    }
}

using Microsoft.EntityFrameworkCore;
using ProjectTemplate.APPLICATION.Interfaces.Persistence;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.CommandRepositories;
using ProjectTemplate.DOMAIN.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
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
            GetAggreagteQueryable().FirstOrDefaultAsync(predicate);

        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate) =>
            GetAggreagteQueryable().Where(predicate).ToListAsync();

        public T Remove(T item) => _dbSet.Remove(item).Entity;

        protected virtual IQueryable<T> GetAggreagteQueryable() => _dbSet;
    }
}

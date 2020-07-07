using Microsoft.EntityFrameworkCore;
using ProjectTemplate.APPLICATION.Interfaces.Persistence;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.CommandRepositories;
using ProjectTemplate.DOMAIN.AggregatesModel.SomeAggregate;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTemplate.PERSISTENCE.Repositories.Commands
{
    public class SomeCommandRepository : ISomeCommandRepository
    {
        readonly SomeDbContext _context;
        public IUnitOfWork UnitOfWork { get; }

        public SomeCommandRepository(SomeDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            UnitOfWork = unitOfWork;
        }

        public void Add(Some item)
        {
            _context.Somes.Add(item);
        }

        public async Task<Some> GetAsync(Expression<Func<Some, bool>> predicate)
        {
            return await _context.Somes.FirstOrDefaultAsync(predicate);
        }

        public Some Remove(Some item)
        {
            return _context.Somes.Remove(item).Entity;
        }
    }
}

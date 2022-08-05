using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.APPLICATION.Dtos.Queries;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.QueryServices;
using Sieve.Models;
using Sieve.Services;

namespace ProjectTemplate.PERSISTENCE.QueryServices
{
    public class QueryService<TEntity, T> : IQueryService<TEntity, T> where TEntity : class
    {
        readonly ProjectTemplateDbContext _context;
        readonly IMapper _mapper;
        readonly ISieveProcessor _sieveProcessor;
        readonly DbSet<TEntity> _dbSet;

        public QueryService(ProjectTemplateDbContext context, IMapper mapper, ISieveProcessor sieveProcessor)
        {
            _context = context;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<ListResultsDto<T>> GetAllAsync(SieveModel sieveModel)
        {
            var entities = GetAggreagteQueryable().AsNoTracking();
            entities = _sieveProcessor.Apply(sieveModel, entities);
            var sievedEntities = await entities.ToListAsync();

            return new ListResultsDto<T>
            {
                Items = sievedEntities.Select(entity => _mapper.Map<TEntity, T>(entity)).ToList(),
                TotalCount = await entities.CountAsync()
            };
        }

        public async Task<T> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await GetAggreagteQueryable().FirstOrDefaultAsync(predicate);
            return _mapper.Map<TEntity, T>(entity);
        }

        protected virtual IQueryable<TEntity> GetAggreagteQueryable() => _dbSet;
    }
}

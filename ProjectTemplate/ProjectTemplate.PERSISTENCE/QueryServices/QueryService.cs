using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.APPLICATION.Dtos.Queries;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.QueryRepositories;
using Sieve.Models;
using Sieve.Services;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTemplate.PERSISTENCE.Services.Queries
{
    public class QueryService<TEntity, T> : IQueryService<TEntity, T> where TEntity : class
    {
        readonly SomeDbContext _context;
        readonly IMapper _mapper;
        readonly ISieveProcessor _sieveProcessor;
        readonly DbSet<TEntity> _dbSet;

        public QueryService(SomeDbContext context, IMapper mapper, ISieveProcessor sieveProcessor)
        {
            _context = context;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<ListResultsDto<T>> GetAllAsync(SieveModel sieveModel)
        {
            var somes = _dbSet.AsNoTracking();
            somes = _sieveProcessor.Apply(sieveModel, somes);
            var sievedSomes = await somes.ToListAsync();

            return new ListResultsDto<T>
            {
                Items = sievedSomes.Select(some => _mapper.Map<TEntity, T>(some)).ToList(),
                TotalCount = await somes.CountAsync()
            };
        }


        public async Task<T> GetAsync(long Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            return _mapper.Map<TEntity, T>(entity);
        }


    }
}

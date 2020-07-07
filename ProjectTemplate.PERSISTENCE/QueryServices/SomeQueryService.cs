using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.APPLICATION.Dtos.Queries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.Something;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.SomethingList;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.QueryRepositories;
using ProjectTemplate.DOMAIN.AggregatesModel.SomeAggregate;
using Sieve.Models;
using Sieve.Services;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTemplate.PERSISTENCE.Services.Queries
{
    public class SomeQueryService : ISomeQueryService
    {
        readonly SomeDbContext _context;
        readonly IMapper _mapper;
        readonly ISieveProcessor _sieveProcessor;       

        public SomeQueryService(SomeDbContext context, IMapper mapper, ISieveProcessor sieveProcessor)
        {
            _context = context;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public async Task<SomethingListDto> GetAll(SieveModel sieveModel)
        {
            var somes = _context.Somes.AsNoTracking();
            somes = _sieveProcessor.Apply(sieveModel, somes);
            var sievedSomes = await somes.ToListAsync();

            return new SomethingListDto
            {
                Items = sievedSomes.Select(some => _mapper.Map<Some, SomeDto>(some)).ToList(),
                TotalCount = await somes.CountAsync()
            };
        }
        

        public async Task<SomeDto> GetAsync(long Id)
        {
            var some = await _context.Somes.FirstAsync(s => s.Id == Id);
            return new SomeDto { Id = some.Id, SomeEnum = some.SomeEnum };
        }

        Task<SomeDto> ISomeQueryService.GetAsync(long Id)
        {
            throw new System.NotImplementedException();
        }
    }
}

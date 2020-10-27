using MediatR;
using ProjectTemplate.APPLICATION.Dtos.Queries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.Something;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.SomethingList;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.QueryRepositories;
using ProjectTemplate.DOMAIN.AggregatesModel.SomeAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTemplate.APPLICATION.Queries.SomeQueries
{
    public class SomethingQueryHandler : IRequestHandler<SomethingQuery, SomeDto>
    {
        public IQueryService<Some, SomeDto> _queryService;
        public SomethingQueryHandler(IQueryService<Some, SomeDto> queryService)
        {
            _queryService = queryService;
        }
        public Task<SomeDto> Handle(SomethingQuery request, CancellationToken cancellationToken)
        {
            return _queryService.GetAsync(request.SomeId);
        }
    }
}

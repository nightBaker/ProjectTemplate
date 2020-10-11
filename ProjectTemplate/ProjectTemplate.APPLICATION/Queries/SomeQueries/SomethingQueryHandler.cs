using MediatR;
using ProjectTemplate.APPLICATION.Dtos.Queries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.Something;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.SomethingList;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.QueryRepositories;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTemplate.APPLICATION.Queries.SomeQueries
{
    public class SomethingQueryHandler : IRequestHandler<SomethingQuery, SomeDto>
    {
        public ISomeQueryService _queryService;
        public SomethingQueryHandler(ISomeQueryService queryService)
        {
            _queryService = queryService;
        }
        public async Task<SomeDto> Handle(SomethingQuery request, CancellationToken cancellationToken)
        {
            return await _queryService.GetAsync(request.SomeId);
        }
    }
}

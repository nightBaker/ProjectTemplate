using MediatR;
using ProjectTemplate.APPLICATION.Dtos.Queries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.SomethingList;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.QueryRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTemplate.APPLICATION.Queries.SomeQueries
{
    public class SomethingListQueryHandler : IRequestHandler<SomethingListQuery, ListResultsDto<SomeDto>>
    {
        public ISomeQueryService _queryService;
        public SomethingListQueryHandler(ISomeQueryService queryService)
        {
            _queryService = queryService;
        }
        public async Task<ListResultsDto<SomeDto>> Handle(SomethingListQuery request, CancellationToken cancellationToken)
        {
            return await _queryService.GetAll(request);
        }
    }
}

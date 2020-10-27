using MediatR;
using ProjectTemplate.APPLICATION.Dtos.Queries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.SomethingList;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.QueryRepositories;
using ProjectTemplate.DOMAIN.AggregatesModel.SomeAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTemplate.APPLICATION.Queries.SomeQueries
{
    public class SomethingListQueryHandler : IRequestHandler<SomethingListQuery, ListResultsDto<SomeDto>>
    {
        public IQueryService<Some,SomeDto> _queryService;
        public SomethingListQueryHandler(IQueryService<Some, SomeDto> queryService)
        {
            _queryService = queryService;
        }
        public  Task<ListResultsDto<SomeDto>> Handle(SomethingListQuery request, CancellationToken cancellationToken)
        {
            return  _queryService.GetAllAsync(request);
        }
    }
}

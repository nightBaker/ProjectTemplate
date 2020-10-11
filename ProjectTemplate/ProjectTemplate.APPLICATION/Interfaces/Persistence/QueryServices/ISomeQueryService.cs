using ProjectTemplate.APPLICATION.Dtos.Queries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.Something;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.SomethingList;
using Sieve.Models;
using System.Threading.Tasks;

namespace ProjectTemplate.APPLICATION.Interfaces.Persistence.QueryRepositories
{
    public interface ISomeQueryService
    {
        Task<SomeDto> GetAsync(long Id);
        Task<SomethingListDto> GetAll(SieveModel sieveModel);
    }
}

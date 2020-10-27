using ProjectTemplate.APPLICATION.Dtos.Queries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.Something;
using ProjectTemplate.APPLICATION.Dtos.Queries.SomeQueries.SomethingList;
using Sieve.Models;
using System.Threading.Tasks;

namespace ProjectTemplate.APPLICATION.Interfaces.Persistence.QueryRepositories
{
    public interface IQueryService<TEntity, T>
    {
        Task<T> GetAsync(long Id);
        Task<ListResultsDto<T>> GetAllAsync(SieveModel sieveModel);
    }
}

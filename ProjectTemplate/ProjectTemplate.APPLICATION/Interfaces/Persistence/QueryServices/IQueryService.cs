using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjectTemplate.APPLICATION.Dtos.Queries;
using Sieve.Models;

namespace ProjectTemplate.APPLICATION.Interfaces.Persistence.QueryServices
{
    public interface IQueryService<TEntity, T>
    {
        Task<T> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ListResultsDto<T>> GetAllAsync(SieveModel sieveModel);
    }
}

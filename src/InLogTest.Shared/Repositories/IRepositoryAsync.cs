using InLogTest.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InLogTest.Shared.Repositories
{
    public interface IRepositoryAsync<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}

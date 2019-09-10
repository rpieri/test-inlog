using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InLogTest.Repository.Contexts;
using InLogTest.Shared.Models;
using InLogTest.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InLogTest.Repository.Repositories
{
    public abstract class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : Entity
    {
        protected readonly DbSet<TEntity> dbSet;
        protected readonly EntityContext context;
        public RepositoryAsync(EntityContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity) => await dbSet.AddAsync(entity);

        public async Task UpdateAsync(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await Task.Run(() => dbSet.Update(entity));
        }

        public async Task DeleteAsync(TEntity entity)
        {
            entity.Delete();
            await UpdateAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAsync() => await dbSet.Where(x => !x.Deleted).ToListAsync();

        public async Task<TEntity> GetAsync(int id) => await dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id) && !x.Deleted);
    }
}

using System.Threading.Tasks;
using InLogTest.Repository.Contexts;
using InLogTest.Shared.Interface;

namespace InLogTest.Repository.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext context;

        public UnitOfWork(EntityContext context)
        {
            this.context = context;
        }

        public async Task<bool> CommitAsnyc() => await context.SaveChangesAsync() > 0;

        public void Dispose() => context.Dispose();
    }
}

using System;
using System.Threading.Tasks;

namespace InLogTest.Shared.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsnyc();
    }
}

using System;
using System.Threading.Tasks;

namespace BookHaven.Core.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        void Rollback();
        void Commit();
        Task CommitAsync();
    }
}

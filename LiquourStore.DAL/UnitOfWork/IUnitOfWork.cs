using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiquourStore.DAL.Repositories;

namespace LiquorStore.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        int Complete();
        Task<int> CompleteAsync();
        Task DisposeAsync();
    }
}

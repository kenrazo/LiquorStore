using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.DAL.Repositories;
using LiquourStore.DAL.Repositories;

namespace LiquorStore.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ILiquorRepository Liquors { get; }
        int Complete();
        Task<int> CompleteAsync();
        Task DisposeAsync();
    }
}

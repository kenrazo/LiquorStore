using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.DAL.Repositories;
using LiquourStore.DAL.Context;
using LiquourStore.DAL.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LiquorStore.DAL.UnitOfWork
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="LiquorStore.DAL.UnitOfWork.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository Users { get; }
        public ILiquorRepository Liquors { get; }
        private readonly LiquorStoreContext _context;

        public UnitOfWork(LiquorStoreContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Liquors = new LiquorRepository(_context);
        }

        /// <summary>
        /// Completes this instance.
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {
            return _context.SaveChanges();
        }
        /// <summary>
        /// Completes the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
        /// <summary>
        /// Disposes the asynchronous.
        /// </summary>
        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}

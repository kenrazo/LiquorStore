using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiquourStore.DAL.Context;
using LiquourStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiquourStore.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly LiquorStoreContext _context;
        public UserRepository(LiquorStoreContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> Authenticate(string username, string password)
        {
            var a = await _context.Users.ToListAsync();
            return true;
        }


    }
}

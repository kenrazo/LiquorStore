using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.DAL.Entities.DatabaseEntities;

namespace LiquourStore.DAL.Repositories
{
    public interface IUserRepository : IRepositoryBase<User, int>
    {
        Task<User> Authenticate(string username, string password);
    }
}

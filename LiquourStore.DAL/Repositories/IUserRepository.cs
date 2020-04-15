using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiquourStore.DAL.Entities;

namespace LiquourStore.DAL.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<bool> Authenticate(string username, string password);
    }
}

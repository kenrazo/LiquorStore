using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Business.LogicCollection
{
    public interface IUserBusiness
    {
        Task<bool> Authenticate(string username, string password);
    }
}

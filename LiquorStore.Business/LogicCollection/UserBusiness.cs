using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiquourStore.DAL.Repositories;

namespace LiquorStore.Business.LogicCollection
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            return await _userRepository.Authenticate(username, password);
        }
    }
}

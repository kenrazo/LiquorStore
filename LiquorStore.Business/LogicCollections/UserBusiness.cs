using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.Business.Dtos;
using LiquorStore.DAL.UnitOfWork;
using LiquourStore.DAL.Entities;
using LiquourStore.DAL.Repositories;

namespace LiquorStore.Business.LogicCollection
{
    /// <summary>
    /// The user business
    /// </summary>
    /// <seealso cref="LiquorStore.Business.LogicCollection.IUserBusiness" />
    public class UserBusiness : IUserBusiness
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UserBusiness(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        /// <summary>
        /// Authenticates the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<AuthenticationOutputDto> Authenticate(AuthenticationInputDto input)
        {
            var result = new AuthenticationOutputDto();

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var a = unitOfWork.User.Authenticate(input.Username, input.Password);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.Business.Dtos;

namespace LiquorStore.Business.LogicCollection
{
    /// <summary>
    /// User business
    /// </summary>
    public interface IUserBusiness
    {
        /// <summary>
        /// Logouts this instance.
        /// </summary>
        /// <returns></returns>
        Task Logout();
        /// <summary>
        /// Authenticates the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        Task<AuthenticationOutputDto> Authenticate(AuthenticationInputDto input);
    }
}

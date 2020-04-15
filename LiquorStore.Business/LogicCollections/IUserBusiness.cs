using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.Business.Dtos;

namespace LiquorStore.Business.LogicCollection
{
    public interface IUserBusiness
    {
        Task<AuthenticationOutputDto> Authenticate(AuthenticationInputDto input);
    }
}

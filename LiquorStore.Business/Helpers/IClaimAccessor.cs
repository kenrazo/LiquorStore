using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.Business.Dtos.Auth;

namespace LiquorStore.Business.Helpers
{
    public interface IClaimAccessor
    {
        Task<RequestInformationOutputDto> GetClaims();
    }
}

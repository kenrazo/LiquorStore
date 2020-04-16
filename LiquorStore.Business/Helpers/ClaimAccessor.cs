using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LiquorStore.Business.Dtos.Auth;
using Microsoft.AspNetCore.Http;

namespace LiquorStore.Business.Helpers
{
    /// <summary>
    /// Claims
    /// </summary>
    /// <seealso cref="LiquorStore.Business.Helpers.IClaimAccessor" />
    public class ClaimAccessor : IClaimAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Gets the claims.
        /// </summary>
        /// <returns></returns>
        public async Task<RequestInformationOutputDto> GetClaims()
        {
            //put all data that is almost never changing in claims
            var userId = Convert.ToInt64(_httpContextAccessor.HttpContext.User.FindFirst("UserId")?.Value);
            var username = _httpContextAccessor.HttpContext.User.FindFirst("Username")?.Value;
            var result = new RequestInformationOutputDto
            {
                UserId = userId
            };

            return await Task.FromResult(result);
        }
    }
}

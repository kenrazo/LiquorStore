using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiquorStore.Business.Dtos;
using LiquorStore.Business.LogicCollection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiquorStore.Controllers
{
    /// <summary>
    /// Source end point form user.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticationInputDto input)
        {
            await _userBusiness.Authenticate(input);
            return Ok();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiquorStore.Business.Dtos;
using LiquorStore.Business.LogicCollections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LiquorStore.Controllers
{
    /// <summary>
    /// Liquor Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LiquorController : ControllerBase
    {
        private readonly ILiquorBusiness _liquorBusiness;

        public LiquorController(ILiquorBusiness liquorBusiness)
        {
            _liquorBusiness = liquorBusiness;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PaginatedInputDto input)
        {
            var resultObject = await _liquorBusiness.GetPaginatedData(input);
            var xPaginationJsonOutput = JsonConvert.SerializeObject(resultObject.Information);
            Response.Headers.Add("Pagination", xPaginationJsonOutput);
            return Ok(resultObject.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LiquorInputDto input)
        {
            await _liquorBusiness.Add(input);
            return Created(String.Empty, null);
        }
    }
}
using LiquorStore.Business.LogicCollection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiquorStore.Business.Dtos;

namespace LiquorStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserBusiness userBusiness)
        {
            _logger = logger;
            _userBusiness = userBusiness;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            //  var a = await _userBusiness.Authenticate("test", "test");
            var a = await _userBusiness.Authenticate(new AuthenticationInputDto()
            {
                Username = "qwe",
                Password = "asd"
            });
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

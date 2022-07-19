using Cache.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cache.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICacheStore _cacheStore;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICacheStore cacheStore)
        {
            _logger = logger;
            _cacheStore = cacheStore;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var myDummyKey = new Utils.Keys.Dummy(1234);
            var dummyCache = _cacheStore.Get(myDummyKey);

            if (dummyCache == null)
            {
                dummyCache = new Utils.Keys.DummyBase(); //create new object from DB/Source/etc...
                _cacheStore.Add(dummyCache, myDummyKey);
            }

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

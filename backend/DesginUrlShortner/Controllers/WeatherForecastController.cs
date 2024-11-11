using Microsoft.AspNetCore.Mvc;

namespace DesginUrlShortner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IConfiguration configuration) : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var connectionString = configuration["MONGO_DB_CONNECTIONSTRING"];
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = connectionString
            })
            .ToArray();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebAPI2;

namespace WebAPI2.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecast forecast)
        {
            // Add data to storage (e.g., database)
            return Ok(forecast);
        }
        private static List<WeatherForecast> _forecasts = new List<WeatherForecast>();

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WeatherForecast forecast)
        {
            var existingForecast = _forecasts.FirstOrDefault(f => f.Date == forecast.Date);
            if (existingForecast == null)
            {
                return NotFound();
            }

            // update fields
            existingForecast.TemperatureC = forecast.TemperatureC;
            existingForecast.Summary = forecast.Summary;

            return NoContent();

          
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Id == id);
            if (forecast == null)
            {
                return NotFound(); // 404 if not found
            }

            _forecasts.Remove(forecast);
            return NoContent(); // 204
        }
    }
}


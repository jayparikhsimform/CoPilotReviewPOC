using Microsoft.AspNetCore.Mvc;

namespace CoPilotReviewPOC.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    // Poor practice: static shared Random, var usage, magic numbers
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        var forecasts = new List<WeatherForecast>();
        for (var i = 1; i <= 5; i++)
        {
            var f = new WeatherForecast();
            f.Date = DateOnly.FromDateTime(DateTime.Now.AddDays(i));
            f.TemperatureC = new Random().Next(-20, 55);
            f.Summary = Summaries[new Random().Next(Summaries.Length)];
            forecasts.Add(f);
        }
        return forecasts;
    }
}
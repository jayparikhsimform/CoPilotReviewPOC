using Microsoft.AspNetCore.Mvc;

namespace CoPilotReviewPOC.Controllers;

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

    /// <summary>
    /// Gets weather forecast for the next specified number of days with optional temperature unit
    /// </summary>
    /// <param name="days">Number of days to forecast (1-10)</param>
    /// <param name="unit">Temperature unit (C, F, or K)</param>
    /// <returns>Weather forecast data for the specified number of days</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<WeatherForecast>> Get([FromQuery] int days = 5, [FromQuery] string unit = "C")
    {
        // Validate input parameters
        if (days < 1 || days > 10)
        {
            _logger.LogWarning("Invalid days parameter received: {Days}", days);
            return BadRequest($"Days parameter must be between 1 and 10, received: {days}");
        }

        unit = unit.ToUpperInvariant();
        if (!new[] { "C", "F", "K" }.Contains(unit))
        {
            _logger.LogWarning("Invalid temperature unit received: {Unit}", unit);
            return BadRequest($"Invalid temperature unit: {unit}. Supported units are C, F, and K.");
        }

        _logger.LogInformation("Generating {Days} days of weather forecast in {Unit} units", days, unit);

        var forecasts = Enumerable.Range(1, days)
            .Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        return Ok(forecasts);
    }
}

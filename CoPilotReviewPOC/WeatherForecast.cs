namespace CoPilotReviewPOC;

/// <summary>
/// Represents a weather forecast with temperature information in different units
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// Gets or sets the date of the weather forecast
    /// </summary>
    public DateOnly Date { get; set; }

    private int _temperatureC;
    public int TemperatureC 
    { 
        get => _temperatureC;
        set => _temperatureC = value;
    }

    public double TemperatureF => 32 + (TemperatureC * 9 / 5.0);

    public double TemperatureK => TemperatureC + 273.15;

    public string? Summary { get; set; }

    public string GetTemperature(string unit) => unit.ToUpper() switch
    {
        "C" => $"{TemperatureC}°C",
        "F" => $"{TemperatureF:F1}°F",
        "K" => $"{TemperatureK:F1}K",
        _ => throw new ArgumentException("Invalid temperature unit. Use C, F, or K.", nameof(unit))
    };
}

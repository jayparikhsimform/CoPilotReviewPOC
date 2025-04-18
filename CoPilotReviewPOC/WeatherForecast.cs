namespace CoPilotReviewPOC;

public class WeatherForecast
{
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

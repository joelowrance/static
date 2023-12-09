using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Statics;

public class MyComplicatedBusinessService
{
    private readonly HttpClient _httpClient; 
    private readonly ILogger<MyComplicatedBusinessService> _logger;
    private readonly IWeatherService _weatherService;

    public MyComplicatedBusinessService(HttpClient httpClient, ILogger<MyComplicatedBusinessService> logger, IWeatherService weatherService)
    {
        _httpClient = httpClient;
        _logger = logger;
        _weatherService = weatherService;
    }
    
    public async Task SomeBusinessLogic()
    {
        // Do some business logic
        _logger.LogInformation("Doing some business logic");
        //load record from db
        var city = new City();
        //make some calculations
        city.Name = "Mobile, Al";

        // This is bad because it is static and it is hitting an external resource.
        // this class is not tightly coupled to the static class 
        // how would you test this with no internet connection?
        // what happens if this resource isn't free or was something more annoying like sending a fax.
        city.Temperature = await  _weatherService.GetTemperature(city.Name);

    }
}

public class BadStatic
{
    public static async Task<double?> GetTemperature(string city)
    {
        
        // From a testability standpoint this is bad.
        // This will hit an external resource which can cause things to slow down and in some cases could start to incur a 
        // cost.  It also requires that the remote resource be available from your machine, the CI/CD pipeline, etc.
        var http = new HttpClient();
        var weatherResponse = await http.GetAsync((
            "https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude={part}&appid={apiKey}"));

        var data = await weatherResponse.Content.ReadAsStringAsync();
        
        var weather = JsonSerializer.Deserialize<Weather>(data);

        return weather?.Temperature;
    }
}

public interface IWeatherService
{
    Task<double> GetTemperature(string city);    
}



public class WeatherService: IWeatherService
{
    public async Task<double> GetTemperature(string city)
    {
        return await BadStatic.GetTemperature("New York") ?? 0;
    }
}

public class FakeWeatherService: IWeatherService
{
    public Task<double> GetTemperature(string city)
    {
        return Task.FromResult(75d);
    }
}


public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public double? Temperature { get; set; }
}

public class Weather
{
    public double Temperature { get; set; }
}
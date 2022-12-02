using Ef_7_IMaterializationInterceptor.Context;
using Ef_7_IMaterializationInterceptor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ef_7_IMaterializationInterceptor.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ApplicationContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,ApplicationContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        
        Console.WriteLine("Inserting a new blog");
        _context.Posts.Add(new Post()
        {
            Content = "http://blogs.msdn.com/adonet",
            Title = "MSDN",
        });
        _context.SaveChanges();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}
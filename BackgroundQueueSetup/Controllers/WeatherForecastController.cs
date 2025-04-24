using BackgroundQueueSetup.BackgroundQueue.Interfaces;
using BackgroundQueueSetup.Models;
using BackgroundQueueSetup.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundQueueSetup.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(
    ISampleService sampleService
    ) : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

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

    [HttpPost("log")]
    public async Task<IActionResult> Send()
    {
        await sampleService.SendWithLog(new EmailMessage()
        {
            Body = "Halo",
            Subject = "Subject",
            To = "HAHA@GMAIL.COM"
        });
        return Accepted(new { message = "Email 已入队，后台处理中。" });
    }


}

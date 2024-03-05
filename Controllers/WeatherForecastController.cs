using AutoMapper;
using LaptopStoreAPI.Controllers.DTOs;
using LaptopStoreAPI.Persistence;
using LaptopStoreAPI.Persistence.Models;
using LaptopStoreAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LaptopStoreAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : GenericCrudController
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public WeatherForecastController(LaptopStoreRepository repository, IMapper mapper, IUnitOfWork uow):
        base(repository, mapper, uow)
    {
       
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetProcessor(int id)
    {
        var processor = await repository.GetEntityAsync<Processor>(id);
        var description = mapper.Map<Processor, LaptopShortDescription>(processor);
        return Ok(description);
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

    
}

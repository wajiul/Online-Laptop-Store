using AutoMapper;
using LaptopStoreAPI.Persistence.Repositories;
using LaptopStoreAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaptopStoreAPI.Persistence.Models;
using LaptopStoreAPI.Controllers.DTOs;

namespace LaptopStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopsController : GenericCrudController
    {
        public LaptopsController(LaptopStoreRepository repository, IMapper mapper, IUnitOfWork uow):
            base(repository, mapper, uow)
        {
            
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await repository.GetLaptopsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await repository.GetLaptopAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LaptopDto laptopDto)
        {
            var laptop = await base.Add<Laptop, LaptopDto>(laptopDto);
            
            return CreatedAtAction("Get", new { id = laptop.Id }, laptop);
        }
    }
}

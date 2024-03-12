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
            var result = await repository.GetLaptopsAsync();
            var laptops = result.Select(l => mapper.Map<Laptop, LaptopShortDescription>(l)).ToList();
            return Ok(laptops);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var laptop = await repository.GetLaptopAsync(id);
            var laptopCardInfo = mapper.Map<Laptop, LaptopShortDescription>(laptop);
            return Ok(laptopCardInfo);
        }
        [HttpGet("price/{start}/{end}")]
        public async Task<IActionResult> GetLaptopByPriceRange(int start, int end)
        {
            var result = await repository.GetLaptopsByPriceRangeAsync(start, end);
            var laptops = result.Select(l => mapper.Map<Laptop, LaptopShortDescription>(l)).ToList();
            return Ok(laptops);
        }

        [HttpGet("brand/{brand}")]
        public async Task<IActionResult> GetLaptopsByBrand(string brand)
        {
            var result = await repository.GetLaptopsByBrandAsync(brand);
            var laptops = result.Select(l => mapper.Map<Laptop, LaptopShortDescription>(l)).ToList();
            return Ok(laptops);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LaptopDto laptopDto)
        {
            var laptop = await base.Add<Laptop, LaptopDto>(laptopDto);
            
            return CreatedAtAction("Get", new { id = laptop.Id }, laptop);
        }
    }
}

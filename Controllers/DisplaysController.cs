using AutoMapper;
using LaptopStoreAPI.Controllers.DTOs;
using LaptopStoreAPI.Persistence;
using LaptopStoreAPI.Persistence.Models;
using LaptopStoreAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaptopStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisplaysController : GenericCrudController
    {
        public DisplaysController(LaptopStoreRepository repository, IMapper mapper, IUnitOfWork uow): 
            base(repository, mapper, uow)
        {
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await base.Get<Display>(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await base.GetAll<Display>();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DisplayDto displayDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var display = await base.Add<Display, DisplayDto>(displayDto);

            return CreatedAtAction("Get", new { id = display.Id }, display);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DisplayDto displayDto)
        {
            return await base.Update<Display, DisplayDto>(id, displayDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await base.Delete<Display, DisplayDto>(id);
        }

    }
}

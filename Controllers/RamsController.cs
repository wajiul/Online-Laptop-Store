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
    public class RamsController : GenericCrudController
    {
    

        public RamsController(LaptopStoreRepository repository, IMapper mapper, IUnitOfWork uow):
            base(repository, mapper, uow)
        {
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await base.Get<Ram>(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await base.GetAll<Ram>();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RamDto ramDto)
        {
            var ram = await base.Add<Ram, RamDto>(ramDto);

            return CreatedAtAction("Get", new { id = ram.Id }, ram);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RamDto ramDto)
        {
            return await base.Update<Ram, RamDto>(id, ramDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await base.Delete<Ram, RamDto>(id);
        }

    }
}

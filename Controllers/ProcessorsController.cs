using AutoMapper;
using LaptopStoreAPI.Controllers.DTOs;
using LaptopStoreAPI.Persistence.Models;
using LaptopStoreAPI.Persistence;
using LaptopStoreAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Data.SqlClient;

namespace LaptopStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessorsController : GenericCrudController
    {

        public ProcessorsController(LaptopStoreRepository repository, IMapper mapper, IUnitOfWork uow): 
            base(repository, mapper, uow)
        {
      
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await base.Get<Processor>(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            return await base.GetAll<Processor>();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProcessorDto processorDto)
        {
            var processor =  await base.Add<Processor, ProcessorDto>(processorDto);
            return CreatedAtAction("Get", new { id = processor.Id }, processor);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProcessorDto processorDto)
        {
            return await base.Update<Processor, ProcessorDto>(id, processorDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await base.Delete<Processor, ProcessorDto>(id);
        }

    }
}

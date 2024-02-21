using AutoMapper;
using LaptopStoreAPI.Controllers.DTOs;
using LaptopStoreAPI.Models;
using LaptopStoreAPI.Persistence;
using LaptopStoreAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace LaptopStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessorsController : ControllerBase
    {
    
        private readonly LaptopStoreRepository repository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public ProcessorsController(LaptopStoreRepository repository, IMapper mapper, IUnitOfWork uow)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProcessor(int id)
        {
            var processor = await repository.GetProcessorAsync(id);
            if(processor == null)
            {
                return NotFound();
            }
            return Ok(processor);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var result = await repository.GetAllProcessorsAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProcessorDto processorDto)
        {
            var processor = mapper.Map<ProcessorDto, Processor>(processorDto);

            await repository.AddProcessorAsync(processor);
            await uow.Complete();

            return CreatedAtAction("GetProcessor", new { id = processor.Id }, processor);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] ProcessorDto processorDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            try
            {
                var processor = mapper.Map<ProcessorDto, Processor>(processorDto);
                processor.Id = id;

                repository.UpdateProcessor(processor);
                await uow.Complete();

                return Ok("Data updated successfully");
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while updating data.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id,[FromBody] ProcessorDto processorDto)
        {
            try
            {
                var processor =  mapper.Map<ProcessorDto, Processor>(processorDto);
                processor.Id = id;

                repository.DeleteProcessor(processor);
                await uow.Complete();

                return Ok("Data deleted successfully.");
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while deleting data.");
            }
        }

    }
}

using AutoMapper;
using LaptopStoreAPI.Controllers.DTOs;
using LaptopStoreAPI.Exceptions;
using LaptopStoreAPI.Persistence;
using LaptopStoreAPI.Persistence.Models;
using LaptopStoreAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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


            if(await IsDisplayExist(displayDto))
                return BadRequest("Display already exist");


            try
            {
                var display = await base.Add<Display, DisplayDto>(displayDto);
                return CreatedAtAction("Get", new { id = display.Id }, display);
            }
            catch(DbUpdateException ex)
            {
                if(ex.InnerException is SqlException sqlException)
                {
                    return StatusCode(StatusCodes.Status409Conflict, sqlException.Message);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while adding data.");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DisplayDto displayDto)
        {
            if (await IsDisplayExist(displayDto))
                return BadRequest("Display already exist");

            return await base.Update<Display, DisplayDto>(id, displayDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await base.Delete<Display, DisplayDto>(id);
        }

        private async Task<bool> IsDisplayExist(DisplayDto displayDto)
        {
            var exist = await repository.IsCompositeExist<Display>(
           d => d.Type == displayDto.Type && d.Size == displayDto.Size && d.Resolution == displayDto.Resolution
            );
            return exist != null;
        }

    }
}

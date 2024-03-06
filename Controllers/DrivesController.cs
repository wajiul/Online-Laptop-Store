using AutoMapper;
using LaptopStoreAPI.Controllers.DTOs;
using LaptopStoreAPI.Persistence.Models;
using LaptopStoreAPI.Persistence.Repositories;
using LaptopStoreAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using LaptopStoreAPI.Exceptions;

namespace LaptopStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivesController : GenericCrudController
    {
        public DrivesController(LaptopStoreRepository repository, IMapper mapper, IUnitOfWork uow) :
                    base(repository, mapper, uow)
        {

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await base.Get<Drive>(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await base.GetAll<Drive>();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await base.Delete<Drive, DriveDto>(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DriveDto driveDto)
        {

            if (await IsDriveExist(driveDto))
                throw new DomainExistException("Drive already exist");

            var drive = await base.Add<Drive, DriveDto>(driveDto);
            return CreatedAtAction("Get", new { id = drive.Id }, drive);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DriveDto driveDto)
        {
            if (await IsDriveExist(driveDto))
                throw new DomainExistException("Drive already exist");

            return await base.Update<Drive, DriveDto>(id, driveDto);
        }

        private async Task<bool> IsDriveExist(DriveDto driveDto)
        {
            var exist = await repository.IsCompositeExist<Drive>(
           d => d.Type == driveDto.Type && d.Capacity == driveDto.Capacity
            );
            return exist != null;
        }
     
    }
}

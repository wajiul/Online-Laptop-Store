using AutoMapper;
using LaptopStoreAPI.Persistence.Repositories;
using LaptopStoreAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using LaptopStoreAPI.Persistence.Models;
using LaptopStoreAPI.Controllers.DTOs;
using System.Runtime.Versioning;

namespace LaptopStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericCrudController : ControllerBase
    {
        protected readonly LaptopStoreRepository repository;
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork uow;

        public GenericCrudController(LaptopStoreRepository repository, IMapper mapper, IUnitOfWork uow)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.uow = uow;
        }

        protected async Task<IActionResult> Update<TModel, TDto>(int id, TDto dto)
         where TModel : class
         where TDto : class
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var oldEntity = await repository.FindEntityAsync<TModel>(id);
            if (oldEntity == null)
                return NotFound();

            try
            {
                var entity = mapper.Map<TDto, TModel>(dto, oldEntity);
                await uow.Complete();

                return Ok("Data updated successfully");
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException exception)
                {
                    return StatusCode(StatusCodes.Status409Conflict, exception.Message);
                }

                return BadRequest();
            }
            
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating data.");
            }
        }

        protected async Task<IActionResult> GetAll<T>() where T: class
        {
            var result = await repository.GetAllEntitiesAsync<T>();
            return Ok(result);
        }

        protected async Task<IActionResult> Get<T>(int id) where T : class
        {
            var entity = await repository.GetEntityAsync<T>(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        protected async Task<TModel> Add<TModel, TDto>(TDto dto)
        where TModel : class
        where TDto : class
        {
            var entity = mapper.Map<TDto, TModel>(dto);

            await repository.AddEntityAsync<TModel>(entity);
            await uow.Complete();
            return entity;
        }

        protected async Task<IActionResult> Delete<TModel, TDto>(int id)
        where TModel : class
        where TDto : class
        {
            try
            {
                var entity = await repository.FindEntityAsync<TModel>(id);
                if (entity == null)
                    return NotFound();

                repository.DeleteEntity<TModel>(entity);
                await uow.Complete();

                return Ok("Data deleted successfully.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while deleting data.");
            }
        }
    }
}



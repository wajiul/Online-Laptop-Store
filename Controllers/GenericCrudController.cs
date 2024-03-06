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
using LaptopStoreAPI.Exceptions;

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
            var oldEntity = await repository.FindEntityAsync<TModel>(id);
            if (oldEntity == null)
                throw new DomainNotFoundException(typeof(TModel).Name + " not found");

            var entity = mapper.Map<TDto, TModel>(dto, oldEntity);
            await uow.Complete();

            return Ok("Data updated successfully");
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
                throw new DomainNotFoundException(typeof(T).Name + " not found");
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

            var entity = await repository.FindEntityAsync<TModel>(id);
            if (entity == null)
                throw new DomainNotFoundException(typeof(TModel).Name + " not found");

            repository.DeleteEntity<TModel>(entity);
            await uow.Complete();

            return Ok("Data deleted successfully.");
        }
    }
}



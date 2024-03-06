using AutoMapper;
using LaptopStoreAPI.Persistence.Repositories;
using LaptopStoreAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LaptopStoreAPI.Controllers.DTOs;
using LaptopStoreAPI.Persistence.Models;

namespace LaptopStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphicsCardsController : GenericCrudController
    {
        public GraphicsCardsController(LaptopStoreRepository repository, IMapper mapper, IUnitOfWork uow):
            base(repository, mapper, uow)
        {

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await base.Get<GraphicsCard>(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await base.GetAll<GraphicsCard>();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] GraphicsCardDto graphicsCardDto)
        {
            var graphicsCard = await base.Add<GraphicsCard, GraphicsCardDto>(graphicsCardDto);
            return CreatedAtAction("Get", new { id = graphicsCard.Id }, graphicsCard);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GraphicsCardDto graphicsCardDto)
        {
            return await base.Update<GraphicsCard, GraphicsCardDto>(id, graphicsCardDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await base.Delete<GraphicsCard, GraphicsCardDto>(id);
        }

    }
}

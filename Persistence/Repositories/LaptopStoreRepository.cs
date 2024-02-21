using LaptopStoreAPI.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LaptopStoreAPI.Persistence.Repositories
{
    public class LaptopStoreRepository
    {
        private readonly LaptopStoreDbContext context;

        public LaptopStoreRepository(LaptopStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Processor>> GetAllProcessorsAsync()
        {
            return await context.processors.ToListAsync();
        }
        public async Task<Processor> GetProcessorAsync(int id)
        {
            return await context.processors.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProcessorAsync(Processor processor)
        {
            await context.processors.AddAsync(processor);
        }

        public void UpdateProcessor(Processor processor)
        {
            context.processors.Update(processor);
        }
        public void DeleteProcessor(Processor processor)
        {
            context.processors.Remove(processor);
        }
    }
}

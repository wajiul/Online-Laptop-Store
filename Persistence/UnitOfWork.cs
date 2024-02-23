using Microsoft.EntityFrameworkCore;

namespace LaptopStoreAPI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LaptopStoreDbContext context;

        public UnitOfWork(LaptopStoreDbContext context)
        {
            this.context = context;
        }

        public async Task Complete()
        {
            await context.SaveChangesAsync();
        }

        public void Attach<T>(T entity) where T : class
        {
            context.Attach(entity);
        }

        public void Detach<T>(T entity) where T : class
        {
            var entry = context.Entry(entity);
            entry.State = EntityState.Detached;
        }

    }
}

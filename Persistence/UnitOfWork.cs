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

    }
}

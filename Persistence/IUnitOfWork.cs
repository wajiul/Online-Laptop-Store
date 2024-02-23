namespace LaptopStoreAPI.Persistence
{
    public interface IUnitOfWork
    {
        void Attach<T>(T entity) where T : class;
        Task Complete();
        void Detach<T>(T entity) where T : class;
    }
}
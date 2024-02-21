namespace LaptopStoreAPI.Persistence
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}
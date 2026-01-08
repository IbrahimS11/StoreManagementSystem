namespace StoreManagementSystem.Repositories.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public Task<int> SaveChangesAsync();
    }
}

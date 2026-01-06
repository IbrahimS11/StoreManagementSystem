namespace StoreManagementSystem.Repositories.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class where TKey : notnull 
    {
        Task<IEnumerable<TEntity>> GetRangeAsync(int skip,int take);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task AddAsync(TEntity entity);
        Task DeleteByIdAsync(TKey id);
    }
}

namespace StoreManagementSystem.Repositories.Interfaces
{
    public interface ICrudRepository<TEntity, TKey> where TEntity : class where TKey : notnull 
    {
        Task<IEnumerable<TEntity>> GetRangeAsync(int skip,int take);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);
        void Add(TEntity entity);
        Task DeleteByIdAsync(TKey id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}

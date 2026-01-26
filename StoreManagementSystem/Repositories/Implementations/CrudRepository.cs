using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Repositories.Interfaces;

public class CrudRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey>
    where TEntity : class
    where TKey : notnull
{
    protected readonly DbSet<TEntity> _dbSet;

    public CrudRepository(AppDbContext _context)
    {
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetByIdAsync(TKey id)
    { 
        return await _dbSet.AsNoTracking()
                     .FirstOrDefaultAsync(e => EF.Property<TKey>(e, "Id").Equals(id));
    }
    public virtual async Task<TEntity?> FindAsync(TKey id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetRangeAsync(int skip, int take)
    {
        return await _dbSet.AsNoTracking()
                       .OrderBy(e => EF.Property<object>(e, "Id"))
                       .Skip(skip)
                       .Take(take)
                       .ToListAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public virtual void Add(TEntity entity)
    { 
         _dbSet.Add(entity);
    }

    public virtual void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public virtual async Task DeleteByIdAsync(TKey id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
            _dbSet.Remove(entity);
    }
    public virtual void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    
}

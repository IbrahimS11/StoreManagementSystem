using StoreManagementSystem.Repositories.Interfaces.UnitOfWork;

namespace StoreManagementSystem.Repositories.Implementations.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public UnitOfWork(AppDbContext _context)
        {
            this.context = _context;
        }

        public void Dispose()
        {
            
        }

        public async Task<int> SaveChangesAsync()
        {
           return  await context.SaveChangesAsync();
        }
    }
}

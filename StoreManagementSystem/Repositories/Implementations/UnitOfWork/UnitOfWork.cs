using Microsoft.EntityFrameworkCore.Storage;
using StoreManagementSystem.Repositories.Interfaces.UnitOfWork;

namespace StoreManagementSystem.Repositories.Implementations.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private IDbContextTransaction? transaction;

        public UnitOfWork(AppDbContext _context)
        {
            context = _context;
        }

        public async Task BeginTransactionAsync()
        {
            transaction = await context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (transaction == null)
                throw new InvalidOperationException("No active transaction");

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            if (transaction != null)
                await transaction.RollbackAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        public void Dispose()
        {
            transaction?.Dispose();
            context.Dispose();
        }
    }
}

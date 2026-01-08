namespace StoreManagementSystem.Repositories.Interfaces.Products
{
    public interface IProductRepository : ICrudRepository<Product,int>
    {
        public Task<bool> IsExistAsync(int CategoryId,int ProductUnitPriceId,int ProductFlavorId,int? ProductId);
        public Task<Product?> GetDetails(int id);
    }
}

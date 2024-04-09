using ShopOnline.Api.Entities;

namespace ShopOnline.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<Product> GetItem(int id);
        Task<ProductCategory> GetCategory(int id);
        Task<List<Product>> AddProduct(Product id);
        Task<List<Product>?> UpdateProduct(int id, Product pr);
        Task<List<Product>?> DeleteProduct(int id);

        Task<IEnumerable<Product>> GetItemsByCategory(int id);

    }
}

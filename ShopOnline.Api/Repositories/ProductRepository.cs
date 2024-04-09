using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;

        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }

        public async Task<List<Product>> AddProduct(Product id)
        {
            this.shopOnlineDbContext.Products.Add(id);
            await this.shopOnlineDbContext.SaveChangesAsync();
            return await this.shopOnlineDbContext.Products.ToListAsync();
        }

        public async Task<List<Product>?> DeleteProduct(int id)
        {
            var product = await this.shopOnlineDbContext.Products.FindAsync(id);
            if(product == null)
            {
                return null;
            }
            this.shopOnlineDbContext.Remove(product);
            await this.shopOnlineDbContext.SaveChangesAsync();
            return await this.shopOnlineDbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.shopOnlineDbContext.ProductCategories.ToListAsync();
           
            return categories; 
        
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await shopOnlineDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await shopOnlineDbContext.Products
                                .Include(p => p.ProductCategory)
                                .SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.shopOnlineDbContext.Products
                                     .Include(p => p.ProductCategory).ToListAsync();

            return products;
        
        }

        public async Task<IEnumerable<Product>> GetItemsByCategory(int id)
        {
            var products = await this.shopOnlineDbContext.Products
                                     .Include(p => p.ProductCategory)
                                     .Where(p => p.CategoryId == id).ToListAsync();
            return products;
        }

        public async Task<List<Product>?> UpdateProduct(int id, Product pr)
        {
            var product = await this.shopOnlineDbContext.Products.FindAsync(id);
            if (product is null)
            {
                return null;
            }
            product.Id = pr.Id;
            product.Name = pr.Name;
            product.Description = pr.Description;
            product.Price = pr.Price;   
            product.Qty = pr.Qty;
            product.CategoryId = pr.CategoryId;

            await this.shopOnlineDbContext.SaveChangesAsync();
            return await this.shopOnlineDbContext.Products.ToListAsync();
        }
    }
}

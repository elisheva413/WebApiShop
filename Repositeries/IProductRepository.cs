using Entities;

namespace Repositeries
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts(int? Product_id, string? name, float? price, int? Category_ID, string? Description);
    }
}
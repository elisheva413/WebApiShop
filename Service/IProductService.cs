using Entities;

namespace Service
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts(int? Product_id, string? name, float? price, int? Category_ID, string? Description);
    }
}
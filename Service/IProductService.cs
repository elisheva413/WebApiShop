using Entities;
using DTOs;

namespace Service
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetProducts(int? Product_id, string? name, float? price, int? Category_ID, string? Description);
    }
}
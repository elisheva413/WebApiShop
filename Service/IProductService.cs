using Entities;
using DTOs;

namespace Service
{
    public interface IProductService
    {
        Task<FinalProducts> GetProducts(string? description, double? minPrice, double? maxPrice, short[]? categoriesId, int position = 1, int skip = 8);
    }
}
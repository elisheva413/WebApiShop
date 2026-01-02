using Entities;

namespace Repositeries
{
    public interface IProductRepository
    {
        Task<(List<Product> Items, int TotalCount)> GetProducts(string? description, double? minPrice, double? maxPrice, short[]? categoriesId, int position = 1, int skip = 8);

    }
}
using Repositeries;
using Entities;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts(int? Product_id, string? name, float? price, int? Category_ID, string? Description)
        {
            return await _productRepository.GetProducts(Product_id, name, price, Category_ID, Description);

        }



    }
}
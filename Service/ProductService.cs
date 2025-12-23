using AutoMapper;
using Entities;
using Repositeries;
using DTOs;


namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetProducts(int? Product_id, string? name, float? price, int? Category_ID, string? Description)
        {
            List<Product> ProductList = await _productRepository.GetProducts(Product_id, name, price, Category_ID, Description);
            List<ProductDTO> ProductDTOList = _mapper.Map<List<Product>, List<ProductDTO>>(ProductList);
            return ProductDTOList;

        }



    }
}
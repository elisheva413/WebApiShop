using AutoMapper;
using Entities;
using Repositories;
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

        public async Task<FinalProducts> GetProducts(string? description, double? minPrice, double? maxPrice, short[]? categoriesId, int position = 1, int skip = 8)
        {
            (List<Product> Items, int TotalCount) products = await _productRepository.GetProducts(description, minPrice, maxPrice, categoriesId, position, skip);
            List<ProductDTO> productsDTO = _mapper.Map<List<Product>, List<ProductDTO>>(products.Items);
            bool hasNext = (products.TotalCount - (position * skip)) > 0;
            bool hasPrev = position > 1;
            FinalProducts finalProducts = new()
            {
                Items = productsDTO,
                TotalCount = products.TotalCount,
                HasNext = hasNext,
                HasPrev = hasPrev
            };
            return finalProducts;
        }



    }
}
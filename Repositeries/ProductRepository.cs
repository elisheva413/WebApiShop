using Entities;
using Microsoft.EntityFrameworkCore;
using Repositeries;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Threading.Tasks;


namespace Repositeries
{
    public class ProductRepository : IProductRepository
    {
        Store_215962135Context _store_215962135Context;
        public ProductRepository(Store_215962135Context store_215962135Context)
        {
            _store_215962135Context = store_215962135Context;
        }
      

        public async Task<(List<Product> Items,int TotalCount)> GetProducts(string? description,double? minPrice,double? maxPrice,short[]? categoriesId,int position = 1,int skip = 8)
        {
            var query = _store_215962135Context.Products.Where(product => (description == null ? (true) : (product.ProductsDescreption.Contains(description)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoriesId.Length == 0) ? (true) : (categoriesId.Contains(product.CategoryId))))
            .OrderBy(product => product.Price);
            Console.WriteLine(query.ToQueryString());

            List<Product> products = await query.Skip((position - 1) * skip).Take(skip).Include(Product => Product.Category).ToListAsync();
            int totalCount = await query.CountAsync();
            


            return  (products, totalCount);
        }
    }
}

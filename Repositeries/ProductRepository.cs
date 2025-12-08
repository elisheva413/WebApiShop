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


        public async Task<List<Product>> GetProducts(int? Product_id, string? name, float? price, int? Category_ID, string? Description)
        {
            return await _store_215962135Context.Products.ToListAsync();
        }
    }
}

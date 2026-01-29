using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Collections.Generic;
using Repositories;
using Service;
using DTOs;




namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productsService;
       

        public ProductsController(IProductService productsService)
        {
            _productsService = productsService;
           
        }

        [HttpGet]
        public async Task<ActionResult<FinalProducts>> Get(string? description, double? minPrice, double? maxPrice, short[]? categoriesId, int position = 1, int skip = 8)
        {
            FinalProducts products = await _productsService.GetProducts(description, minPrice, maxPrice, categoriesId, position, skip);
            if (products.Items.Count() == 0)
                return NoContent();
            return Ok(products);
        }

       
      
    }
}
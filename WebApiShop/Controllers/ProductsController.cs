using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Collections.Generic;
using Repositeries;
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
        public async Task<ActionResult<List<ProductDTO>>> Get(int? Product_id,string? name,float? price,int? Category_ID,string? Description)
        {
            return await _productsService.GetProducts( Product_id,name,price,Category_ID,Description);
            //if (Products == null || !Products.Any())
            //    return NoContent();
            //return Ok(Products);
        }

       
      
    }
}
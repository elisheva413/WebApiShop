using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Collections.Generic;
using Repositeries;
using Service;




namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
       

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            List<Category> categories=await _categoryService.GetCategory();
            if (categories == null || categories.Count==0)
                return NoContent();
            return Ok(categories);
        }

       
     
    }
}
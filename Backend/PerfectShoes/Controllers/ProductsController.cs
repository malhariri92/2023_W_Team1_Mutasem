using Microsoft.AspNetCore.Mvc;
using PerfectShoes.BusinessLogic;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfectShoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       private readonly IProductsService _productsService;
       public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet(Name = "GetProduct")]
        public ActionResult<List<Product>> Get()
        {
            var products = _productsService.GetAllProducts();

            if (products == null) return NotFound();

            return Ok(products);
        }

        [HttpPost(Name = "InsertProduct")]
        public ActionResult InsertProduct(ProductDto productDto)
        {
            if (_productsService.InsertProduct(productDto)) return Ok();
            return BadRequest();
        }

        [HttpGet("categories", Name = "getCategories")]
        public ActionResult<List<Category>> GetCategories()
        {
            var categories = _productsService.GetAllCategories();
            if (categories == null) return NotFound();
            return Ok(categories);
        }

    }
}

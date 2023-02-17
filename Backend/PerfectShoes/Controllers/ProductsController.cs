using Microsoft.AspNetCore.Mvc;
using PerfectShoes.BusinessLogic;
using PerfectShoes.Models;

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

    }
}

using Microsoft.AspNetCore.Mvc;
using PerfectShoes.BusinessLogic;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpPost(Name = "InsertCategory")]
        public ActionResult InsertCategory(CategoryDto dto)
        {
            if (_categoriesService.InsertProduct(dto)) return Ok();
            return BadRequest();
        }

        [HttpGet(Name = "getCategories")]
        public ActionResult<List<Category>> GetCategories()
        {
            var categories = _categoriesService.GetAllCategories();
            if (categories == null) return NotFound();
            return Ok(categories);
        }
    }
}

using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.BusinessLogic
{
    public interface ICategoriesService
    {
        public bool InsertProduct(CategoryDto categoryDto);
        public List<Category> GetAllCategories();
    }
}

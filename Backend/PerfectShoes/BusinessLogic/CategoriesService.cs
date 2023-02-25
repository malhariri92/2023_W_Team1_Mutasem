using PerfectShoes.Models.DTO;
using PerfectShoes.Models;

namespace PerfectShoes.BusinessLogic
{
    public class CategoriesService : Service, ICategoriesService
    {
        public CategoriesService(DataContext context) : base(context) { }

        public bool InsertProduct(CategoryDto categoryDto)
        {
            Category category = new Category
            {
                Name = categoryDto.Name,
            };

            _context.Categories.Add(category);
            return _context.SaveChanges() > 0;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}

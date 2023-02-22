using Microsoft.EntityFrameworkCore;
using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.BusinessLogic
{
    public class ProductsService : Service, IProductsService
    {
        public ProductsService(DataContext context) : base(context) { }

        public List<Product> GetAllProducts()
        {
           return _context.Products.Where(p => p.IsActive).Include(c => c.Category)
                .Include(s => s.Specs).OrderBy(x => x.CategoryId).ToList();
        }

        public bool InsertProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                Specs = productDto.Specs,
                ImageUrl = productDto.ImageUrl,
                CategoryId = productDto.CategoryId,
                Description = productDto.Description,
                IsActive= productDto.IsActive,
            };
            _context.Products.Add(product);
            return _context.SaveChanges() > 0;          
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}

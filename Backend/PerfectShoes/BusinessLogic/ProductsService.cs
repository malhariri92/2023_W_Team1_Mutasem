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

        public bool UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            if(product.Specs?.Count > 0 )
            {
                foreach (var attr in product.Specs)
                {
                    if (attr.Id == 0)
                    {
                        _context.Entry(attr).State = EntityState.Added;
                    }
                    else
                    {
                        _context.Entry(attr).State = EntityState.Modified;
                    }
                }
            }
            
            return _context.SaveChanges() > 0;
        }

        public bool DeleteSpec(int id)
        {
           _context.Specifications.Remove(new Specification() { Id = id });
            return _context.SaveChanges() > 0;
        }
    }
}

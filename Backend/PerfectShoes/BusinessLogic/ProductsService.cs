using Microsoft.EntityFrameworkCore;
using PerfectShoes.Models;


namespace PerfectShoes.BusinessLogic
{
    public class ProductsService : Service, IProductsService
    {
        public ProductsService(DataContext context) : base(context) { }

        public List<Product> GetAllProducts()
        {
           return _context.Products.OrderBy(x => x.Category).ToList();
        }
    }
}

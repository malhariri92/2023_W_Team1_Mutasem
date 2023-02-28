using PerfectShoes.Models;
using PerfectShoes.Models.DTO;

namespace PerfectShoes.BusinessLogic
{
    public interface IProductsService
    {
        List<Product> GetAllProducts();
        bool InsertProduct(ProductDto productDto);
        bool UpdateProduct(Product product);
    }
}

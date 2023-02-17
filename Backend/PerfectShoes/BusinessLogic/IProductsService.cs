using PerfectShoes.Models;

namespace PerfectShoes.BusinessLogic
{
    public interface IProductsService
    {
        List<Product> GetAllProducts();
    }
}

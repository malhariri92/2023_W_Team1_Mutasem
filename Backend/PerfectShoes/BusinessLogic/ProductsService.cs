namespace PerfectShoes.BusinessLogic
{
    public class ProductsService : Service, IProductsService
    {
        public ProductsService(DataContext context) : base(context) { }
    }
}

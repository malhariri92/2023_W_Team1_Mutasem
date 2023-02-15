namespace PerfectShoes.BusinessLogic
{
    public abstract class Service
    {
        protected readonly DataContext _context;
        public Service (DataContext context)
        {
            _context = context;
        }
    }
}

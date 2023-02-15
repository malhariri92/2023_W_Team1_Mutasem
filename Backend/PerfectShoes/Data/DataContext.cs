using Microsoft.EntityFrameworkCore;
using PerfectShoes.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) :base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Specification> Specifications { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<LineItem> LineItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasDiscriminator<string>("Type")
        .HasValue<Customer>("customer")
        .HasValue<Employee>("employee");
    }
    
}
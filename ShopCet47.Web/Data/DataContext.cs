
using Microsoft.EntityFrameworkCore;
using ShopCet47.Web.Data.Entities;



public class DataContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}


using Microsoft.EntityFrameworkCore;

namespace Shopping_Cart.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){ }

        public DbSet<User> User { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<Record> Record { get; set; }
    }
}

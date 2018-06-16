namespace IMM.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using IMM.Models;
    using IMM.Data.Models;

    public class IMMDbContext : IdentityDbContext<User>
    {
        public IMMDbContext(DbContextOptions<IMMDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

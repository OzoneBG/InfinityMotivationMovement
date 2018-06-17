namespace IMM.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using IMM.Models;
    using IMM.Data.Models;
    using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
    using System;
    using IMM.Data.Common.Models;
    using System.Linq;

    public class IMMDbContext : IdentityDbContext<User>
    {
        private DbContextOptions options;

        public IMMDbContext(DbContextOptions<IMMDbContext> options)
            : base(options)
        {
            this.options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var sqlServerOptions = options.GetExtension<SqlServerOptionsExtension>();
            optionsBuilder.UseSqlServer(sqlServerOptions.ConnectionString, b => b.MigrationsAssembly("IMM.Data"));

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SetupIndexesForTables(builder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        private void ApplyDeletableEntityRules()
        {
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                .Where(
                    e => e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void SetupIndexesForTables(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(b => b.IsDeleted);

            builder.Entity<Category>()
                .HasIndex(b => b.IsDeleted);

            builder.Entity<Product>()
                .HasIndex(b => b.IsDeleted);
        }
    }
}

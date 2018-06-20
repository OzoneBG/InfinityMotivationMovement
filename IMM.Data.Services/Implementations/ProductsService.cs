namespace IMM.Data.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IMM.Data.Common.Repository;
    using IMM.Data.Models;
    using IMM.Data.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> products;

        public ProductsService(IRepository<Product> products)
        {
            this.products = products;
        }

        public void CreateNewProduct(string Name, string Description, Category Category, decimal Price = 0, int Quantity = 0)
        {
            Product product = new Product
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Quantity = Quantity,
                CategoryId = Category.Id
            };

            products.Add(product);
            products.SaveChanges();
        }

        public IQueryable<Product> GetAllProducts()
        {
            return products.All().Include(p => p.Category).AsQueryable();
        }

        public IQueryable<Product> GetProductById(Guid Id)
        {
            var product = GetAllProducts().Where(x => x.Id == Id);

            return product;
        }

        public IQueryable<Product> GetProductByName(string Name)
        {
            var product = products
                .All()
                .Where(p => p.Name == Name)
                .AsQueryable();

            return product;
        }

        public IQueryable<Product> GetProductsByCategory(string Category)
        {
            var productsByCategory = products
                .All()
                .Where(p => p.Category.Name == Category)
                .AsQueryable();

            return productsByCategory;
        }

        public bool ShouldCreateDefaultProducts()
        {
            int count = products.All().Count();

            if (count == 0)
                return true;
            else
                return false;
        }
    }
}

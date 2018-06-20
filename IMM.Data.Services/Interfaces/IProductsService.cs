using IMM.Data.Models;
using System;
using System.Linq;

namespace IMM.Data.Services.Interfaces
{
    public interface IProductsService
    {
        bool ShouldCreateDefaultProducts();

        void CreateNewProduct(string Name, string Description, Category Category, decimal Price = 0M, int Quantity = 0);

        IQueryable<Product> GetProductById(Guid Id);

        IQueryable<Product> GetProductByName(string Name);

        IQueryable<Product> GetProductsByCategory(string Category);

        IQueryable<Product> GetAllProducts();
    }
}

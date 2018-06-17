namespace IMM.Data.Services.DbSeeder
{
    using IMM.Data.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;

    public static class IMMDBSeeder
    {
        public static void Seed(IMMDbContext context, ICategoriesService categories, IProductsService products, ILogger logger)
        {
            context.Database.EnsureCreated();

            logger.LogInformation("Database was successfully created");

            if (categories.ShouldCreateDefaultCategories())
            {
                logger.LogInformation("Creating default categories.");
                categories.CreateNewCategory("T-Shirt");
                categories.CreateNewCategory("Cap");
                categories.CreateNewCategory("Wristband");
                categories.CreateNewCategory("Necklace");
                categories.CreateNewCategory("Sweater");
            }

            if (products.ShouldCreateDefaultProducts())
            {
                logger.LogInformation("Creating sample products");

                var tshirtCategory = categories.GetCategoryByName("T-Shirt").FirstOrDefault();
                var capCategory = categories.GetCategoryByName("Cap").FirstOrDefault();

                products.CreateNewProduct("Black T-Shirt", "A very black T-Shirt for you!", tshirtCategory, 15.99M, 10);
                products.CreateNewProduct("Red T-Shirt", "A red agressive T-Shirt for you!", tshirtCategory, 10.99M, 7);
                products.CreateNewProduct("White T-Shirt", "A white T-Shirt for you!", tshirtCategory, 7.99M, 13);
                products.CreateNewProduct("Black Cap", "A very black cap for you!", capCategory, 2.99M, 10);
                products.CreateNewProduct("Red Cap", "A red cap to keep you warm!", capCategory, 1.99M, 10);
                products.CreateNewProduct("Yellow Cap", "A very yellow cap for your head!", capCategory, .99M, 10);
            }
        }
    }
}

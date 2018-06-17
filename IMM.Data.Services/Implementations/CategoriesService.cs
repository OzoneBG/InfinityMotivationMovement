namespace IMM.Data.Services.Implementations
{
    using System;
    using System.Linq;
    using IMM.Data.Common.Repository;
    using IMM.Data.Models;
    using IMM.Data.Services.Interfaces;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categories;

        public CategoriesService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public void CreateNewCategory(string name)
        {
            Category category = new Category
            {
                Name = name
            };

            categories.Add(category);
            categories.SaveChanges();
        }

        public void DeleteCategoryByName(string name)
        {
            Category category = categories
                .All()
                .Where(cat => cat.Name == name)
                .FirstOrDefault();

            category.DeletedOn = DateTime.Now;
            category.IsDeleted = true;

            categories.SaveChanges();
        }

        public IQueryable<Category> GetAllCategories()
        {
            return categories.All().AsQueryable();
        }

        public IQueryable<Category> GetCategoryByName(string name)
        {
            var category = categories
                .All()
                .Where(cat => cat.Name == name)
                .AsQueryable();

            return category;
        }

        public bool ShouldCreateDefaultCategories()
        {
            int count = categories.All().Count();

            if (count == 0)
                return true;
            else
                return false;
        }
    }
}

namespace IMM.Data.Services.Interfaces
{
    using IMM.Data.Models;
    using System.Linq;

    public interface ICategoriesService
    {
        IQueryable<Category> GetCategoryByName(string name);

        bool ShouldCreateDefaultCategories();

        IQueryable<Category> GetAllCategories();

        void CreateNewCategory(string Name);

        void DeleteCategoryByName(string name);
    }
}

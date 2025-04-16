using CTSMVCDemo.Models;

namespace CTSMVCDemo.Repository
{
    public interface ICategory
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}

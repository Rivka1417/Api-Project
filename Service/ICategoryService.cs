using Entity;

namespace Service
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
    }
}
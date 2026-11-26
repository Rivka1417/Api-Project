using Entity;

namespace repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
    }
}
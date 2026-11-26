using Entity;

namespace Service
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
    }
}
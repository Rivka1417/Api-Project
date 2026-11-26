using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using repository;

namespace Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            this._repository = repository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _repository.GetAllProducts();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Microsoft.EntityFrameworkCore;
using repository.Entity;

namespace repository
{
    public class ProductRepository:IProductRepository
    {
        MyStoreContext _dbContext;

        public ProductRepository(MyStoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Product>> GetAllProducts()
        {


            List<Product> products= await _dbContext.Products.Include(p=>p.Category).ToListAsync();
            return products;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Entity;
using repository.Entity;

namespace repository
{
    public class CategoryRepository : ICategoryRepository
    {
        MyStoreContext _dbContext;

        public CategoryRepository(MyStoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Category>> GetAllCategories()
        {


            List<Category> categories = await _dbContext.Categories.Include(c => c.Products).ToListAsync();
            return categories;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using repository;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            this._repository = repository;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _repository.GetAllCategories();
        }
    }
}

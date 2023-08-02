using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            var categories = await _manager.Category.GetAllCategoriesAsync(trackChanges);
            return categories;
        }

        public async Task<Category> GetOneCategoryAsync(int id, bool trackChanges)
        {
            var entity = await _manager.Category.GetOneCategoryByIdAsync(id, trackChanges);

            if (entity is null)
                throw new CategoryNotFoundException(id);

            return entity;
        }
    }
}

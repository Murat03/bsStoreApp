using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetOneCategoryAsync(int id, bool trackChanges);
        //Sonra isteğe bağlı tanımlayabilirim.
        //Task CreateOneCategoryAsync();
        //Task DeleteOneCategoryAsync(int id, bool trackChanges);
        //Task UpdateOneCategoryAsync(int id, bool trackChanges);
    }
}

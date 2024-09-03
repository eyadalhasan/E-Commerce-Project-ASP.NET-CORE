using Microsoft.EntityFrameworkCore;
using SimpleProject.Data;
using SimpleProject.Models.Services.Interfaces;

namespace SimpleProject.Models.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        AppDBContext _context;
        public CategoryService(AppDBContext _context)
        {
            this._context = _context;

        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Category.ToListAsync();
        }


    }
}

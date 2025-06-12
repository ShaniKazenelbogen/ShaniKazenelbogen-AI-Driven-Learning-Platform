using Dal.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dal.Repositories
{

    public class CategoryRepository
    {
        private readonly dbClass _context;

        public CategoryRepository(dbClass context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories() {
            return _context.Categories.ToList();
        }
        public  Task<string?> GetCategoryNameByIdAsync(int categoryId)
        {
            var category = _context.Categories
                .Where(c => c.Id == categoryId)
                .Select(c => c.Name)  
                .FirstOrDefaultAsync();

            return category;  
        }
    }
}


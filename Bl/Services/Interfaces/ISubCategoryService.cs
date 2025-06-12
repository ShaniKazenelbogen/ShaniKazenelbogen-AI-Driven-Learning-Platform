using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Services.Interfaces
{
    public interface ISubCategoryService
    {
        IEnumerable<SubCategory> GetAllSubCategories();
        Task<string?> GetSubCategoryNameByIdAsync(int subCategoryId);
    }
}

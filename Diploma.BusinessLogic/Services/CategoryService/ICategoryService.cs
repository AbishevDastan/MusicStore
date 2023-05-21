using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Services.CategoryService
{
    public interface ICategoryService
    {
        List<CategoryDTO> Categories { get; set; }
        Task GetCategories();
        Task<CategoryDTO> GetCategory(int categoryId);
    }
}

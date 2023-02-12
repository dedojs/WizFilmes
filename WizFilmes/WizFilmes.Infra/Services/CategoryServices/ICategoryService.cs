using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.CategoryDtos;

namespace WizFilmes.Infra.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        Task<IEnumerable<CategoryDto>> GetCategoryById(int id);
        Task<CategoryDto> CreateCategory(CreateCategoryDto createCategoryDto);
    }
}

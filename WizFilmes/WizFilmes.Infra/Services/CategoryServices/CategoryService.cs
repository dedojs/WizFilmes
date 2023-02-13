using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.ActorDtos;
using WizFilmes.Infra.Data.Dtos.CategoryDtos;
using WizFilmes.Infra.Data.Repository.ActorRepository;

namespace WizFilmes.Infra.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var listAllCategories = await _repository.GetAllCategories();
            var findCategory = listAllCategories.Where(a => a.Name.ToLower() == createCategoryDto.Name.ToLower());

            if (findCategory.Any())
                return null;

            var category = _mapper.Map<Category>(createCategoryDto);
            var categoryCreated = await _repository.CreateCategory(category);

            var categoryDto = _mapper.Map<CategoryDto>(categoryCreated);

            return categoryDto;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = await _repository.GetAllCategories();

            return categories;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryById(int id)
        {
            var category = await _repository.GetCategoryById(id);
            if (!category.Any())
                return null;

            return category;
        }
    }
}

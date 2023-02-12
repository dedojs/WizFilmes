using Microsoft.EntityFrameworkCore;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Context;
using WizFilmes.Infra.Data.Dtos.CategoryDtos;
using WizFilmes.Infra.Data.Dtos.DirectorDtos;

namespace WizFilmes.Infra.Data.Repository.ActorRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = await _context.Categories
                .Include(x => x.Films)
                .Select(d => new CategoryDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Films = d.Films.Select(f => f.Name).ToList()
                })
                .ToListAsync();

            return categories;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryById(int id)
        {
            var categories = await _context.Categories
                .Include(x => x.Films)
                .Where(x => x.Id == id)
                .Select(d => new CategoryDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Films = d.Films.Select(f => f.Name).ToList()
                })
                .ToListAsync();

            return categories;
        }
    }
}

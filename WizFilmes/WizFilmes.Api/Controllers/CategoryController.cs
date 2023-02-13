using Microsoft.AspNetCore.Mvc;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.ActorDtos;
using WizFilmes.Infra.Data.Dtos.CategoryDtos;
using WizFilmes.Infra.Services.CategoryServices;

namespace WizFilmes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _service.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _service.GetCategoryById(id);

            if (category == null)
                return NotFound("Categoria não localizada");
            
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto == null)
                return BadRequest("Dados Inválidos");

            var category = await _service.CreateCategory(createCategoryDto);

            if (category == null)
                return BadRequest("Categoria já existe");

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }
    }
}

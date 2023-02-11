using Microsoft.AspNetCore.Mvc;
using WizFilmes.Infra.Data.Dtos.ReviewsDto;
using WizFilmes.Infra.Services.ReviewServices;

namespace WizFilmes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            var result = await _service.GetReviews();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var result = await _service.GetReviewById(id);

            if (result == null)
                return BadRequest("Review não localizada");

            return Ok(result);
        }

        [HttpGet("film/{id}")]
        public async Task<IActionResult> GetReviewByFilmId(int id)
        {
            var result = await _service.GetReviewsByFilmId(id);

            if (result == null)
                return BadRequest("Review ou Filme não localizado");

            return Ok(result);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetReviewByUserId(int id)
        {
            var result = await _service.GetReviewsByUserId(id);

            if (result == null)
                return BadRequest("Review ou Filme não localizado");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto createReview)
        {
            var review = await _service.CreateReview(createReview);
            if (review == null)
                return BadRequest("Usuário ja fez uma avaliação para esse filme");

            return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, review);
        }

    }
}

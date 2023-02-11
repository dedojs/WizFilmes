using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.ReviewsDto;

namespace WizFilmes.Infra.Services.ReviewServices
{
    public interface IReviewService
    {
        Task<IEnumerable<ReadReviewDto>> GetReviews();
        Task<ReadReviewDto> CreateReview(CreateReviewDto createReviewDto);
        Task<ReadReviewDto> GetReviewById(int id);
        Task<IEnumerable<Review>> GetReviewsByFilmId(int id);
        Task<IEnumerable<Review>> GetReviewsByUserId(int id);
    }
}

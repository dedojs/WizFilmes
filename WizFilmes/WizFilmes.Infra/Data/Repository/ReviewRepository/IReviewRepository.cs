using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Repository.ReviewRepository
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviews();
        Task<Review> CreateReview(Review review);
        Task<Review> GetReviewById(int id);
        Task<IEnumerable<Review>> GetReviewsByFilmId(int id);
        Task<IEnumerable<Review>> GetReviewsByUserId(int id);
        

    }
}

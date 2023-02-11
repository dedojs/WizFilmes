using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Context;

namespace WizFilmes.Infra.Data.Repository.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;
        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Review> CreateReview(Review review)
        {
            _context.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<Review> GetReviewById(int id)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(x => x.Id == id);

            if (review == null)
                return null;

            return review;
        }

        public async Task<IEnumerable<Review>> GetReviews()
        {
            var listReviews = await _context.Reviews.ToListAsync();
            return listReviews;
        }

        public async Task<IEnumerable<Review>> GetReviewsByFilmId(int id)
        {
            var review = await _context.Reviews
                .Where(x => x.Film.Id == id)
                .ToListAsync();

            if (review == null)
                return null;

            return review;
        }

        public async Task<IEnumerable<Review>> GetReviewsByUserId(int id)
        {
            var review = await _context.Reviews
                .Where(x => x.User.Id == id)
                .ToListAsync();

            if (review == null)
                return null;

            return review;
        }
    }
}

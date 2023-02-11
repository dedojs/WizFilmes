using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.ReviewsDto;
using WizFilmes.Infra.Data.Dtos.UserDtos;
using WizFilmes.Infra.Data.Repository.ReviewRepository;
using WizFilmes.Infra.Data.Repository.UserRepository;

namespace WizFilmes.Infra.Services.ReviewServices
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;
        private readonly IUserRepository _repositoryUser;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository repository, IMapper mapper, IUserRepository repositoryUser)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryUser = repositoryUser;
        }

        public async Task<ReadReviewDto> CreateReview(CreateReviewDto createReviewDto)
        {
            var result = await _repository.GetReviewsByUserId(createReviewDto.UserId);

            foreach (var item in result)
            {
                if (item.FilmId == createReviewDto.FilmId)
                    return null;
            }

            var review = _mapper.Map<Review>(createReviewDto);
            var reviewCreated = await _repository.CreateReview(review);

            var reviewDto = _mapper.Map<ReadReviewDto>(reviewCreated);
            return reviewDto;

        }

        public async Task<IEnumerable<Review>> GetReviewsByUserId(int id)
        {
            var user = await _repositoryUser.GetUserById(id);
            if (user == null)
                return null;
            
            var reviews = await _repository.GetReviewsByUserId(id);

            return reviews;
        }

        public async Task<ReadReviewDto> GetReviewById(int id)
        {
            var review = await _repository.GetReviewById(id);

            if (review == null)
                return null;

            var reviewDto = _mapper.Map<ReadReviewDto>(review);

            return reviewDto;
        }

        public async Task<IEnumerable<ReadReviewDto>> GetReviews()
        {
            var reviews = await _repository.GetReviews();

            var listReviews = reviews.Select(u => _mapper.Map<ReadReviewDto>(u));
            return listReviews;
        }

        public async Task<IEnumerable<Review>> GetReviewsByFilmId(int id)
        {
            var reviews = await _repository.GetReviewsByFilmId(id);

            if (reviews == null)
                return null;

            return reviews;
        }
    }
}

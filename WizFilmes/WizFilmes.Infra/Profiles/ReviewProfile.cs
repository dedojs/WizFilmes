using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.ReviewsDto;
using WizFilmes.Infra.Data.Dtos.UserDtos;

namespace WizFilmes.Infra.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<CreateReviewDto, Review>();
            CreateMap<Review, ReadReviewDto>();
        }
    }
}

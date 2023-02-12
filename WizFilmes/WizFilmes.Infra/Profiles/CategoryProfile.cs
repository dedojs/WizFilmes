using AutoMapper;
using System;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.CategoryDtos;

namespace WizFilmes.Infra.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}

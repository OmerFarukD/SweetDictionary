using AutoMapper;
using SweetDictionary.Models.Categories;
using SweetDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Mappings
{
    public class CategoriesProfile : Profile
    {

        public CategoriesProfile()
        {
            CreateMap<CategoryAddRequestDto, Category>();
            CreateMap<CategoryUpdateRequestDto, Category>();
            CreateMap<Category, CategoryResponseDto>();
        }
    }
}

using AutoMapper;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;

namespace SweetDictionary.Service.Mappings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostRequestDto,Post>();
        CreateMap<Post, PostResponseDto>();
        CreateMap<UpdatePostRequestDto, Post>();
    }
}

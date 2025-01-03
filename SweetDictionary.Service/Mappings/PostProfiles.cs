﻿using AutoMapper;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;

namespace SweetDictionary.Service.Mappings;

public class PostProfiles : Profile
{
    public PostProfiles()
    {
        CreateMap<CreatePostRequestDto,Post>();
        CreateMap<Post, PostResponseDto>();
        CreateMap<UpdatePostRequestDto, Post>();
    }
}

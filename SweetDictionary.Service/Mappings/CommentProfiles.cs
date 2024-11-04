using AutoMapper;
using SweetDictionary.Models.Comments;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Service.Mappings;

public class CommentProfiles : Profile
{
    public CommentProfiles()
    {
        CreateMap<CommentAddRequestDto, Comment>();
        CreateMap<Comment, CommentResponseDto>()
            .ForMember(x => x.PostTitle, opt => opt.MapFrom(x => x.Post.Title))
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName));

    }
}

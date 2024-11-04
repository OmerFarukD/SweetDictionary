using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using SweetDictionary.Models.Comments;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Abstract;


namespace SweetDictionary.Service.Concretes;

public sealed class CommentService(IMapper _mapper, ICommentRepository _commentRepository) : ICommentService
{
    public ReturnModel<NoData> Add(string userId, CommentAddRequestDto dto)
    {
        Comment comment = _mapper.Map<Comment>(dto);
        comment.UserId = userId;

        _commentRepository.Add(comment);

        return new ReturnModel<NoData>
        {
            Message = "Yorum Eklendi.",

            Status = 200,
            Success = true
        };
    }

    public ReturnModel<NoData> Delete(Guid id)
    {
        Comment comment = CheckGetById(id);
        _commentRepository.Delete(comment);

        return new ReturnModel<NoData>
        {
            Message = "Yorum Silindi.",

            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid id)
    {
        var comments = _commentRepository.GetAll(x=> x.PostId==id);
        List<CommentResponseDto> responses = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = responses,
            Success = true,
            Status = 200
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAllCommentsByAuthor(string authorId)
    {
        var comments = _commentRepository.GetAll(x => x.UserId == authorId);
        List<CommentResponseDto> responses = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = responses,
            Success = true,
            Status = 200
        };
    }

    public ReturnModel<NoData> Update(string userId, CommentUpdateRequestDto dto)
    {
        Comment comment = CheckGetById(dto.Id);

        comment.PostId = dto.PostId;
        comment.Text = dto.Text;


        _commentRepository.Update(comment);


        return new ReturnModel<NoData>
        {
            Message = "Yorum Güncellendi.",

            Status = 200,
            Success = true
        };


    }


    private Comment CheckGetById(Guid id)
    {
        var comment = _commentRepository.GetById(id);
        if(comment is null)
        {
            throw new NotFoundException("İlgili yorum bulunamadı.");
        }

        return comment;
    }
}

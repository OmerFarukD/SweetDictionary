using Core.Entities;
using SweetDictionary.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Abstract;

public interface ICommentService
{
    ReturnModel<List<CommentResponseDto>> GetAllCommentsByAuthor(string authorId);
    ReturnModel<NoData> Add(string userId, CommentAddRequestDto dto);
    ReturnModel<NoData> Update(string userId, CommentUpdateRequestDto dto);

    ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid id);

    ReturnModel<NoData> Delete(Guid id);
}

namespace SweetDictionary.Models.Comments
{
    public sealed record CommentUpdateRequestDto(Guid Id,string Text, Guid PostId);
}

using FluentValidation;
using SweetDictionary.Models.Posts;

namespace SweetDictionary.Service.Validations.Posts;

public class UpdatePostRequestDtoValidator : AbstractValidator<UpdatePostRequestDto>
{
    public UpdatePostRequestDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Post Başlığı boş olamaz.")
    .Length(2, 50).WithMessage("Post Başlığı Minimum 2 max 50 karakterli olmalıdır.");


        RuleFor(x => x.Content).NotEmpty().WithMessage("Post İçeriği boş olamaz.");
    }
}

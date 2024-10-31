using FluentValidation;
using SweetDictionary.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Validations.Posts;

public class CreatePostRequestDtoValidator : AbstractValidator<CreatePostRequestDto>
{
    public CreatePostRequestDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Post Başlığı boş olamaz.")
            .Length(2, 50).WithMessage("Post Başlığı Minimum 2 max 50 karakterli olmalıdır.");


        RuleFor(x => x.Content).NotEmpty().WithMessage("Post İçeriği boş olamaz.");
    }
}

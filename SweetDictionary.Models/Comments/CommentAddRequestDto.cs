using SweetDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Models.Comments
{
    public sealed record CommentAddRequestDto(string Text, Guid PostId);
}

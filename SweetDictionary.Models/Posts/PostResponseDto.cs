using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Models.Posts;

public sealed record PostResponseDto {
    
    public Guid id { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public  string AuthorUserName { get; init; }
    public string CategoryName { get; init; }
}

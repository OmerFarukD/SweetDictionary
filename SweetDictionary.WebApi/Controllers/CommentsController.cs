using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Comments;
using SweetDictionary.Service.Abstract;
using System.Security.Claims;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public sealed class CommentsController(ICommentService _service) : ControllerBase
{


    [HttpPost("add")]
    public IActionResult Add([FromBody]CommentAddRequestDto dto)
    {
        string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

        var result = _service.Add(userId,dto);

        return Ok(result);
    }


    [HttpGet("getallbyuserid")]
    public IActionResult GetAllByUser()
    {
        string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

        var result = _service.GetAllCommentsByAuthor(userId);

        return Ok(result);
    }

}

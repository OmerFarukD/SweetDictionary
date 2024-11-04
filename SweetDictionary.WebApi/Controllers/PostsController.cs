using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Posts;
using SweetDictionary.Service.Abstract;
using System.Security.Claims;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PostsController(IPostService _postService) : ControllerBase
{
   
    [HttpGet("getall")]
    [Authorize(Roles = "User")]
    public IActionResult GetAll()
    {
        var result = _postService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody]CreatePostRequestDto dto)
    {

        // kullanıcının tokenden id alanının alınması.
        string authorId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _postService.Add(dto,authorId);
        return Ok(result);
    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById([FromRoute]Guid id)
    {

        var result = _postService.GetById(id);
        return Ok(result);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] UpdatePostRequestDto dto)
    {
        var result = _postService.Update(dto);
        return Ok(result);
    }

    [HttpGet("getallbycategoryid")]
    public IActionResult GetAllByCategoryId(int id)
    {
        var result = _postService.GetAllByCategoryId(id);
        return Ok(result);
    }

    [HttpGet("getallbyauthorid")]
    public IActionResult GetAllByAuthorId(string id)
    {
    
        var result = _postService.GetAllByAuthorId(id);
        return Ok(result);
    }

    [HttpGet("getallbytitlecontains")]
    public IActionResult GetAllByTitleContains(string text)
    {
        var result = _postService.GetAllByTitleContains(text);
        return Ok(result);
    }
}
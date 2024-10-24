using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Users;
using SweetDictionary.Service.Abstract;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService _userService) : ControllerBase
{


    [HttpPost("creeate")]
    public async Task<IActionResult> CreateUser([FromBody]RegisterRequestDto dto)
    {
        var result = await _userService.CreateUserAsync(dto);

        return Ok(result);
    }


    [HttpGet("getbyemail")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        var result = await _userService.GetByEmailAsync(email);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var result = await _userService.LoginAsync(dto);
        return Ok(result);
    }



}

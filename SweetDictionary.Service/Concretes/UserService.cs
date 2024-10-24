using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users;
using SweetDictionary.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Concretes;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
   
    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User> CreateUserAsync(RegisterRequestDto registerRequestDto)
    {
        User user = new User()
        {
            Email = registerRequestDto.Email,
            UserName = registerRequestDto.Username,
            BirthDate = registerRequestDto.BirthDate,
        };

        var result = await _userManager.CreateAsync(user,registerRequestDto.Password);

        return user;
    }



    public async Task<User> GetByEmailAsync(string email)
    {
        var user =await _userManager.FindByEmailAsync(email);
        if(user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        return user;
    }

    public async Task<User> LoginAsync(LoginRequestDto dto)
    {
        var userExist = await _userManager.FindByEmailAsync(dto.Email);
        if(userExist is null)
        {
            throw new NotFoundException("Bu mailde bir kullanıcı yok.");
        }

        var result = await _userManager.CheckPasswordAsync(userExist,dto.Password);

        if (result is false)
        {
            throw new NotFoundException("Parolanız yanlış.");
        }

        return userExist;
    }
}

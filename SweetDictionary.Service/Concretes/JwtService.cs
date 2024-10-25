﻿using Core.Tokens.Configuration;
using Microsoft.Extensions.Options;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Tokens;
using SweetDictionary.Service.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Concretes;

public class JwtService : IJwtService
{

    private readonly CustomTokenOptions _tokenOptions;
    public JwtService(IOptions<CustomTokenOptions> options)
    {
        _tokenOptions = options.Value;   
    }
    public TokenResponseDto CreateToken(User user)
    {
        throw new NotImplementedException();
    }

    private IEnumerable<Claim> GetClaims(User user,List<string> audiences)
    {
        var userList = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim("email",user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("mehmed_umud_hojam","Atejle Oynama")
        };
        userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud,x)));

        return userList;
    }
}
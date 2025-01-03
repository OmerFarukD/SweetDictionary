﻿using SweetDictionary.Models.Tokens;
using SweetDictionary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Abstract;

public interface IAuthenticationService
{

    Task<TokenResponseDto> RegisterByTokenAsync(RegisterRequestDto dto);
    Task<TokenResponseDto> LoginByTokenAsync(LoginRequestDto dto);
}

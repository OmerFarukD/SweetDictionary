﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Models.Tokens;

public sealed class TokenResponseDto
{
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
}

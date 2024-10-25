using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Abstract;

public interface IJwtService
{
    TokenResponseDto CreateToken(User user);
}

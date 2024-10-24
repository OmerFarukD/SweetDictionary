using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Abstract;

public interface IUserService
{
    Task<User> CreateUserAsync(RegisterRequestDto registerRequestDto);
    Task<User> GetByEmailAsync(string email);

    Task<User> LoginAsync(LoginRequestDto dto);

    Task<string> DeleteAsync(string id);

    Task<User> UpdateAsync();
        // Dto nesnesi alınacak güncellenmesi istenen yerler belirlenecek);


}

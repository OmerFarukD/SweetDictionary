using Core.Entities;
using StackExchange.Redis;
using SweetDictionary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Abstract
{
     public  interface IRoleService
    {
   

        Task<string> AddRoleToUser(RoleAddToUserRequestDto dto);

        Task<List<string>> GetAllRolesByUserId(string userId);

        Task<string> AddRoleAsync(string name);
    }
}

using Core.Repository;
using SweetDictionary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Repository.Repositories.Abstracts;

public interface ICategoryRepository : IRepository<Category,int>
{
}

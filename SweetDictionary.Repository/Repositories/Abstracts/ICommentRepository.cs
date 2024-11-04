

using Core.Repository;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Contexts;

namespace SweetDictionary.Repository.Repositories.Abstracts;

public interface ICommentRepository : IRepository<Comment,Guid>
{

}

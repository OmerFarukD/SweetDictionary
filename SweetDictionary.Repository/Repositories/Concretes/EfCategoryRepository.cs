using Core.Repository;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Contexts;
using SweetDictionary.Repository.Repositories.Abstracts;

namespace SweetDictionary.Repository.Repositories.Concretes;

public class EfCategoryRepository : EfRepositoryBase<BaseDbContext,Category,int>, ICategoryRepository
{

    public EfCategoryRepository(BaseDbContext context) : base(context)
    {
        
    }
}

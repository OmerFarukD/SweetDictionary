

using Core.Exceptions;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Constants;

namespace SweetDictionary.Service.Rules;

public class PostBusinessRules(IPostRepository _postRepository)
{


    public virtual bool PostIsPresent(Guid id)
    {
        var post = _postRepository.GetById(id);
        if(post is null)
        {
            throw new NotFoundException(Messages.PostIsNotPresentMessage(id));
        }

        return true;



    }


    public void PostTitleMustBeUnique(string title)
    {
        var post = _postRepository.GetAll(x=> x.Title == title);
        if (post.Count > 0)
        {
            throw new BusinessException("Post benzersiz olmalı.");
        }
    }

}

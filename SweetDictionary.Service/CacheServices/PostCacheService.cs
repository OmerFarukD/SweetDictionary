

using Core.Exceptions;
using Microsoft.Extensions.Caching.Distributed;
using SweetDictionary.Models.Posts;
using System.Text.Json;

namespace SweetDictionary.Service.CacheServices;

public sealed class PostCacheService(IDistributedCache cache)
{
    public async Task<PostResponseDto> GetPostByIdAsync(Guid id)
    {
        string cacheKey = $"Post({id})";
        string cachedPost = await cache.GetStringAsync(cacheKey);


        if (string.IsNullOrEmpty(cachedPost))
        {
            throw new BusinessException("İlgili post Cache de yok");
        }

        PostResponseDto post = JsonSerializer.Deserialize<PostResponseDto>(cachedPost);
        return post;
    }

    public async Task<PostResponseDto> CreatePostAsync(PostResponseDto post)
    {
        string cacheKey = $"Post({post.id})";
        var serializePost = JsonSerializer.Serialize(post);

        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
        };

        await cache.SetStringAsync(cacheKey,serializePost,options);

        return post;
    }


    // post(1): {'id': değeri, 'title': değeri }
    public async Task DeleteAsync(Guid id)
    {
        string cacheKey = $"Post({id})";
        await cache.RemoveAsync(cacheKey);

    }

}

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SweetDictionary.Service.Abstract;
using SweetDictionary.Service.CacheServices;
using SweetDictionary.Service.Concretes;

using SweetDictionary.Service.Rules;

using System.Reflection;


namespace SweetDictionary.Service;

public static class ServiceDependencies
{
    public static IServiceCollection AddServiceDependenies(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<PostCacheService>();
        services.AddScoped<PostBusinessRules>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = "localhost:6379";
            opt.InstanceName = "SweetDictionary";
        }); 


        return services;
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Configurations;
using System.Reflection;

namespace SweetDictionary.Repository.Contexts;

public class BaseDbContext : IdentityDbContext<User,IdentityRole,string>
{

    public BaseDbContext(DbContextOptions opt): base(opt)
    {
        
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    public DbSet<Post> Posts { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Comment> Comments { get; set; }

}

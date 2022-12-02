using System.Reflection;
using Ef_7_IMaterializationInterceptor.Context.Interceptors;
using Ef_7_IMaterializationInterceptor.Models;
using Microsoft.EntityFrameworkCore;

namespace Ef_7_IMaterializationInterceptor.Context;

public class ApplicationContext:DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new SetRetrievedInterceptor());
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Post> Posts { get; set; }
}
using Ef_7_IMaterializationInterceptor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ef_7_IMaterializationInterceptor.Context.Configurations;

public class PostConfiguration:IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Ignore(q => q.Retrieved);
    }
}
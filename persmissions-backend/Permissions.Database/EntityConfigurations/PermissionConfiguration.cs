using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permissions.Domain.Entities;

namespace Permissions.Database.EntityConfigurations
{
    class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(_ => _.FirstnameEmployee).IsRequired();
            builder.Property(_ => _.LastnameEmployee).IsRequired();
        }
    }
}

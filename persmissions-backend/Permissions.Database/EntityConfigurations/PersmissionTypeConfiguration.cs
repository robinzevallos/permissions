using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permissions.Domain.Entities;

namespace Permissions.Database.EntityConfigurations
{
    class PersmissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(_ => _.Description).IsRequired();
            builder.HasIndex(_ => _.Description).IsUnique();
        }
    }
}

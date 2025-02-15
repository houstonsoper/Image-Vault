using imagevault.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace imagevault.api.Configurations;

public class UserGroupEntityTypeConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.HasData(
            new UserGroup {GroupId = 1, GroupName = "Default"},
            new UserGroup {GroupId = 2, GroupName = "Admin"}
        );
    }
}
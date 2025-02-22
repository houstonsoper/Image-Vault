using imagevault.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace imagevault.api.Configurations;

public class LikeEntityTypeConfiguration : IEntityTypeConfiguration<Like>
{
	public void Configure(EntityTypeBuilder<Like> builder)
	{
		builder
			.HasOne(l => l.Post)
			.WithOne()
			.HasForeignKey<Like>(l => l.PostId)
			.OnDelete(DeleteBehavior.NoAction);

		builder
			.HasOne(l => l.User)
			.WithOne()
			.HasForeignKey<Like>(l => l.UserId)
			.OnDelete(DeleteBehavior.NoAction);
	}
}
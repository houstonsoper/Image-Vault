using imagevault.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace imagevault.api.Configurations;

public class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
{
	public void Configure(EntityTypeBuilder<Comment> builder)
	{
		builder.HasKey(c => c.Id);

		builder
			.HasOne(c => c.Post)
			.WithOne()
			.HasForeignKey<Comment>(c => c.PostId)
			.OnDelete(DeleteBehavior.Restrict);
		
		builder
			.HasOne(c => c.User)
			.WithOne()
			.HasForeignKey<Comment>(c => c.UserId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
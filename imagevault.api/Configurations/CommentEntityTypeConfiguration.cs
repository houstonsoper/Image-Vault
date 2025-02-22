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
			.WithMany()
			.HasForeignKey(c => c.PostId)
			.OnDelete(DeleteBehavior.Restrict);
		
		builder
			.HasOne(c => c.User)
			.WithMany()
			.HasForeignKey(c => c.UserId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
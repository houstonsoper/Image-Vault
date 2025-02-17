using imagevault.api.Contexts;
using imagevault.api.Models;
using Microsoft.EntityFrameworkCore;

namespace imagevault.api.Repositories;

public class PostRepository : IPostRepository
{
	private readonly ImageVaultDbContext _dbContext;

	public PostRepository(ImageVaultDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	
	public async Task CreatePostAsync(Post post)
	{
		await _dbContext.Posts.AddAsync(post);
		await _dbContext.SaveChangesAsync();
	}

	public async Task<Post?> GetPostByIdAsync(Guid postId)
	{
		return await _dbContext.Posts.FindAsync(postId);
	}
	public IQueryable<Post> GetPostsQuery()
	{
		return _dbContext.Posts
			.Include(p => p.Images)
			.AsQueryable();
	}
}
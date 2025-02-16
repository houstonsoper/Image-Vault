using imagevault.api.Contexts;
using imagevault.api.Models;

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
}
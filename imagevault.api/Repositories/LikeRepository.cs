using imagevault.api.Contexts;
using imagevault.api.Models;
using Microsoft.EntityFrameworkCore;

namespace imagevault.api.Repositories;

public class LikeRepository : ILikeRepository
{
	private readonly ImageVaultDbContext _context;

	public LikeRepository(ImageVaultDbContext context)
	{
		_context = context;
		_context.SaveChanges();
	}
	
	public async Task AddLikeAsync(Like like)
	{
		await _context.Likes.AddAsync(like);
	}

	public async Task RemoveLikeAsync(Like like)
	{
		_context.Likes.Remove(like);
		await _context.SaveChangesAsync();
	}

	public async Task<Like?> GetLikeByIdAsync(Guid postId, Guid userId)
	{
		return await _context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
	}

	public async Task<int?> GetLikesOnPostCountAsync(Guid postId)
	{
		return await _context.Likes.CountAsync(l => l.PostId == postId);
	}
}
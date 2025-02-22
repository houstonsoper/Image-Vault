using imagevault.api.Models;
using imagevault.api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace imagevault.api.Services;

public class CommentService : ICommentService
{
	private readonly IGenericRepository<Comment> _commentRepository;
	private readonly IUserService _userService;
	private readonly IPostService _postService;

	public CommentService(IGenericRepository<Comment> commentRepository, IUserService userService, IPostService postService)
	{
		_commentRepository = commentRepository;
		_userService = userService;
		_postService = postService;
	}
	
	public async Task AddCommentAsync(Comment comment)
	{
		//Check Post and User exist
		await _userService.GetUserByIdAsync(comment.UserId);
		await _postService.GetPostByIdAsync(comment.PostId);
		
		await _commentRepository.AddAsync(comment);
		await _commentRepository.SaveAsync();
	}

	public async Task DeleteCommentAsync(Comment comment)
	{
		//Check Post and User exist
		await _userService.GetUserByIdAsync(comment.UserId);
		await _postService.GetPostByIdAsync(comment.PostId);
		
		_commentRepository.Delete(comment);
		await _commentRepository.SaveAsync();
	}

	public async Task UpdateCommentAsync(Comment comment)
	{
		//Check Post and User exist
		await _userService.GetUserByIdAsync(comment.UserId);
		await _postService.GetPostByIdAsync(comment.PostId);
		
		_commentRepository.Update(comment);
		await _commentRepository.SaveAsync();
	}

	public async Task<List<Comment>> GetCommentsAsync(Guid postId, int? limit, int? offset)
	{
		var query = _commentRepository.GetAllQuery();
		
		query = query.Where(c => c.PostId == postId);

		if (offset.HasValue && offset != 0)
			query = query.Skip(offset.Value);
		
		if (limit.HasValue && limit.Value != 0)
			query = query.Take(limit.Value);

		return await query.ToListAsync();
	}

	public async Task<Comment> GetCommentByPostAndUserIdAsync(Guid postId, Guid userId)
	{
		var query = _commentRepository.GetAllQuery();
		query = query.Where(c => c.PostId == postId && c.UserId == userId);
		
		return await query.FirstOrDefaultAsync()
			?? throw new InvalidOperationException("No Comment Found");
	}

	public async Task<Comment> GetCommentById(Guid commentId)
	{
		return await _commentRepository.GetByIdAsync(commentId)
			?? throw new InvalidOperationException("No Comment Found");
	}
}
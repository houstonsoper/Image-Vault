using imagevault.api.Contexts;
using imagevault.api.Models;
using imagevault.api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace imagevault.api.Services;

public class PostService : IPostService
{
	private readonly IPostRepository _postRepository;
	private readonly IUserService _userService;

	public PostService(IPostRepository postRepository, IUserService userService)
	{
		_postRepository = postRepository;
		_userService = userService;
	}

	public async Task CreatePostAsync(Post post)
	{
		//Check if user exists
		var user = await _userService.GetUserByIdAsync(post.UserId)
			?? throw new KeyNotFoundException ("User not found");

		//Create the post
		try
		{
			await _postRepository.CreatePostAsync(post);
		}
		catch (Exception ex)
		{
			throw new Exception ("An error occured while creating a post");
		}
	}
	public Task<List<Post>> GetPostsAsync(int? limit, int? offset, string? search)
	{
		var query = _postRepository.GetPostsQuery();
		
		if(offset.HasValue && offset != 0)
			query = query.Skip(offset.Value);
		
		if (limit.HasValue && limit.Value != 0)
			query = query.Take(limit.Value);

		if (!string.IsNullOrEmpty(search))
			query = query.Where(p => p.Title.ToLower().Contains(search.ToLower()));

		return query.ToListAsync();
	}
}
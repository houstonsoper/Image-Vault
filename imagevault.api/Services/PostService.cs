using imagevault.api.Contexts;
using imagevault.api.Models;
using imagevault.api.Repositories;

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
}
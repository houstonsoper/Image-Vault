using imagevault.api.Models;
using imagevault.api.Repositories;

namespace imagevault.api.Services;

public class LikesService : ILikesService
{
	private readonly ILikesRepository _likesRepository;
	private readonly IPostService _postService;
	private readonly IUserService _userService;

	public LikesService(ILikesRepository likesRepository, IPostService postService, IUserService userService)
	{
		_likesRepository = likesRepository;
		_postService = postService;
		_userService = userService;
	}
		
	public async Task AddLikeAsync(Like like)
	{
		var post = await _postService.GetPostByIdAsync(like.PostId)
			?? throw new NullReferenceException("Post not found");
		
		var user = await _userService.GetUserByIdAsync(like.UserId)
			?? throw new NullReferenceException("User not found");

		await _likesRepository.AddLikeAsync(like);
	}

	public async Task RemoveLikeAsync(Guid postId, Guid userId)
	{
		var like = await _likesRepository.GetLikeByIdAsync(postId, userId)
			?? throw new InvalidOperationException("Like not found");
		
		await _likesRepository.RemoveLikeAsync(like);
	}

	public async Task<int> GetLikesOnPostCountAsync(Guid postId)
	{
		var post = await _postService.GetPostByIdAsync(postId);
		
		return await _likesRepository.GetLikesOnPostCountAsync(post.Id)
			?? throw new InvalidOperationException("Post not found");
	}
}
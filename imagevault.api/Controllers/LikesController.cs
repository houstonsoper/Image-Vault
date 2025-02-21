using imagevault.api.DTOs;
using imagevault.api.Extensions;
using imagevault.api.Models;
using imagevault.api.Repositories;
using imagevault.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace imagevault.api.Controllers;
[ApiController]
[Route("[controller]")]

public class LikesController : ControllerBase
{
	private readonly ILikesService _likesService;
	private readonly ILikesRepository _likesRepository;

	public LikesController(ILikesService likesService, ILikesRepository likesRepository)
	{
		_likesService = likesService;
		_likesRepository = likesRepository;
	}
	
	[HttpGet("{postId}/count")]
	public async Task<IActionResult> GetLikesOnPostCount([FromRoute] Guid postId)
	{
		var likesCount = await _likesService.GetLikesOnPostCountAsync(postId);
		return Ok(likesCount);
	}

	[HttpPost]
	public async Task<IActionResult> AddLike([FromBody] LikePostDto likePostDto)
	{
		await _likesService.AddLikeAsync(likePostDto.ToLike());
		return Ok("Like added");
	}
	
	[HttpDelete("{postId}/{userId}")]
	public async Task<IActionResult> RemoveLike ([FromRoute] Guid postId, [FromRoute] Guid userId)
	{
		await _likesService.RemoveLikeAsync(postId, userId);
		return Ok("Like removed");
	}

	[HttpGet("{postId}/{userId}")]
	public async Task<IActionResult> HasUserLikedPost([FromRoute] Guid postId, [FromRoute] Guid userId)
	{
		var hasUserLikedPost = await _likesRepository.HasUserLikedPostAsync(postId, userId);
		return Ok(hasUserLikedPost);
	}
}
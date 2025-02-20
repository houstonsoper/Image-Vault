using imagevault.api.DTOs;
using imagevault.api.Extensions;
using imagevault.api.Models;
using imagevault.api.Repositories;
using imagevault.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace imagevault.api.Controllers;
[ApiController]
[Route("[controller]")]

public class LikeController : ControllerBase
{
	private readonly ILikeService _likeService;

	public LikeController(ILikeService likeService)
	{
		_likeService = likeService;
	}
	
	[HttpGet("{postId}")]
	public async Task<IActionResult> GetLikesOnPostCount([FromRoute] Guid postId)
	{
		var likesCount = await _likeService.GetLikesOnPostCountAsync(postId);
		return Ok(likesCount);
	}

	[HttpPost]
	public async Task<IActionResult> AddLike([FromBody] LikePostDto likePostDto)
	{
		await _likeService.AddLikeAsync(likePostDto.ToLike());
		return Ok("Like added");
	}
	
	[HttpDelete("{postId}/{userId}")]
	public async Task<IActionResult> RemoveLike ([FromRoute] Guid postId, [FromRoute] Guid userId)
	{
		await _likeService.RemoveLikeAsync(postId, userId);
		return Ok("Like removed");
	}
}
using imagevault.api.DTOs;
using imagevault.api.Extensions;
using imagevault.api.Repositories;
using imagevault.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace imagevault.api.Controllers;
[ApiController]
[Route("[controller]")]

public class PostController : ControllerBase
{
	private readonly IImageService _imageService;
	private readonly IPostService _postService;

	public PostController(IImageService imageService, IPostService postService)
	{
		_imageService = imageService;
		_postService = postService;
	}
	
	[HttpPost("create")]
	public async Task<IActionResult> CreatePost([FromBody] PostDto postDto)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		
		var post = postDto.ToPostFromCreatePostDto();
		await _postService.CreatePostAsync(post);
		
		return Ok(post.ToPostRequestDto());
	}
	
	[HttpPost ("{postId}/images/upload")]
	public async Task<IActionResult> UploadImage([FromForm] UploadImageDto image, [FromRoute] Guid postId)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		
		await _imageService.UploadImageAsync(image.ToImageFromUploadImageDto(), postId);
		
		return Ok("Image uploaded");
	}
	
	[HttpGet ("{postId}/images")]
	public async Task<IActionResult> GetImagesByPostId([FromRoute] Guid postId)
	{
		var images = await _imageService.GetImagesByPostIdAsync(postId);
		var imagesDto = images.Select(i => i.ToImageRequestDto());
		return Ok(imagesDto);
	}
}
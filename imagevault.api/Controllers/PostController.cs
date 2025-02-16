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
	private readonly IPostRepository _postRepository;

	public PostController(IImageService imageService, PostRepository postRepository)
	{
		_imageService = imageService;
		_postRepository = postRepository;
	}
	
	[HttpPost("create")]
	public async Task<IActionResult> CreatePost(CreatePostDto createPostDto)
	{
		await _postRepository.CreatePostAsync(createPostDto.ToPostFromCreatePostDto());
		return Ok("Post created");
	}
}
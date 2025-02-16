using imagevault.api.DTOs;
using imagevault.api.Extensions;
using imagevault.api.Models;
using imagevault.api.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace imagevault.api.Controllers;
[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
	private readonly IImageService _imageService;

	public ImageController(IImageService imageService)
	{
		_imageService = imageService;
	}
	
	[HttpPost ("upload")]
	public async Task<IActionResult> UploadImage([FromForm] UploadImageDto image)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		await _imageService.UploadImageAsync(image.ToImageFromUploadImageDto());
			
		return Ok("Image uploaded");
	}
}
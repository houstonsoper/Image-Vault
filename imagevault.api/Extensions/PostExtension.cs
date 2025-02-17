using imagevault.api.DTOs;
using imagevault.api.Models;

namespace imagevault.api.Extensions;

public static class PostExtension
{
	public static Post ToPostFromCreatePostDto (this PostDto postDto)
	{
		return new Post
		{
			Id = Guid.NewGuid (),
			Title = postDto.Title,
			Description = postDto.Description,
			Date = DateTime.UtcNow,
			IsActive = true,
			UserId = postDto.UserId
		};
	}

	public static PostRequestDto ToPostRequestDto(this Post post)
	{
		return new PostRequestDto
		{
			Id = post.Id,
			Title = post.Title,
			Description = post.Description,
			Date = post.Date,
			IsActive = post.IsActive,
			UserId = post.UserId
		};
	}

	public static PostRequestWithImagesDto ToPostRequestWithImagesDto(this Post post)
	{
		return new PostRequestWithImagesDto
		{
			Id = post.Id,
			Title = post.Title,
			Description = post.Description,
			Date = post.Date,
			IsActive = post.IsActive,
			UserId = post.UserId,
			Images = post.Images.Select(i => i.ToImageRequestDto())
		};
	}
}
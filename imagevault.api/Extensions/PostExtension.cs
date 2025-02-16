using imagevault.api.DTOs;
using imagevault.api.Models;

namespace imagevault.api.Extensions;

public static class PostExtension
{
	public static Post ToPostFromCreatePostDto (this PostDto dto)
	{
		return new Post
		{
			Id = Guid.NewGuid (),
			Title = dto.Title,
			Description = dto.Description,
			Date = DateTime.UtcNow,
			IsActive = true,
			UserId = dto.UserId
		};
	}

	public static PostRequestDto ToPostRequestDto(this Post dto)
	{
		return new PostRequestDto
		{
			Id = dto.Id,
			Title = dto.Title,
			Description = dto.Description,
			Date = dto.Date,
			IsActive = dto.IsActive,
			UserId = dto.UserId
		};
	}
}
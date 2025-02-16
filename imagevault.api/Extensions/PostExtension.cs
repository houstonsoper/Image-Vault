using imagevault.api.DTOs;
using imagevault.api.Models;

namespace imagevault.api.Extensions;

public static class PostExtension
{
	public static Post ToPostFromCreatePostDto (this CreatePostDto dto)
	{
		return new Post
		{
			Id = default,
			Title = dto.Title,
			Description = dto.Description,
			Date = default,
			IsActive = false,
			UserId = dto.UserId
		};
	}
}
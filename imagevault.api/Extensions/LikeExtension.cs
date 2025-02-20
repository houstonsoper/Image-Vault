using imagevault.api.DTOs;
using imagevault.api.Models;

namespace imagevault.api.Extensions;

public static class LikeExtension
{
	public static Like ToLike(this LikePostDto likePostDto)
	{
		return new Like
		{
			Id = Guid.NewGuid(),
			PostId = likePostDto.PostId,
			UserId = likePostDto.UserId,
			Date = DateTime.UtcNow
		};
	}

	public static LikeRequestDto ToLikeRequestDto(this Like like)
	{
		return new LikeRequestDto
		{
			Id = like.PostId,
			PostId = like.PostId,
			UserId = like.UserId,
			Date = like.Date,
		};
	}
}
using imagevault.api.DTOs;
using imagevault.api.Models;

namespace imagevault.api.Extensions;

public static class ImageExtension
{
	public static Image ToImageFromUploadImageDto(this ImagePostDto postDto)
	{
		return new Image
		{
			Id = Guid.NewGuid(),
			UploadTime = DateTime.UtcNow,
		};
	}

	public static ImageRequestDto ToImageRequestDto(this Image dto)
	{
		return new ImageRequestDto
		{
			Id = dto.Id,
			UploadTime = dto.UploadTime,
			IsDeleted = dto.IsDeleted
		};
	}
}
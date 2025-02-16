using imagevault.api.DTOs;
using imagevault.api.Models;

namespace imagevault.api.Extensions;

public static class ImageExtension
{
	public static Image ToImageFromUploadImageDto(this UploadImageDto dto)
	{
		return new Image
		{
			Id = Guid.NewGuid(),
			UploadTime = DateTime.UtcNow,
			ImageFile = dto.ImageFile
		};
	}
}
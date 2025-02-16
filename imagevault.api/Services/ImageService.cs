using imagevault.api.Models;
using imagevault.api.Repositories;

namespace imagevault.api.Services;

public class ImageService : IImageService
{
	private readonly IImageRepository _imageRepository;
	
	public ImageService(IImageRepository imageRepository)
	{
		_imageRepository = imageRepository;
	}
	
	public async Task UploadImageAsync(Image image, Guid postId)
	{
		//Upload to file area
		try
		{
			var path = Path.Combine(@"C:\Users\houst\RiderProjects\Image Vault\imagevault.api\Images", image.Id.ToString());
			await using var stream = new FileStream(path, FileMode.Create);

			if (image.ImageFile == null)
				throw new FileNotFoundException("Image file was not found");
			
			await image.ImageFile.CopyToAsync(stream);
		}
		catch (Exception e)
		{
			throw new IOException($"Unable to upload image {image.ImageFile?.FileName ?? "unknown"}");
		}
		
		//Upload to database
		try
		{
			var newImage = new Image {
				Id = image.Id,
				UploadTime = image.UploadTime,
				PostId = postId,
				IsDeleted = image.IsDeleted,
			};
			await _imageRepository.AddImagesAsync(newImage);
		}
		catch (Exception e)
		{
			throw new IOException($"Unable to add {image.ImageFile.FileName} to database");
		}
	}
}
using imagevault.api.Models;

namespace imagevault.api.Services;

public class ImageService : IImageService
{
	public async Task UploadImagesAsync(IEnumerable<Image> images)
	{
		try
		{
			await Parallel.ForEachAsync(images, async (image, cancellationToken) =>
			{
				var path = Path.Combine(@"C:\Users\houst\RiderProjects\Image Vault\imagevault.api\Images", image.Id.ToString());
				await using var stream = new FileStream(path, FileMode.Create);
				await image.ImageFile.CopyToAsync(stream, cancellationToken);
			});
		}
		catch (Exception e)
		{
			throw new IOException("Unable to upload images");
		}
	}

	public async Task UploadImageAsync(Image image)
	{
		try
		{
			var path = Path.Combine(@"C:\Users\houst\RiderProjects\Image Vault\imagevault.api\Images", image.Id.ToString());
			await using var stream = new FileStream(path, FileMode.Create);
			await image.ImageFile.CopyToAsync(stream);
		}
		catch (Exception e)
		{
			throw new IOException("Unable to upload images");
		}
	}
}
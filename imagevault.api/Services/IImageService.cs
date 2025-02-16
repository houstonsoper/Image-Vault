using imagevault.api.Models;

namespace imagevault.api.Services;

public interface IImageService
{
	Task UploadImagesAsync (IEnumerable<Image> images);
	Task UploadImageAsync (Image image);
}
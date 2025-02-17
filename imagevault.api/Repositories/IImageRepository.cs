using imagevault.api.Models;

namespace imagevault.api.Repositories;

public interface IImageRepository
{
	Task AddImagesAsync(Image image);
	Task <IEnumerable<Image>> GetImagesByPostIdAsync(Guid postId);
}
using imagevault.api.Contexts;
using imagevault.api.Models;

namespace imagevault.api.Repositories;

public class ImageRepository : IImageRepository
{
	private readonly ImageVaultDbContext _dbContext;

	public ImageRepository(ImageVaultDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	
	public async Task AddImagesAsync(Image image)
	{
			await _dbContext.Images.AddAsync(image);
			await _dbContext.SaveChangesAsync(); 
	} 
}

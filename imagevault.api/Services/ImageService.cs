using imagevault.api.Models;
using imagevault.api.Repositories;

namespace imagevault.api.Services;

public class ImageService : IImageService
{
	private readonly IImageRepository _imageRepository;
	private readonly IPostRepository _postRepository;
	
	public ImageService(IImageRepository imageRepository, IPostRepository postRepository)
	{
		_imageRepository = imageRepository;
		_postRepository = postRepository;
	}
	
	public async Task UploadImageAsync(Image image, Guid postId)
	{
		//Upload to file area
		try
		{
			if (image.ImageFile == null)
				throw new FileNotFoundException("Image file was not found");
			
			//Check if the file is an accepted image type
			var fileExtension = Path.GetExtension(image.ImageFile.FileName).ToLower();
			var allowedExtensions = new[] { ".jpg", ".jpeg", ".png"};
			
			if (!allowedExtensions.Contains(fileExtension))
				throw new FormatException("Invalid file extension, only jpg, jpeg, and .png format are supported");
			
			//Upload the image to file
			var path = Path.Combine(@"C:\Users\houst\RiderProjects\Image Vault\imagevault.api\Images", image.Id.ToString() + fileExtension);
			await using var stream = new FileStream(path, FileMode.Create);
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

	public async Task<List<Image>> GetImagesByPostIdAsync(Guid postId)
	{
		var post = await _postRepository.GetPostByIdAsync(postId)
			?? throw new KeyNotFoundException("No post was found");

		var images = await _imageRepository.GetImagesByPostIdAsync(post.Id);
		var imageList = images.ToList();
		
		if (imageList.Count == 0)
			throw new InvalidOperationException("No images were found for this post");

		return imageList;
	}
}
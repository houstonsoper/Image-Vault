﻿using imagevault.api.Models;

namespace imagevault.api.Services;

public interface IImageService
{
	Task UploadImageAsync (Image image, Guid postId);
	Task <List<Image>> GetImagesByPostIdAsync (Guid postId);
}
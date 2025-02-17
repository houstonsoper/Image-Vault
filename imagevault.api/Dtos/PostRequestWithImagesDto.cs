using imagevault.api.Models;

namespace imagevault.api.DTOs;

public class PostRequestWithImagesDto
{
	public Guid Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public DateTime Date { get; set; }
	public bool IsActive { get; set; }
	public Guid UserId { get; set; }
	public IEnumerable<ImageRequestDto> Images { get; set; } = [];
}
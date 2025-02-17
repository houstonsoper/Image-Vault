namespace imagevault.api.DTOs;

public class ImageRequestDto
{
	public Guid Id { get; set; }
	public DateTime UploadTime { get; set; } 
	public bool IsDeleted { get; set; }
	
	public string Path { get; set; } = string.Empty;
}
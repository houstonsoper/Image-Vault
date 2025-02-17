using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imagevault.api.Models;

public class Image
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public DateTime UploadTime { get; set; } = DateTime.UtcNow;
	public Guid? PostId { get; set; }
	public bool IsDeleted { get; set; }
	
	[StringLength(10)]
	public string? Extension { get; set; }
	
	[StringLength(500, ErrorMessage = "Image path exceeds 500 characters.")]
	
	[NotMapped]
	public IFormFile? ImageFile { get; set; }
	
	//Navigation
	public Post? Post { get; set; }
}
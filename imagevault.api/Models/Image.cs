using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imagevault.api.Models;

public class Image
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public DateTime UploadTime { get; set; } = DateTime.Now;
	public Guid PostId { get; set; } = Guid.NewGuid();
	public bool IsDeleted { get; set; } = false;
	
	//Navigation
	[NotMapped]
	public required IFormFile ImageFile { get; set; }
	
	public Post? Post { get; set; }
}
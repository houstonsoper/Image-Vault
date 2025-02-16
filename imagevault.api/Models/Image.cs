using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imagevault.api.Models;

public class Image
{
	public Guid Id { get; set; }
	public DateTime UploadTime { get; set; } 
	public Guid PostId { get; set; } 
	public bool IsDeleted { get; set; }
	
	//Navigation
	[NotMapped]
	public IFormFile? ImageFile { get; set; }
	
	public Post? Post { get; set; }
}
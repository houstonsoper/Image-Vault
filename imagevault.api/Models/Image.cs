using System.ComponentModel.DataAnnotations;

namespace imagevault.api.Models;

public class Image
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public required IFormFile ImageFile { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace imagevault.api.Models;

public class Like
{
	public Guid Id { get; set; }
	[Required (ErrorMessage="Post ID is required")]
	
	public required Guid PostId { get; set; }
	
	[Required (ErrorMessage="User ID is required")]
	public required Guid UserId { get; set; }
	public DateTime Date { get; set; } = DateTime.UtcNow;
	
	//Navigation
	public Post? Post { get; set; }
	public User? User { get; set; }
}
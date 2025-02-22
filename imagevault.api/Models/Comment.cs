using System.ComponentModel.DataAnnotations;

namespace imagevault.api.Models;

public class Comment
{
	public Guid Id { get; set; }

	[Required (ErrorMessage="Comment is required")]
	[StringLength(200, MinimumLength = 5, ErrorMessage="Comment must be between 5 and 200 characters")]
	public required string Content { get; set; }
	
	[Required (ErrorMessage="Post Id is required")]
	public required Guid PostId { get; set; }
	
	[Required (ErrorMessage="User Id is required")]
	public required Guid UserId { get; set; }
	
	public DateTime DateCreated { get; set; } = DateTime.UtcNow;
	
	//Navigation
	public Post? Post { get; set; }
	public User? User { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace imagevault.api.Models;

public class Post
{
	public Guid Id { get; set; }
	
	[Required (ErrorMessage=("Title is required"))]
	[StringLength(100, ErrorMessage ="Title must be between 5 and 100 characters", MinimumLength = 5)]
	public required string Title { get; set; } 
	
	[Required (ErrorMessage=("Description is required"))]
	[StringLength(200, ErrorMessage ="Description must be between 5 and 200 characters", MinimumLength = 5)]
	public required string Description { get; set; } 
	
	public DateTime Date { get; set; }
	
	public bool IsActive { get; set; }
	
	[Required (ErrorMessage ="Please enter a User Id")]
	public Guid UserId { get; set; }
	
	//Navigation
	public User? User { get; set; }
	public IEnumerable<Image> Images { get; set; } = [];
}
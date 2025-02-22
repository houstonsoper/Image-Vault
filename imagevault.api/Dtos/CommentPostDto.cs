using System.ComponentModel.DataAnnotations;

namespace imagevault.api.DTOs;

public class CommentPostDto
{
	[Required (ErrorMessage="Comment is required")]
	[StringLength(200, MinimumLength = 5, ErrorMessage="Comment must be between 5 and 200 characters")]
	public required string Content { get; set; }
	
	[Required (ErrorMessage="Post Id is required")]
	public required Guid PostId { get; set; }
	
	[Required (ErrorMessage="User Id is required")]
	public required Guid UserId { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace imagevault.api.DTOs;

public class LikePostDto
{
	[Required (ErrorMessage="Post ID is required")]
	public required Guid PostId { get; set; }
	
	[Required (ErrorMessage="User ID is required")]
	public required Guid UserId { get; set; }
}
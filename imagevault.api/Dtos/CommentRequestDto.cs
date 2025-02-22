namespace imagevault.api.DTOs;

public class CommentRequestDto
{
	public Guid Id { get; set; }

	public string Content { get; set; } = string.Empty;
	
	public Guid PostId { get; set; }
	
	public Guid UserId { get; set; }
	
	public DateTime DateCreated { get; set; }
}
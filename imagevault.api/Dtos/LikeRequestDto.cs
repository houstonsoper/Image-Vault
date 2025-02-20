using System.ComponentModel.DataAnnotations;

namespace imagevault.api.DTOs;

public class LikeRequestDto
{
	public Guid Id { get; set; }
	public required Guid PostId { get; set; }
	public required Guid UserId { get; set; }
	public DateTime Date { get; set; }
}
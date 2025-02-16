namespace imagevault.api.Models;

public class PostImage
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public Guid ImageId { get; set; } 
	public Guid PostId { get; set; }
	
	//Navigation
	public Image? Image { get; set; }
	public Post? Post { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace imagevault.api.Models;

public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    
    [Required (ErrorMessage = "Username is required")]
    [StringLength(20, ErrorMessage = "Username must be between 5 and 20 characters", MinimumLength = 5)]
    public required string Username { get; set; }
    
    [Required (ErrorMessage = "Email is required")]
    [StringLength(254, ErrorMessage = "Email must be between 5 and 254 characters", MinimumLength = 5)]
    public required string Email { get; set; }
    
    [Required (ErrorMessage = "Password is required")]
    [StringLength(15, ErrorMessage = "Password must be between 5 and 15 characters", MinimumLength = 5)]
    [NotMapped] 
    public required string Password { get; set; }
    
    public int UserGroupId { get; set; } = 1;

    public DateTime CreateDateTime { get; set; } = DateTime.UtcNow;
    
    //Navigation
    public UserGroup? UserGroup { get; set; }
}

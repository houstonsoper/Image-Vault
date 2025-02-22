﻿using imagevault.api.Models;

namespace imagevault.api.DTOs;

public class UserRequestDto
{
    public Guid UserId { get; set; }
    public required string Username{ get; set; }
    public string Email { get; set; } = string.Empty;
    
    public UserGroup? UserGroup { get; set; } 
}
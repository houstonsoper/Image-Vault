using imagevault.api.DTOs;
using imagevault.api.Models;

namespace imagevault.api.Extensions;

public static class UserExtension 
{
    public static UserRegistrationDto ToUserRegistrationDto(this User user)
    {
        return new UserRegistrationDto
        {
            Username = user.Username,
            Email = user.Email,
            Password = user.Password,
        };
    }

    public static UserRequestDto ToUserRequestDto(this User user)
    {
        return new UserRequestDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email,
            UserGroup = user.UserGroup,
        };
    }

    public static UserLoginDto ToUserLoginDto(this User user)
    {
        return new UserLoginDto
        {
            Email = user.Email,
            Password = user.Password
        };
    }
}
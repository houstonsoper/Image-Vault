using imagevault.api.Models;

namespace imagevault.api.Services;

public interface IPasswordTokenService
{
    public Task<PasswordResetToken?> CreatePasswordResetTokenAsync(string email);
    public Task<PasswordResetToken?> GetTokenByTokenIdAsync(Guid tokenId);
}
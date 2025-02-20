using imagevault.api.Models;

namespace imagevault.api.Services;

public interface ILikeService
{
	Task AddLikeAsync(Like like);
	Task RemoveLikeAsync(Guid postId, Guid userId);
	Task<int> GetLikesOnPostCountAsync (Guid postId);
}
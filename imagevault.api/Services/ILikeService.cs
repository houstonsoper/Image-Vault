using imagevault.api.Models;

namespace imagevault.api.Services;

public interface ILikeService
{
	Task AddLikeAsync(Like like);
	Task RemoveLikeAsync(Like like);
	Task<int> GetLikesOnPostAsync (Guid postId);
}
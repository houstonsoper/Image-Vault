using imagevault.api.Models;

namespace imagevault.api.Repositories;

public interface ILikesRepository
{
	Task AddLikeAsync(Like like);
	Task RemoveLikeAsync(Like like);
	Task <Like?> GetLikeByIdAsync(Guid postId, Guid userId);
	Task<int?> GetLikesOnPostCountAsync (Guid postId);
	Task<bool> HasUserLikedPostAsync(Guid postId, Guid userId);
}
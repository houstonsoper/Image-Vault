using imagevault.api.Models;

namespace imagevault.api.Repositories;

public interface ILikeRepository
{
	Task AddLike(Like like);
	Task RemoveLike(Like like);
	Task<int> GetLikesOnPost (Guid postId);
}
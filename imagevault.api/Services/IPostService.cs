using imagevault.api.Models;

namespace imagevault.api.Services;

public interface IPostService
{
	Task CreatePostAsync(Post post);
	Task<List<Post>> GetPostsAsync(int? limit, int? offset, string? search);
}
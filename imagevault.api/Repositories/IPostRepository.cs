using imagevault.api.DTOs;
using imagevault.api.Models;

namespace imagevault.api.Repositories;

public interface IPostRepository
{
	Task CreatePostAsync (Post post);
	Task <Post?> GetPostByIdAsync (Guid postId);
	IQueryable<Post> GetPostsQuery();
}
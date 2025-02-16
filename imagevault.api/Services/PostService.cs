using imagevault.api.Models;
using imagevault.api.Repositories;

namespace imagevault.api.Services;

public class PostService : IPostService
{
	private readonly IPostRepository _postRepository;

	public PostService(IPostRepository postRepository)
	{
		_postRepository = postRepository;
	}
}
using imagevault.api.Models;

namespace imagevault.api.Services;

public interface ICommentService
{
	Task AddCommentAsync(Comment comment);
	Task DeleteCommentAsync(Comment comment);
	Task UpdateCommentAsync(Comment comment);
	Task <List<Comment>> GetCommentsAsync(Guid postId, int? limit, int? offset);
	Task<Comment> GetCommentByPostAndUserIdAsync(Guid postId, Guid userId);
	public Task<Comment> GetCommentById(Guid commentId);
}
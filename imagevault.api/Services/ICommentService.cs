using imagevault.api.Models;

namespace imagevault.api.Services;

public interface ICommentService
{
	Task AddCommentAsync(Comment comment);
	Task DeleteCommentAsync(Comment comment);
	Task UpdateCommentAsync(Comment comment);
	Task <List<Comment>> GetCommentsAsync(int? limit, int? offset);
}
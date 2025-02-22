using imagevault.api.DTOs;
using imagevault.api.Models;
using imagevault.api.Services;

namespace imagevault.api.Extensions;

public static class CommentExtension
{
	public static Comment ToComment(this CommentPostDto commentPostDto)
	{
		return new Comment
		{
			Id = Guid.NewGuid(),
			Content = commentPostDto.Content,
			PostId = commentPostDto.PostId,
			UserId = commentPostDto.UserId,
			DateCreated = DateTime.Now,
		};
	}

	public static CommentRequestDto ToCommentRequestDto(this Comment comment)
	{
		return new CommentRequestDto
		{
			Id = comment.Id,
			Content = comment.Content,
			PostId = comment.PostId,
			UserId = comment.UserId,
			DateCreated = comment.DateCreated,
		};
	}
}
using imagevault.api.DTOs;
using imagevault.api.Extensions;
using imagevault.api.Models;
using imagevault.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace imagevault.api.Controllers;
[ApiController]
[Route("[controller]")]

public class CommentController : ControllerBase
{
	private readonly ICommentService _commentService;

	public CommentController(ICommentService commentService)
	{
		_commentService = commentService;
	}

	[HttpPost]
	public async Task<IActionResult> AddComment([FromBody] CommentPostDto commentPostDto)
	{ 
		if (!ModelState.IsValid)
			return BadRequest(ModelState);
		
		await _commentService.AddCommentAsync(commentPostDto.ToComment());
		return Ok("Comment Added");
	}

	[HttpGet]
	[Route("{postId}")]
	public async Task<IActionResult> GetComments([FromRoute] Guid postId, [FromQuery] int? limit, int? offset)
	{
		var comments = await _commentService.GetCommentsAsync(postId, limit, offset);
		var commentsDto = comments.Select(c => c.ToCommentRequestDto());
		return Ok(commentsDto);
	}

	[HttpGet]
	[Route("{postId}/{userId}")]
	public async Task<IActionResult> GetUsersCommentOnPost([FromRoute] Guid postId, [FromRoute] Guid userId)
	{
		var comment = await _commentService.GetCommentByPostAndUserIdAsync(postId, userId);
		return Ok(comment.ToCommentRequestDto());
	}
	
	[HttpDelete]
	[Route("{commentId}")]
	public async Task<IActionResult> DeleteComment([FromRoute] Guid commentId)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);
		
		var comment = await _commentService.GetCommentById(commentId);
		
		await _commentService.DeleteCommentAsync(comment);
		return Ok("Comment Deleted");
	}
}
const DEFAULT_URL = "https://localhost:44367/Comment"

export async function addComment(comment: Comment): Promise<void> {
  try {
    const response: Response = await fetch(DEFAULT_URL, {
      method: "POST",
      body: JSON.stringify(comment),
      headers: {"Content-Type": "application/json"},
    });
    
    if (!response.ok) {
      throw new Error("Failed to add comment");
    }
  } catch (e){
    console.error(e)
  }
}

export async function fetchComments(postId: string, limit?: number, offset?: number, signal?: AbortSignal) : Promise<Comment[]> {
  try {
    const url : string = `${DEFAULT_URL}/${postId}?limit=${limit}&offset=${offset}`;
    const response: Response = await fetch(url, {signal});

    if (!response.ok) {
      throw new Error("Failed to fetch comments");
    }
    
    return response.json();
  } catch (e){
    console.error(e)
    return [];
  }
}

export async function getUsersCommentOnPost (postId: string, userId: string, signal?: AbortSignal): Promise<Comment | null> {
  try {
    const url : string = `${DEFAULT_URL}/${postId}/${userId}`;
    const response: Response = await fetch(url, {signal});

    if (!response.ok) {
      throw new Error("Failed to fetch comment");
    }

    return response.json();
  } catch (e){
    console.error(e)
    return null;
  }
}

export async function deleteComment(commentId: string): Promise<void> {
  try {
    const response: Response = await fetch(DEFAULT_URL, {
      method: "DELETE",
      headers: {"Content-Type": "application/json"},
    });

    if (!response.ok) {
      throw new Error("Failed to delete comment");
    }
  } catch (e){
    console.error(e)
  }
}
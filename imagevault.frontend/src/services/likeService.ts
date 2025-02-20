const BASE_URL = 'https://localhost:44367/Likes'

export async function getLikesForPostCount(postId : number, signal? : AbortSignal) : Promise<number | null> {
  try{
    const url = `${BASE_URL}/${postId}/count`;
    const response : Response = await fetch(url, {signal});
    
    if (!response.ok) {
      throw new Error("Unable to fetch likes count for post");
    }
    
    return await response.json();
  } catch (e){
    console.error(e);
    return null;
  }
}

export async function addLike (postId : number, userId : string) : Promise<void> {
  try{
    const url = `${BASE_URL}`;
    
    const response : Response = await fetch(url, {
      method: "POST",
      body: JSON.stringify({postId, userId}),
      headers: {"Content-Type": "application/json"}
    });

    if (!response.ok) {
      throw new Error("Unable to add like");
    }

    return await response.json();
  } catch (e){
    console.error(e);
  }
}

export async function removeLike (postId : number, userId : string) : Promise<void> {
  try{
    const url = `${BASE_URL}/${postId}/${userId}`;

    const response : Response = await fetch(url, {
      method: "DELETE",
      headers: {"Content-Type": "application/json"}
    })

    if (!response.ok) {
      throw new Error("Unable to remove like");
    }

    return await response.json();
  } catch (e){
    console.error(e);
  }
}
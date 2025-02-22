﻿const BASE_URL = 'https://localhost:44367/Likes'

export async function getLikesForPostCount(postId: string, signal?: AbortSignal): Promise<number | null> {
  try {
    const url = `${BASE_URL}/${postId}/count`;
    const response: Response = await fetch(url, {signal});

    if (!response.ok) {
      throw new Error("Unable to fetch likes count for post");
    }

    return await response.json();
  } catch (e) {
    console.error(e);
    return null;
  }
}

export async function addLike(postId: string, userId: string): Promise<void> {
  try {
    const url = `${BASE_URL}`;

    const response: Response = await fetch(url, {
      method: "POST",
      body: JSON.stringify({postId, userId}),
      headers: {"Content-Type": "application/json"}
    });

    if (!response.ok) {
      throw new Error("Unable to add like");
    }

    return await response.json();
  } catch (e) {
    console.error(e);
  }
}

export async function removeLike(postId: string, userId: string): Promise<void> {
  try {
    const url = `${BASE_URL}/${postId}/${userId}`;

    const response: Response = await fetch(url, {
      method: "DELETE",
      headers: {"Content-Type": "application/json"}
    })

    if (!response.ok) {
      throw new Error("Unable to remove like");
    }

    return await response.json();
  } catch (e) {
    console.error(e);
  }
}

export async function hasUserLikedPost(postId: string, userId?: string, signal?: AbortSignal): Promise<boolean> {
  try {
    const url = `${BASE_URL}/${postId}/${userId}`;
    const response: Response = await fetch(url, {signal})

    if (!response.ok) {
      throw new Error("Unable to fetch like");
    }
    const data : string = await response.json();
    return Boolean(data);
  } catch (e) {
    console.error(e);
    return false;
  }
}
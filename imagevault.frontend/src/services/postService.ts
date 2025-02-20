import Post from "@/interfaces/post";
import FetchPostsParams from "@/interfaces/fetchPostsParams";
import PostWithImages from "@/interfaces/postWithImages";

const DEFAULT_URL = "https://localhost:44367/Post"
const FILE_PATH: string = "C:/Users/houst/RiderProjects/Image Vault/imagevault.api/Images";

export async function createPost(title : string, description : string, userId : string) : Promise<Post |null> {
  try{
    
    const url : string = DEFAULT_URL + "/create"
    
    const response : Response = await fetch(url, {
      method: "POST",
      headers : {"Content-Type": "application/json"},
      body : JSON.stringify({title, description, userId})
    });
    
    if (!response.ok) {
      throw new Error("Failed to create Post");
    }
    
    return await response.json();
  } catch (error) {
    console.error(error);
  }
  return null;
}

export async function uploadImages(postId : string, imageFiles : FileList){
  
  const url : string = `${DEFAULT_URL}/${postId}/images/upload`

  const uploads = Array.from(imageFiles).map(async file => {
    try {
      const formData = new FormData();
      formData.append("ImageFile", file);

      const response : Response = await fetch(url, {
        method: "POST",
        body : formData
      });

      if (!response.ok)
        throw new Error(`Failed to upload ${file.name}`);
    } catch (error) {
      console.error(error);
    }
  });
  await Promise.allSettled(uploads);
}

export async function fetchPosts ({limit = 0, offset = 0, search = ""} : FetchPostsParams, signal? : AbortSignal) : Promise<PostWithImages[]> {
  
  const url : string = `${DEFAULT_URL}/search?limit=${limit}&offset=${offset}&search=${search}`;
  
  try {
    const response : Response = await fetch(url, {signal});
    
    if (!response.ok)
      throw new Error("Failed to fetch posts");
    
    return await response.json();
  } catch (e){
    console.error(e);
    return [];
  }
}

export async function fetchPostById (postId : string, signal? : AbortSignal) : Promise<PostWithImages | null> {
  try {
    const url: string = `${DEFAULT_URL}/${postId}`;
    const response: Response = await fetch(url, {signal});
    
    if (!response.ok) {
      throw new Error("Failed to fetch post");
    }
    return await response.json();
  } catch (e){
    console.error(e);
    return null;
  }
}
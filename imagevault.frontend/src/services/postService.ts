import Post from "@/interfaces/post";

const DEFAULT_URL = "https://localhost:44367/Post"

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
  debugger;
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
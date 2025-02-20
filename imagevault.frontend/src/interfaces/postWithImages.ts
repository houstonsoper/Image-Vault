import PostImage from "@/interfaces/postImage";

export default interface PostWithImages {
  id: string,
  title: string,
  description: string,
  date: string,
  isActive : boolean,
  userId : string,
  images : PostImage[],
}
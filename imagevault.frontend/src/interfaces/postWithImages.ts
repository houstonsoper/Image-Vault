import Image from "@/interfaces/image";

export default interface PostWithImages {
  id: string,
  title: string,
  description: string,
  date: Date,
  isActive : boolean,
  userId : string,
  images : Image[],
}
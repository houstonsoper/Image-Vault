export default interface Comment {
  id: string,
  content: string,
  postId: string,
  userId: string,
  dateCreated: Date,
}
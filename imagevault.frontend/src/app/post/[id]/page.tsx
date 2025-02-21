"use client"

import React, {useEffect, useState} from "react";
import {fetchPostById} from "@/services/postService";
import {useParams, useSearchParams} from "next/navigation";
import {Params} from "next/dist/server/request/params";
import PostWithImages from "@/interfaces/postWithImages";
import Image from "next/image";
import User from "@/interfaces/user";
import {getUserById} from "@/services/userService";
import {getLikesForPostCount, hasUserLikedPost} from "@/services/likeService";
import {useUser} from "@/contexts/userContext";

export default function PostPage() {
  const searchParams: Params = useParams();
  const postId: string | undefined = searchParams.id?.toString();
  const [post, setPost] = useState<PostWithImages | null>(null);
  const [selectedImageIndex, setSelectedImageIndex] = useState<number>(0);
  const [user, setUser] = useState<User | null>(null);
  const [likesCount, setLikesCount] = useState<number>(0);
  const [hasUserLiked, setHasUserLiked] = useState<boolean>(false);
  const {auth} = useUser();
  const [loading, setLoading] = useState(true);
  
  //Get post on mount
  useEffect(() => {
    setLoading(true);
    const controller = new AbortController();
    const signal: AbortSignal = controller.signal;
    const getPostDetails = async (): Promise<void> => {
      if (postId) {
        const fetchedPost: PostWithImages | null = await fetchPostById(postId, signal);
        setPost(fetchedPost);
        
        if (fetchedPost) {
          const fetchedUser: User | null = await getUserById(fetchedPost.userId, signal);
          const fetchedLikesCount : number | null = await getLikesForPostCount(fetchedPost.id, signal);
          const fetchedHasUserLikedPost : boolean = await hasUserLikedPost(fetchedPost.id, auth.user?.userId, signal);
          setLikesCount(fetchedLikesCount ?? 0);
          setUser(fetchedUser);
          setHasUserLiked(fetchedHasUserLikedPost);
        }
      }
    }
    getPostDetails();
    setLoading(false);
    return () => controller.abort();
  }, [auth.user]);

  const handleImageChange = (direction : string) => {
    if (direction === "next" && post) {
      setSelectedImageIndex(prevIndex => (prevIndex + 1) % post.images.length);
    }
    if (direction === "prev" && post) {
      setSelectedImageIndex(prevIndex => (prevIndex - 1 + post.images.length) % post.images.length);
    }
  }
  
  return (
    <section className="container m-auto">
      {!loading && post ? (
        <div className="flex text-white py-12">
          <div className="m-auto w-full max-w-[30rem]">
            <div>
              <p>{user?.username ?? "unknown"}</p>
              <p>{new Date(post.date).toLocaleDateString("en-GB", {
                day: "2-digit",
                month: "2-digit",
                year: "2-digit",
                hour: "2-digit",
                minute: "2-digit",
              }).replace(",", "")}</p>
            </div>
            <div className="group relative aspect-square">
            <Image
              src={`https://localhost:44367/images/${post.images[selectedImageIndex].id + post.images[selectedImageIndex].extension}`}
              alt={`Image #${selectedImageIndex + 1}`}
              layout="fill"
              unoptimized={true}
              objectFit="cover"
            />
            {post.images.length > 1 && (
              <div
                className="flex relative justify-between items-center h-full px-1 opacity-0 group-hover:opacity-100 transition duration-200">
                <button
                  className="material-symbols-outlined bg-gray-800 p-1 hover:bg-gray-700 rounded hover:scale-105"
                  onClick={(e: React.MouseEvent<HTMLButtonElement>) => {
                    e.preventDefault();
                    handleImageChange("prev");
                  }}
                >
                  <span>chevron_left</span>
                </button>
                <button
                  className="material-symbols-outlined bg-gray-800 p-1 hover:bg-gray-700 rounded hover:scale-105"
                  onClick={(e: React.MouseEvent<HTMLButtonElement>) => {
                    e.preventDefault();
                    handleImageChange("next");
                  }}
                >
                  <span className="relative left-[0.14rem]">chevron_right</span>
                </button>
              </div>
            )}
            </div>
            <div className="flex space-x-3">
              <button className="text-gray-400 hover:text-red-500 transition-colors duration-200">
                <span className={`material-symbols-outlined text-2xl symbol-hover ${hasUserLiked && ("symbol-fill text-red-600")}`}>favorite</span>
                <span>{likesCount}</span>
              </button>
            </div>
            <div>
              <h1 className="text-2xl">{post.title}</h1>
              <p>{post.description}</p>
            </div>
            <div className="pt-4">
              <h2 className="font-semibold text- text-sm">42 COMMENTS</h2>
              <hr className="opacity-70 my-2"/>
            </div>
          </div>
        </div>
      ) : null}
    </section>
  )
}
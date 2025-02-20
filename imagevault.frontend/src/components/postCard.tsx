"use client"

import type PostWithImages from "@/interfaces/postWithImages"
import Image from "next/image"
import React, {useEffect, useState} from "react"
import Link from "next/link";
import {getLikesForPostCount} from "@/services/likeService";

interface PostCardProps {
  post: PostWithImages
}

export default function PostCard({ post }: PostCardProps) {
  const [selectedImageIndex, setSelectedImageIndex] = useState<number>(0);
  const [likesCount, setLikesCount] = useState<number>(0);
  
  useEffect(() => {
    const controller = new AbortController;
    const signal : AbortSignal = controller.signal;
    
    const getPostDetails = async () => {
      const fetchedLikesCount : number | null = await getLikesForPostCount(post.id, signal);
      setLikesCount(fetchedLikesCount ?? 0);
    }
    getPostDetails();
    return () => controller.abort();
  })
  const handleImageChange = (direction : string) => {
    if (direction === "next") {
      setSelectedImageIndex(prevIndex => (prevIndex + 1) % post.images.length)
    } else if (direction === "prev") {
      setSelectedImageIndex(prevIndex => (prevIndex - 1 + post.images.length) % post.images.length)
    }
  }
  
  return (
    <Link href={`post/${post.id}`} className="mb-10">
      <div className="bg-neutral-800 hover:bg-neutral-700 hover:scale-105 transition-all duration-200 hover:cursor-pointer text-white rounded-lg overflow-hidden shadow-lg group">
        <div className="relative aspect-square">
          <Image
            src={`https://localhost:44367/images/${post.images[selectedImageIndex].id + post.images[selectedImageIndex].extension}`}
            alt={post.title}
            layout="fill"
            unoptimized={true}
            objectFit="cover"
          />
          {post.images.length > 1 && (
          <div className="flex relative justify-between items-center h-full px-1 opacity-0 group-hover:opacity-100 transition duration-200">
            <button 
              className="material-symbols-outlined bg-gray-800 p-1 hover:bg-gray-700 rounded hover:scale-105"
              onClick={(e : React.MouseEvent<HTMLButtonElement>) => {
                e.preventDefault();
                handleImageChange("prev");
              }
            }
            >
              <span>chevron_left</span>
            </button>
            <button 
              className="material-symbols-outlined bg-gray-800 p-1 hover:bg-gray-700 rounded hover:scale-105" 
              onClick={(e : React.MouseEvent<HTMLButtonElement>) => {
                e.preventDefault();
                handleImageChange("next");
              }
            }
            >
              <span className="relative left-[0.14rem]">chevron_right</span>
            </button>
          </div>
          )}
        </div>
        <div className="p-4">
          <h2 className="text-lg font-semibold mb-2">{post.title}</h2>
          <div className="flex justify-between items-center">
            <div className="flex space-x-3">
              <button className="text-gray-400 hover:text-red-500 transition-colors duration-200">
                <span className="material-symbols-outlined symbol-hover text-2xl">favorite</span>
                <span>{likesCount}</span>
              </button>
              <button className="text-gray-400 hover:text-blue-500 transition-colors duration-200">
                <span className="material-symbols-outlined symbol-hover text-2xl ">chat_bubble</span>
              </button>
            </div>
            <span className="text-sm text-gray-400">{post.images.length} photo{post.images.length > 1 && "s"}</span>
          </div>
        </div>
      </div>
    </Link>
  )
}


"use client"

import type PostWithImages from "@/interfaces/postWithImages"
import Image from "next/image"
import { useState } from "react"
import type PostImage from "@/interfaces/postImage"

interface PostCardProps {
  post: PostWithImages
}

export default function PostCard({ post }: PostCardProps) {
  const [selectedImageIndex, setSelectedImageIndex] = useState<number>(0)

  const handleImageChange = (direction : string) => {
    if (direction === "next") {
      setSelectedImageIndex(prevIndex => (prevIndex + 1) % post.images.length)
    } else if (direction === "prev") {
      setSelectedImageIndex(prevIndex => (prevIndex - 1 + post.images.length) % post.images.length)
    }
  }
    
  
  return (
    <div className="mb-10">
      <div className="bg-neutral-800 text-white rounded-lg overflow-hidden shadow-lg">
        <div className="relative aspect-square">
          <Image
            src={`https://localhost:44367/images/${post.images[selectedImageIndex].id + post.images[selectedImageIndex].extension}`}
            alt={post.title}
            layout="fill"
            unoptimized={true}
            objectFit="cover"
          />
          {post.images.length > 1 && (
          <div className="flex text-white  relative justify-between items-center h-full">
            <button className="material-symbols-outlined bg-black" onClick={() => handleImageChange("prev")}>arrow_back_ios_new</button>
            <button className="material-symbols-outlined bg-black" onClick={() => handleImageChange("next")}>arrow_forward_ios</button>
          </div>
          )}
        </div>
        <div className="p-4">
          <h2 className="text-lg font-semibold mb-2">{post.title}</h2>
          <div className="flex justify-between items-center">
            <div className="flex space-x-2">
              <button className="text-gray-400 hover:text-red-500 transition-colors duration-200">
                <span className="material-symbols-outlined text-2xl">favorite</span>
              </button>
              <button className="text-gray-400 hover:text-blue-500 transition-colors duration-200">
                <span className="material-symbols-outlined text-2xl">chat_bubble</span>
              </button>
            </div>
            <span className="text-sm text-gray-400">{post.images.length} photo{post.images.length > 1 && "s"}</span>
          </div>
        </div>
      </div>
    </div>
  )
}


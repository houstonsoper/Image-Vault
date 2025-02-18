"use client"

import React, { useEffect } from "react"
import type PostWithImages from "@/interfaces/postWithImages"
import { fetchPosts } from "@/services/postService"
import PostCard from "@/components/postCard"

export default function Home() {
  const [posts, setPosts] = React.useState<PostWithImages[]>([])
  const limit = 12
  const page = 1

  useEffect(() => {
    const controller = new AbortController()
    const signal: AbortSignal = controller.signal

    const getPosts = async () => {
      const fetchedPosts: PostWithImages[] = await fetchPosts({ limit, offset: page - 1 }, signal)
      setPosts(fetchedPosts)
      console.log(fetchedPosts)
    }
    getPosts()
    return () => controller.abort()
  }, [])

  return (
    <section className="py-12">
      <div className="container mx-auto px-12">
        <h1 className="text-4xl font-bold text-white mb-8 text-center">Images</h1>
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 xl:grid-cols-6 gap-12">
          {posts.map((post) => (
            <PostCard post={post} key={post.id}/>
          ))}
        </div>
      </div>
    </section>
  )
}


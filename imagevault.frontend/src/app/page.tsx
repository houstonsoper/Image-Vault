"use client"

import React, {useEffect, useState} from "react"
import type PostWithImages from "@/interfaces/postWithImages"
import { fetchPosts } from "@/services/postService"
import PostCard from "@/components/postCard"
import {useInView} from "react-intersection-observer";

export default function Home() {
  const [posts, setPosts] = useState<PostWithImages[]>([]);
  const [nextPosts, setNextPosts] = useState<PostWithImages[]>([]);
  const [scrollTrigger, isInView] = useInView();
  const limit = 18;
  const [page, setPage] = useState<number>(1);

  //Get posts on mount
  useEffect(() => {
    const controller = new AbortController();
    const signal: AbortSignal = controller.signal;

    const getPosts = async (): Promise<void> => {
      const fetchedPosts: PostWithImages[] = await fetchPosts({ limit, offset: page - 1 }, signal);
      setPosts(fetchedPosts);
    }
    getPosts();
   
    return () => controller.abort();
  }, [])
  
  //Retrieve posts for the next page
  useEffect(() => {
    const controller = new AbortController();
    const signal: AbortSignal = controller.signal;
    
    const getNextPosts = async () : Promise<void> => {
      const fetchedPosts: PostWithImages[] = await fetchPosts({ limit, offset: page * limit}, signal);
      setNextPosts(fetchedPosts);
    }
    getNextPosts();
    
    return () => controller.abort()
  }, [page]);

  //Display the posts for the next page when the scrollTrigger is in view
  useEffect(() => {
    if (isInView && nextPosts.length > 0){
      setPosts(prevPosts => [...prevPosts, ...nextPosts]);
      setPage(prevPage => prevPage + 1);
    }
  }, [isInView]);
  
  return (
    <section className="py-12">
      <div className="container mx-auto px-12">
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 xl:grid-cols-6 gap-12">
          {posts.map((post) => (
            <PostCard post={post} key={post.id}/>
          ))}
        </div>
        <div>
          {nextPosts.length > 0 && (
            <p className="text-center text-white font-semibold" ref={scrollTrigger}>Loading...</p>
          )}
        </div>
      </div>
    </section>
  )
}


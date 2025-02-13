"use client"

import React from "react";
import Link from "next/link";

export default function Home() {
  return (
      <section>
          <div className="container m-auto">
              <div className="flex h-screen">
                  <div className="m-auto">
                      <Link href="/upload">Upload Image</Link>
                  </div>
              </div>
          </div>
      </section>
  );
}

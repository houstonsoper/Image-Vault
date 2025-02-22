﻿"use client"

import Link from "next/link";
import {useUser} from "@/contexts/userContext";

export default function Navbar() {
  const {auth} = useUser();

  return (
    <nav className="bg-gray-900">
      <div className="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
        <div className="relative flex h-16 items-center justify-between">
          <div className="absolute inset-y-0 left-0 flex items-center sm:hidden">
          </div>
          <div className="flex flex-1 items-center justify-center sm:items-stretch sm:justify-start">
            <div className="flex shrink-0 items-center">
              <img className="h-8 w-auto"
                   src="https://tailwindui.com/plus-assets/img/logos/mark.svg?color=indigo&shade=500"
                   alt="Your Company"/>
            </div>
            <div className="hidden sm:ml-6 sm:block">
              <div className="flex space-x-4">
                <Link href="upload">
                  <div className="flex space-x-2 bg-pink-600 hover:bg-pink-700 rounded text-white py-1 px-3 transition duration-200">
                    <p className="font-semibold">Upload</p>
                    <span className="material-symbols-outlined symbol-fill">drive_folder_upload</span>
                  </div>
                </Link>
              </div>
            </div>
          </div>
          <div>
            {auth.user ? (
              <span className="material-symbols-outlined text-white">account_circle</span>
            ) : (<Link className="text-white" href="/login">Login</Link>)}
          </div>
        </div>
      </div>
    </nav>
  );
}
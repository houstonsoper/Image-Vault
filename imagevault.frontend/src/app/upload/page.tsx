"use client"

import React, {useState} from "react";
import Image from "next/image";

export default function UploadPage() {
  const [imageUrls, setImageUrls] = useState<string[]>([]);

  const handleFormSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const formData = new FormData(e.currentTarget);

    console.log(formData.get("title"));
  }

  const generateImageUrls = (files: FileList) => {
    let urls: string[] = [];
    for (const file of files) {
      const url: string = URL.createObjectURL(file);
      urls.push(url);
    }
    return urls;
  }
  const handleImagesOnButton = (e: React.ChangeEvent<HTMLInputElement>) => {
    const files: FileList | null = e.target.files;

    if (files) {
      const generatedImageUrls: string[] = generateImageUrls(files);
      setImageUrls(prevUrls => [...prevUrls, ...generatedImageUrls]);
    }
  }

  const handleImagesOnDrop = (e: React.DragEvent) => {
    e.preventDefault();
    const files: FileList = (e.dataTransfer.files);

    if (files) {
      const generatedImageUrls: string[] = generateImageUrls(files);
      setImageUrls(prevUrls => [...prevUrls, ...generatedImageUrls]);
    }
  }

  return (
    <div className="container mx-auto px-4 py-8">
      <div className="flex min-h-screen items-center justify-center">
        <div className="w-full max-w-md rounded-lg bg-white p-8 shadow-2xl">
          <h2 className="mb-6 text-2xl font-bold text-gray-800">Upload Image</h2>
          <form onSubmit={handleFormSubmit} className="space-y-6">
            <div>
              <label htmlFor="title" className="block text-sm font-medium text-gray-700">
                Title
              </label>
              <input
                name="title"
                type="text"
                className="mt-1 block w-full rounded-md border border-gray-300 px-3 py-2 shadow-sm focus:border-indigo-500 focus:outline-none focus:ring-indigo-500 sm:text-sm"
                placeholder="Enter image title"
              />
            </div>
            <div>
              <label htmlFor="description" className="block text-sm font-medium text-gray-700">
                Description
              </label>
              <textarea
                name="description"
                rows={3}
                className="mt-1 block w-full rounded-md border border-gray-300 px-3 py-2 shadow-sm focus:border-indigo-500 focus:outline-none focus:ring-indigo-500 sm:text-sm"
                placeholder="Enter image description"
              />
            </div>
            <div>
              <label className="block text-sm font-medium text-gray-700">Image</label>
              <div
                className="mt-1 justify-center rounded-md border-2 border-dashed border-gray-300 px-6 pt-5 pb-6"
                onDrop={handleImagesOnDrop}
                onDragOver={(e: React.DragEvent) => e.preventDefault()}>
                {imageUrls.length > 0 ? (
                  <div className="grid grid-cols-3 w-full">
                    {imageUrls.map((url, i) => (
                      <div key={i} className="border rounded m-2 shadow-md">
                        <Image
                          src={url}
                          alt={`Image #${i}`}
                          width={100}
                          height={100}
                          className="mx-auto p-2"
                        />
                      </div>
                    ))}
                  </div>
                ) : (
                  <>
                    <div className="flex">
                      <span className="mx-auto text-gray-400 material-symbols-outlined text-[2.5rem]">imagesmode</span>
                    </div>
                    <div className="flex text-sm text-gray-600 w-full justify-center">
                      <label
                        htmlFor="file-upload"
                        className="relative cursor-pointer rounded-md bg-white font-medium text-indigo-600 focus-within:outline-none focus-within:ring-2 focus-within:ring-indigo-500 focus-within:ring-offset-2 hover:text-indigo-500"
                      >
                        <span>Upload a file</span>
                        <input
                          id="file-upload"
                          name="image"
                          type="file"
                          className="sr-only"
                          onChange={handleImagesOnButton}
                          accept="image/png,image/jpeg"
                          multiple={true}
                        />
                      </label>
                      <p className="pl-1">or drag and drop</p>
                    </div>
                    <div className="flex justify-center w-full">
                      <p className="text-xs text-gray-500 ">PNG, JPG up to 10MB</p>
                    </div>
                  </>
                )}
              </div>
            </div>
            <div>
              <button
                type="submit"
                className="flex w-full justify-center rounded-md border border-transparent bg-indigo-600 px-4 py-2 text-sm font-medium text-white shadow-sm hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:ring-offset-2"
              >
                Upload
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  )
}


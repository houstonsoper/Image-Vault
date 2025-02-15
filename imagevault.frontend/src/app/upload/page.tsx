"use client"

import Link from "next/link";
import React, {RefObject, useRef, useState} from "react";
import Image from "next/image";

export default function UploadPage () {
    const [imagePreview, setImagePreview] = useState<string>("");
    
    const handleFormSubmit = (e :React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const formData = new FormData(e.currentTarget);
        
        console.log(formData.get("title"));
    }
    
    const handleImage = (e:React.ChangeEvent<HTMLInputElement>) => {
        const file : FileList | null = e.target.files;
        console.log(e.target.files);
        if (!file) return;
        
       setImagePreview(window.URL.createObjectURL(file[0]));
    }
    
    return (
        <div className="container m-auto">
            <div className="flex h-screen">
                <div className="m-auto">
                    <form onSubmit={handleFormSubmit}>
                        <div>
                            <label htmlFor="title">Title</label>
                            <input name="title" type="text" className="w-full border"/>
                        </div>
                        <div>
                            <label htmlFor="description">Description</label>
                            <input name="description" type="text" className="w-full border"/>
                        </div>
                        {/*Image Upload Box*/}
                        <div className="mt-3 h-[200px]">
                            <div className="flex flex-col border m-auto h-full">
                                <input 
                                    onChange={handleImage} 
                                    name="image" 
                                    type="file"
                                    accept="image/png,image/jpeg"
                                    className="h-full"
                                />
                                {imagePreview &&
                                    <Image
                                        src={imagePreview}
                                        alt={"unknown"}
                                        width={150}
                                        height={150}
                                        className="m-auto h-[150px] w-[150px]"
                                    />
                                }
                            </div>
                        </div>
                        <div className="flex p-3">
                            <button type="submit" className="m-auto bg-gray-700 hover:bg-gray-800 text-white rounded px-3">
                                Submit
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}
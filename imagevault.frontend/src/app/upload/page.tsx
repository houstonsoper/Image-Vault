"use client"

import Link from "next/link";
import React, {RefObject, useRef} from "react";

export default function UploadPage () {
    const handleFormSubmit = (e :React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const formData = new FormData(e.currentTarget);
        
        console.log(formData.get("title"));
        
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
                        <div>
                            <label htmlFor="image">Images</label>
                        </div>
                        <div className="flex p-3">
                            <button type="submit"
                                    className="m-auto bg-gray-700 hover:bg-gray-800 text-white rounded px-3">Submit
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}
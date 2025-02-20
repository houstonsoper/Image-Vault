﻿import User from "@/interfaces/user";
import UserFormDetails from "@/interfaces/userFormDetails";
import {use} from "react";

const BASEURL: string = "https://localhost:44367/User"

export function extractFormDate(form: FormData): UserFormDetails{
    const username: string | undefined = form.get('username')?.toString();
    const email: string | undefined = form.get('email')?.toString();
    const password: string | undefined = form.get('password')?.toString();
    const confirmPassword: string | undefined = form.get('confirmPassword')?.toString();

    return {username, email, password, confirmPassword} as UserFormDetails;
}

export function validateRegistrationForm(formData: FormData): Error[] | null {
    const details: UserFormDetails = extractFormDate(formData);
    let errors: Error[] = [];

    //Check if username is supplied and is between 5 and 20 characters
    if (!details.username) {
        errors.push({name: "InvalidEmail", message: "Please enter your email"});
    } else if (details.username.length < 5 || details.username.length > 20) {
        errors.push({name: "InvalidUsernameLength", message: "Username must be between 5 and 20 characters"});
    }
    
    //Check if email is supplied and is between 5 and 254 characters
    if (!details.email) {
        errors.push({name: "InvalidEmail", message: "Please enter your email"});
    } else if (details.email.length < 5 || details.email.length > 254) {
        errors.push({name: "InvalidEmailLength", message: "Email must be between 5 and 254 characters"});
    }
    
    //Check that passwords match 
    //and that the password is between 5 and 15 characters
    if (!details.password && !details.confirmPassword) {
        errors.push({name: "InvalidPassword", message: "Please enter a password"});
    } else if (details.password !== details.confirmPassword) {
        errors.push({name: "PasswordMismatch", message: "Passwords do not match"});
    } else if (details.password.length < 5 || details.password.length > 15) {
        errors.push({name: "InvalidPasswordLength", message: "Password must be between 5 and 15 characters"});
    }

    //Return any errors 
    if (errors.length > 0) {
        return errors;
    }

    return null
}

export function validateLoginForm(formData: FormData): Error[] | null {
    const details: UserFormDetails = extractFormDate(formData);
    let errors: Error[] = [];

    //Check if an email has been entered
    if (!details.email) {
        errors.push({name: "InvalidEmail", message: "Please enter your email"});
    }
    
    //Check if a password has been entered
    if (!details.password) {
        errors.push({name: "InvalidPassword", message: "Please enter your password"});
    }

    //Return any errors 
    if (errors.length > 0) {
        return errors;
    }

    return null
}

export function validateForgotPasswordForm (formData: FormData): Error[] | null {
    const details: UserFormDetails = extractFormDate(formData);
    let errors: Error[] = [];

    //Check if an email has been entered
    if (!details.email) {
        errors.push({name: "InvalidEmail", message: "Please enter your email"});
    }

    //Return any errors 
    if (errors.length > 0) {
        return errors;
    }

    return null;
}

export function validatePasswordResetForm (formData: FormData): Error[] | null {
    const details: UserFormDetails = extractFormDate(formData);
    let errors: Error[] = [];

    //Check that passwords match 
    //and that the password is between 5 and 15 characters
    if (!details.password && !details.confirmPassword) {
        errors.push({name: "InvalidPassword", message: "Please enter a password"});
    } else if (details.password !== details.confirmPassword) {
        errors.push({name: "PasswordMismatch", message: "Passwords do not match"});
    } else if (details.password.length < 5 || details.password.length > 15) {
        errors.push({name: "InvalidPasswordLength", message: "Password must be between 5 and 15 characters"});
    }
    
    //Return any errors
    if (errors.length > 0) {
        return errors;
    }
    return null;
}

export async function createUser(formData: FormData) {
    const registrationDetails: UserFormDetails = extractFormDate(formData);

    const url: string = BASEURL + "/Register"

    const response: Response = await fetch(url, {
        method: "POST",
        body: JSON.stringify(registrationDetails),
        headers: {"Content-Type": "application/json"},
        credentials: "include",
    });

    if (!response.ok) {
        const errorData = await response.json();
        console.error(errorData.message);
        throw new Error(errorData.message);
    }
}

export async function userLogin(formData: FormData) {
    const loginDetails: UserFormDetails = extractFormDate(formData);

    const url: string = BASEURL + "/Login"

    const response: Response = await fetch(url, {
        method: "POST",
        body: JSON.stringify(loginDetails),
        headers: {"Content-Type": "application/json"},
        credentials: "include",
    });

    if (!response.ok) {
        const errorData = await response.json();
        console.error(errorData.message);
        throw new Error(errorData.message);
    }
}

export async function getUser() : Promise<User | null> {
    const response: Response = await fetch(BASEURL, {
        method: "GET",
        credentials: "include",
    });

    if (response.ok) {
        const responseData = await response.json();

        if(responseData.message === "User is not logged in"){
            return null;
        }
        return responseData;
    }
    return null;
}

export async function userLogout()  {
    const url: string = BASEURL + "/Logout";
    const response: Response = await fetch(url, {
        method: "POST",
        credentials: "include",
    });

    if (!response.ok) {
        throw new Error("Unable to logout");
    }
} 

export async function sendPasswordResetToken(formData: FormData) {
    const details : UserFormDetails = extractFormDate(formData);
    
    const url: string = "https://localhost:44367/PasswordResetToken";
 
    await fetch(url, {
        method: "POST",
        body: JSON.stringify({email : details.email}),
        headers: {"Content-Type": "application/json"},
    });
}

export async function fetchPasswordToken(tokenId : string ) {
    const url: string = "https://localhost:44367/PasswordResetToken/" + tokenId;
    const response : Response = await fetch(url);
    
    if (!response.ok) {
        const errorData = await response.json();
        console.error(errorData.message);
        return null;
    }
    
    return await response.json();
}

export async function userResetPassword(tokenId : string, formData : FormData ) {
    const details: UserFormDetails = extractFormDate(formData);
    
    const url: string = BASEURL + "/ResetPassword";
    const response : Response = await fetch(url, {
        method: "POST",
        headers: {"Content-Type": "application/json"},
        body: JSON.stringify({tokenId : tokenId, password: details.password}),
    });

    if (!response.ok) {
        const errorData = await response.json();
        console.error(errorData.message);
        throw new Error(errorData.message);
    }
    
    return await response.json();
}

export async function getUserById (userId : string, signal? : AbortSignal){
    try{
        const url: string = `${BASEURL}/${userId}`;
        const response : Response = await fetch(url, {signal})
        
        if (!response.ok) 
            throw new Error(`Unable to get user with id ${userId}`);
        
        return await response.json();
    } catch (e){
        console.error(e);
    }
}
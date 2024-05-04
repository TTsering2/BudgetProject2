import exp from "constants";
import React, { ChangeEvent, HTMLInputTypeAttribute, useState } from "react";

// Function to login a user
export default async function LoginUser(username: string, password: string) {
    try{
        console.log("Attempting to login")

        const response = await fetch(`http://localhost:5112/api/user/login?username=${encodeURIComponent(username)}&password=${encodeURIComponent(password)}`, {
            method: 'POST',
        });
        if(response.ok){
            const data = await response.json();
            console.log("Login successful. UserID: " + data.userId)
        }else{
            console.log("Login failed. Status:", response.status, "Status text:", response.statusText)
            const text = await response.text();
            console.log("Response text:", text);
        }
    } catch (error){
        console.error(error)
    }
}

export async function AddUser(name: string, username: string, password: string) {
    try{
        console.log("Attempting to add user")

        const response = await fetch('http://localhost:5112/api/User', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: name,
                username: username,
                password: password
            })
        });
        if(response.ok){
            const data = await response.json();
            console.log("User added successfully. UserID: " + data.userId + " Username: " + data.username + " Name: " + data.name)
        }else{
            console.log("Failed to add user. Status:", response.status, "Status text:", response.statusText)
            const text = await response.text();
            console.log("Response text:", text);
        }
    } catch (error){
        console.error(error)
    }
}




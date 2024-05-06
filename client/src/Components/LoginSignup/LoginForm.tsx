
import React, { ChangeEvent, HTMLInputTypeAttribute, useState } from "react";
import facebook_icon from '../Assets/fb.png';
import x_icon from '../Assets/X.png';
import google_icon from '../Assets/google.png';
import './LoginPage.css';

interface IProps {
}


// import Validation from "./LoginValidator";
// import { setConstantValue } from "typescript";


// Interface representing the state of the form
interface FormState {
    userName: string;
    name: string;
    userPassword: string;
}


export const LoginForm:React.FC<IProps> = (props: IProps) => {

    // form title state
    const [action, setAction] = useState("Welcome back");

    // form state
    const [userName, setUserName] = useState("");
    const [userPassword, setUserPassword] = useState("");

    // Sign In error states
    const[errors, setErrors] = useState<FormState>({userName: '',name: '', userPassword: ''});

    // form submission handler 
//     const handleSubmit = (e: React.FormEvent<HTMLFormElement>) =>{
//         e.preventDefault();
//         // Calling the Validation function to check for errors
//         const validationErrors = Validation({email :userEmail, password:userPassword});


// // Creating a new object to hold errors based on FormState interface
//         const newErrors: FormState = {
//             userName: validationErrors.email || '',
//             userEmail: validationErrors.email || ' ',
//             userPassword: validationErrors.password || ' '

//         };
//         // Setting the errors state with the new errors object
//         setErrors(newErrors);


//         // If there are no validation errors, log success message
//         if(Object.keys(validationErrors).length === 0){
//             console.log("SUCCESSFUL!")
//         }
        

       

//         };


    



    // function to handle login submit
        function handleLoginSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        const username = event.currentTarget.userName.value;
        const password = event.currentTarget.userPassword.value;
        LoginUser(username, password);
    }


    // Function to login a user
    async function LoginUser(username: string, password: string) {
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




         // user input, operate simply input. Without this "onChange" event, we cannot type.
    const UserOnChangeFunction = (synthEvent: ChangeEvent<HTMLInputElement>) => {
        if(synthEvent.target.name === "userName" ){
            setUserName(synthEvent.target.value);
        }else if(synthEvent.target.name === "userPassword"){
            setUserPassword(synthEvent.target.value);
        }
    }

   
    return (
        <div className = "Container">
            <div className = "header">
                <div className = "text"> {action}</div>
            </div>

          
            
            <form onSubmit={handleLoginSubmit}>
                
                    
                <div className = "input">
                    <input placeholder="Username" type="text" value={userName} onChange={UserOnChangeFunction} name="userName"/>
                    {errors.name && <span className="text-error"> {errors.name}</span>}
                </div>
                

                <div className = "input">
                    <input placeholder="Password" type="password" value={userPassword} onChange={UserOnChangeFunction} name="userPassword"/>
                    {errors.userPassword && <span className="text-error"> {errors.userPassword}</span>}
                </div>

                
        

                <div className="submit-container">
                {/*  <div className="submit">Sign Up</div>*/}
                <button type = "submit" className={action} onClick={() =>{setAction("Welcome Back!")}}> Login</button>

                    <div className="forgot-password">Forgot Password?</div>
                    
                </div>
            
            <br></br>
            <div> Or continue with </div>
            <div className="log-container">
                <img src={google_icon}></img>
                <img src={facebook_icon}></img>
                <img src={x_icon}></img>
            </div>
            </form>


        </div>
            

    )
   
}

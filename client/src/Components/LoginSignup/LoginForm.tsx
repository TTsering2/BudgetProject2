
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
    //const [action, setAction] = useState("Welcome back");

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
        <div className = "text-[white] text-center w-1/5 h-[65vh] bg-[#0A2430] ml-auto mr-[10%] mt-[45px] mb-5 rounded-[15px] ">
    
            <div className = "p-4">
                <div className = "text text-[25px] mt-[42px]">Welcome Back</div>
            </div>
            
            <form onSubmit={handleLoginSubmit}>
                
                    
                <div className = "p-2">
                    <input className="text-[black] w-[calc(100%_-_60px)] h-[30px] text-xs pl-[5%] rounded-[10px]" placeholder="Username" type="text" value={userName} onChange={UserOnChangeFunction} name="userName"/>
                    {errors.name && <span className="text-error"> {errors.name}</span>}
                </div>
                

                <div className = "p-2">
                    <input className="text-[black] w-[calc(100%_-_60px)] h-[30px] text-xs pl-[5%] rounded-[10px]" placeholder="Password" type="password" value={userPassword} onChange={UserOnChangeFunction} name="userPassword"/>
                    {errors.userPassword && <span className="text-error"> {errors.userPassword}</span>}
                </div>

                
        

                <div className="pt-6">
                {/*  <div className="submit">Sign Up</div>*/}
                <button id="LogInSubmit" type = "submit"> Log in</button>

                    <div className="text-xs mt-[5px] mb-5 rounded-md">Forgot Password?</div>
                    
                </div>
            
            <div className="justify-center h-0.5 w-[70%] mx-auto my-0 rounded-sm bg-[white]"></div>
            <div className="text-logo text-[15px] mt-5 mb-[15px]">Or continue with</div> 
            <div className="flex justify-evenly gap-5 w-full max-w-[calc(100%_-_20px)] ml-[5%] mb-[50px] pt-0 pb-[5px] px-[5px]">
                <img className="h-[25px] gap-10 " src={google_icon}></img>
                <img className="h-[25px] gap-10" src={facebook_icon}></img>
                <img className="h-[25px] gap-10" src={x_icon}></img>
            </div>
            </form>
           


        </div>
            

    )
   
}


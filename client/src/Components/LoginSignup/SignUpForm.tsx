import React, { ChangeEvent, useState } from "react";
import facebook_icon from "@/Assets/fb.png";
import x_icon from "@/Assets/X.png";
import google_icon from "@/Assets/google.png";
import "./LoginPage.css";

export const SignUpForm: React.FC = () => {
  const [name, setName] = useState("");
  const [userName, setUserName] = useState("");
  const [userPassword, setUserPassword] = useState("");
  // const [errors, setErrors] = useState<SignUpFormState>({ name: '', userName: '', userPassword: '' });

  const handleSignUpSubmit = async (
    event: React.FormEvent<HTMLFormElement>,
  ) => {
    event.preventDefault();
    const name = (
      event.currentTarget.querySelector(
        'input[name="name"]',
      ) as HTMLInputElement
    ).value;
    const username = (
      event.currentTarget.querySelector(
        'input[name="userName"]',
      ) as HTMLInputElement
    ).value;
    const password = (
      event.currentTarget.querySelector(
        'input[name="userPassword"]',
      ) as HTMLInputElement
    ).value;
    AddUser(name, username, password);
  };

  async function AddUser(name: string, username: string, password: string) {
    try {
      console.log("Attempting to add user");

      const response = await fetch("http://localhost:5112/api/User", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          name: name,
          username: username,
          password: password,
        }),
      });
      if (response.ok) {
        const data = await response.json();
        console.log(
          "User added successfully. UserID: " +
            data.userId +
            " Username: " +
            data.username +
            " Name: " +
            data.name,
        );
      } else {
        console.log(
          "Failed to add user. Status:",
          response.status,
          "Status text:",
          response.statusText,
        );
        const text = await response.text();
        console.log("Response text:", text);
      }
    } catch (error) {
      console.error(error);
    }
  }

  const UserOnChangeFunction = (event: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    if (name === "name") {
      setName(value);
    } else if (name === "userName") {
      setUserName(value);
    } else if (name === "userPassword") {
      setUserPassword(value);
    }
  };

  return (

    <div className = "flex w-screen h-[75vh]">
      <div className=" h-[89%] w-6/12 relative ml-auto my-auto">
        <img src="./assets/TopCoin1.png" alt="TopCoin" id="Tcoin"></img>
        <img src="./assets/Money1.png" alt="Money1" id="money1"></img>
        <img src="./assets/Money2.png" alt="Money2" id="money2"></img>
        <img src="./assets/Money3.png" alt="Money3" id="money3"></img>
        <img src="./assets/BottomCoin2.png" alt="BottomCoin" id="Bcoin"></img>
        <section className="money-text absolute text-[#0A2430] text-[40px] text-center rounded-[10px] left-[6%] top-[35%]">We can't wait to Budget with you!</section>
      </div>  
      <div className="text-[white] text-center w-1/5 h-[65vh] bg-[#0A2430] ml-auto mr-[10%] mt-[45px] mb-5 rounded-[15px]">
                <div className="p-4">
                    <div className="text text-[25px] mt-[42px]">Nice To Meet You!</div>
                </div>

                <form onSubmit={handleSignUpSubmit}>
                    <div className="p-2 ">
                        <input className="inputVtext-[black] w-[calc(100%_-_60px)] h-[30px] text-xs pl-[5%] rounded-[10px] " placeholder="Name" type="text" value={name} onChange={UserOnChangeFunction} name="name" />
                    </div>

                    <div className="p-2">
                        <input className="text-[black] w-[calc(100%_-_60px)] h-[30px] text-xs pl-[5%] rounded-[10px]" placeholder="Username" type="text" value={userName} onChange={UserOnChangeFunction} name="userName" />
                    </div>

                    <div className="p-2">
                        <input className="text-[black] w-[calc(100%_-_60px)] h-[30px] text-xs pl-[5%] rounded-[10px] " placeholder="Password" type="password" value={userPassword} onChange={UserOnChangeFunction} name="userPassword" />
                    </div>

                    <div className="pt-6">
                
                        <button id="SignUpSubmit" type="submit"> Sign Up</button>
                    </div>

                <div className="justify-center h-0.5 w-[70%] mx-auto my-0 rounded-sm bg-[white]"></div>

                <div className="text-logo text-[15px] mt-5 mb-[15px]" > Or continue with </div>
                <div className="flex justify-evenly gap-5 w-full max-w-[calc(100%_-_20px)] ml-[5%] mb-[50px] pt-0 pb-[5px] px-[5px]">
                    <img className="h-[25px] gap-10" src={google_icon}></img>
                    <img className="h-[25px] gap-10" src={facebook_icon}></img>
                    <img className="h-[25px] gap-10" src={x_icon}></img>
                </div>
                </form>
            </div>
        </div>


            
      
            
  );
};

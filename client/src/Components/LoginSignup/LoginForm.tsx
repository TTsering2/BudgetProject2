import React, { ChangeEvent, useState } from "react";
import facebook_icon from "@/Assets/fb.png";
import x_icon from "@/Assets/X.png";
import google_icon from "@/Assets/google.png";
import "./LoginPage.css";
import { useNavigate } from "react-router-dom";
import useAuth from "@/Hooks/useAuth";

// Interface representing the state of the form
 /*interface FormState {
   userName: string;
   name: string;
   userPassword: string;
 }
 */
/*
 interface LoginUpFormState {
  
  userEmail: string;
  userPassword: string;
}
*/

export const LoginForm: React.FC = () => {
  // form title state
  //const [action, setAction] = useState("Welcome back");

  // form state
  const [userName, setUserName] = useState("");
  const [userPassword, setUserPassword] = useState("");
  //const [errors, setErrors] = useState<LoginUpFormState>({ userEmail: '', userPassword: '' });
  // Sign In error states
  // const [errors, setErrors] = useState<FormState>({
  //   userName: "",
  //   name: "",
  //   userPassword: "",
  // });AA

  const navigate = useNavigate();
  const auth = useAuth();

  async function LoginUser(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();
    const username = e.currentTarget.userName.value;
    const password = e.currentTarget.userPassword.value;
    try {
      await auth?.signIn(username, password);

      //TODO: CHANGE THIS BACK TO INCOME DASH BOARD WHEN DONE
      // navigate("/reportDashboard")
      navigate("/incomeDashboard");
    } catch (error) {
      console.error(error);
      throw error;
    }
    console.log("Login successful. UserID: " + auth?.userId);
  }

  // user input, operate simply input. Without this "onChange" event, we cannot type.
  const UserOnChangeFunction = (synthEvent: ChangeEvent<HTMLInputElement>) => {
    if (synthEvent.target.name === "userName") {
      setUserName(synthEvent.target.value);
    } else if (synthEvent.target.name === "userPassword") {
      setUserPassword(synthEvent.target.value);
    }
  };

  return (
    <div className="flex w-screen h-[75vh]">
      <div className="pic-container h-[89%] w-6/12 relative ml-auto my-auto">
        <img src="./assets/TopCoin1.png" alt="TopCoin" id="Tcoin"></img>
        <img src="./assets/Money1.png" alt="Money1" id="money1"></img>
        <img src="./assets/Money2.png" alt="Money2" id="money2"></img>
        <img src="./assets/Money3.png" alt="Money3" id="money3"></img>
        <img src="./assets/BottomCoin2.png" alt="BottomCoin" id="Bcoin"></img>
        <section className="money-text absolute text-[#0A2430] text-[40px] text-center rounded-[10px] left-[6%] top-[35%]">
          We can't wait to Budget with you!
        </section>
      </div>

      <div className=" text-[white] text-center w-1/5 h-[65vh] bg-[#0A2430] ml-auto mr-[10%] mt-[45px] mb-5 rounded-[15px] ">
        <div className="p-4">
          <div className="text text-[25px] mt-[42px]">Welcome Back</div>
        </div>

       <form onSubmit={LoginUser}>   
           <div className = "p-2">
               <input className="text-[black] w-[calc(100%_-_60px)] h-[30px] text-xs pl-[5%] rounded-[10px]" placeholder="Username" type="text" value={userName} onChange={UserOnChangeFunction} name="userName"/>
                 {/* {errors.userEmail && <span className="text-error"> {errors.userEmail}</span>}   */}
           </div>

           <div className = "p-2">
               <input className="text-[black] w-[calc(100%_-_60px)] h-[30px] text-xs pl-[5%] rounded-[10px]" placeholder="Password" type="password" value={userPassword} onChange={UserOnChangeFunction} name="userPassword"/>
                 {/* {errors.userPassword && <span className="text-error"> {errors.userPassword}</span>}  */}
           </div>

          <div className="pt-6">
            <button id="LogInSubmit" type="submit">
              {" "}
              Log in
            </button>
            <div className="text-xs mt-[5px] mb-5 rounded-md">
              Forgot Password?
            </div>
          </div>

          <div className="justify-center h-0.5 w-[70%] mx-auto my-0 rounded-sm bg-[white]"></div>

          <div className="text-logo text-[15px] mt-5 mb-[15px]">
            Or continue with
          </div>
          <div className="flex justify-evenly gap-5 w-full max-w-[calc(100%_-_20px)] ml-[5%] mb-[50px] pt-0 pb-[5px] px-[5px]">
            <img className="h-[25px] gap-10 " src={google_icon}></img>
            <img className="h-[25px] gap-10" src={facebook_icon}></img>
            <img className="h-[25px] gap-10" src={x_icon}></img>
          </div>
        </form>
      </div>
    </div>
  );
};

import React, { ChangeEvent, useState } from "react";
import facebook_icon from "@/Assets/fb.png";
import x_icon from "@/Assets/X.png";
import google_icon from "@/Assets/google.png";
import "./LoginPage.css";
import { useLocation, useNavigate } from "react-router-dom";
import useAuth from "@/Hooks/useAuth";

// Interface representing the state of the form
// interface FormState {
//   userName: string;
//   name: string;
//   userPassword: string;
// }

export const LoginForm: React.FC = () => {
  // form title state
  const [action, setAction] = useState("Welcome back");

  // form state
  const [userName, setUserName] = useState("");
  const [userPassword, setUserPassword] = useState("");

  // Sign In error states
  // const [errors, setErrors] = useState<FormState>({
  //   userName: "",
  //   name: "",
  //   userPassword: "",
  // });

  const navigate = useNavigate();
  const location = useLocation();
  const auth = useAuth();
  const from = location.state?.from?.pathname || "/";

  async function LoginUser(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();
    const username = e.currentTarget.userName.value;
    const password = e.currentTarget.userPassword.value;
    try {
      // Send them back to the page they tried to visit when they were
      // redirected to the login page. Use { replace: true } so we don't create
      // another entry in the history stack for the login page.  This means that
      // when they get to the protected page and click the back button, they
      // won't end up back on the login page, which is also really nice for the
      // user experience.
      await auth.signIn(username, password);
      navigate(from, { replace: true });
    } catch (error) {
      console.error(error);
      throw error;
    }
    console.log("Login successful. UserID: " + auth.userId);
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
    <div className="Container">
      <div className="header">
        <div className="text"> {action}</div>
      </div>

      <form onSubmit={LoginUser}>
        <div className="input">
          <input
            placeholder="Username"
            type="text"
            value={userName}
            onChange={UserOnChangeFunction}
            name="userName"
          />
          {/* {errors.name && <span className="text-error"> {errors.name}</span>} */}
        </div>

        <div className="input">
          <input
            placeholder="Password"
            type="password"
            value={userPassword}
            onChange={UserOnChangeFunction}
            name="userPassword"
          />
          {/* {errors.userPassword && ( */}
          {/* // <span className="text-error"> {errors.userPassword}</span> */}
          {/* )} */}
        </div>

        <div className="submit-container">
          {/*  <div className="submit">Sign Up</div>*/}
          <button
            type="submit"
            className={action}
            onClick={() => {
              setAction("Welcome Back!");
            }}
          >
            {" "}
            Login
          </button>

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
  );
};

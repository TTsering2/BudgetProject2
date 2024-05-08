import React, { useState } from "react";
import { LoginForm } from "./LoginForm";
import { SignUpForm } from "./SignUpForm";

export const AuthenticationPage = () => {
  const [mode, setMode] = useState<"login" | "signup">("login");

  const toggleMode = () => {
    setMode(mode === "login" ? "signup" : "login");
  };

  return (
    <div>
      {/* <h1>{mode === "login" ? "Login" : "Sign Up"}</h1> */}
      {mode === "login" ? <LoginForm /> : <SignUpForm />}
      <p onClick={toggleMode} style={{ textAlign: "center" }}>
        {mode === "login"
          ? "Don't have an account? Sign up here."
          : "Already have an account? Login here."}
      </p>
    </div>
  );
};

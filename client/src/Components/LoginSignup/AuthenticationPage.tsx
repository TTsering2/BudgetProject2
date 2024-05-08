import React, { useState } from "react";
import { LoginForm } from "./LoginForm";
import { SignUpForm } from "./SignUpForm";
 
// Define the type for the props
interface AuthenticationPageProps {
  initialMode: "login" | "signup";
}
 
export const AuthenticationPage: React.FC<AuthenticationPageProps> = ({
  initialMode,
}) => {
  const [mode, setMode] = useState<"login" | "signup">(initialMode);
 
  const toggleMode = () => {
    const newMode = mode === "login" ? "signup" : "login";
    setMode(newMode);
    console.log(newMode);
  };
 
  return (
    <div>
      {mode === "login" ? <LoginForm /> : <SignUpForm />}
      <p
        onClick={toggleMode}
        style={{ textAlign: "center", cursor: "pointer" }}
      >
        {mode === "login"
          ? "Don't have an account? Sign up here."
          : "Already have an account? Login here."}
      </p>
    </div>
  );
};
 
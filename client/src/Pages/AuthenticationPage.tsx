import React, { useState } from "react";
import { LoginForm } from "../Components/LoginSignup/LoginForm";
import { SignUpForm } from "../Components/LoginSignup/SignUpForm";
import Footer from "@/Components/Footer";
import Header from "@/Components/Header";

interface AuthenticationPageProps {
  initialMode: "login" | "signup";
}
export const AuthenticationPage: React.FC<AuthenticationPageProps> = ({
  initialMode,
}) => {
  const [mode, setMode] = useState<"login" | "signup">(initialMode);

  const toggleMode = () => {
    setMode(mode === "login" ? "signup" : "login");
  };

  return (
    <div>
      <Header></Header>
      {/* <h1>{mode === "login" ? "Login" : "Sign Up"}</h1> */}
      {mode === "login" ? <LoginForm /> : <SignUpForm />}
      <p
        className="text-white bg-primary-dark-blue bg-opacity-50 p-4 shadow-lg hover:bg-opacity-50 hover:scale-105 transform transition-all ease-in-out duration-200 font-lato"
        onClick={toggleMode}
        style={{ textAlign: "center" }}
      >
        {mode === "login"
          ? "Don't have an account? Sign up here."
          : "Already have an account? Login here."}
      </p>
      <Footer />
    </div>
  );
};

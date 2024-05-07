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
    <div className="bg-[url('/assets/bg.png')] bg-cover bg-center ">
      <Header myBoolProp={false}></Header>
      {/* <h1>{mode === "login" ? "Login" : "Sign Up"}</h1> */}
      {mode === "login" ? <LoginForm /> : <SignUpForm />}
      <p onClick={toggleMode} style={{ textAlign: "center" }}>
        {mode === "login"
          ? "Don't have an account? Sign up here."
          : "Already have an account? Login here."}
      </p>

      <Footer></Footer>
    </div>
  );
};

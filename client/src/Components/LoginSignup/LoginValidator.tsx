import React from "react";
import { LoginForm } from "./LoginForm";

interface ValidationErrors {
  email?: string;
  password?: string;
}

// Validation function that takes an object with email and password properties
function Validation(values: {
  email: string;
  password: string;
}): ValidationErrors {
  // Initialize an empty object to store validation errors
  let error: ValidationErrors = {}; // Explicitly define the type of 'error' object

  const email_pattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // no white space, must contain @ and .
  /**It must contain at least one digit.
        It must contain at least one lowercase letter.
        It must contain at least one uppercase letter.
        It can only contain alphanumeric characters (letters and digits).
        It must be at least 8 characters long. 
        */
  const password_pattern = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{8,}$/; //

  // Validate the email field
  if (values.email === "") {
    error.email = "Name should not be empty";
  } else if (!email_pattern.test(values.email)) {
    error.email = "Email Didn't match";
  } else {
    error.email = "";
  }

  // Validate the password field
  if (values.password === "") {
    error.password = "Password should not be empty";
  } else if (!password_pattern.test(values.password)) {
    error.password = "Password didnt match";
  } else {
    error.password = "";
  }

  // Return the object containing validation errors (if any)
  return error;
}

export default Validation;

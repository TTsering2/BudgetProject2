interface ValidationErrors {
  name?: string;
  username?: string;
  password?: string;
}

// Validation function that takes an object with email and password properties
function Validation(values: {
  name: string;
  username: string;
  password: string;
}): ValidationErrors {
  // Initialize an empty object to store validation errors
  const error: ValidationErrors = {}; // Explicitly define the type of 'error' object

  const password_pattern = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{8,}$/; //

  // Validate the email field
  if (values.name === "") {
    error.name = "Name should not be empty";
  } else {
    error.name = "";
  }

  if (values.username === "") {
    error.username = "Name should not be empty";
  } else {
    error.username = "";
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

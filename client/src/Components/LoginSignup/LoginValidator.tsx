interface ValidationErrors {

    name?: string;
    password?: string;
  }
  
  
  function Validation(values: {
    name: string;
    password: string;
  }): ValidationErrors {
    
    const error: ValidationErrors = {}; // Explicitly define the type of 'error' object
  
    //const email_pattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; // no white space, must contain @ and .
    const password_pattern = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{8,}$/; //
    
      // Validate the email field
    if (values.name === "") {
      error.name = "Name should not be empty";
    } else {
      error.name = "";
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
  
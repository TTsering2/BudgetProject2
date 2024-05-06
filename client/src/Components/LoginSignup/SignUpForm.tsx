import React, { ChangeEvent, useState } from "react";
import "./LoginPage.css";

interface IProps {}

export const SignUpForm: React.FC<IProps> = (props: IProps) => {
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
    <div className="Container">
      <div className="header">
        <div className="text">Nice To Meet You!</div>
      </div>

      <form onSubmit={handleSignUpSubmit}>
        <div className="input">
          <input
            placeholder="Name"
            type="text"
            value={name}
            onChange={UserOnChangeFunction}
            name="name"
          />
        </div>

        <div className="input">
          <input
            placeholder="Username"
            type="text"
            value={userName}
            onChange={UserOnChangeFunction}
            name="userName"
          />
        </div>

        <div className="input">
          <input
            placeholder="Password"
            type="password"
            value={userPassword}
            onChange={UserOnChangeFunction}
            name="userPassword"
          />
        </div>

        <div className="submit-container">
          <button type="submit"> Sign Up</button>
        </div>
      </form>
    </div>
  );
};

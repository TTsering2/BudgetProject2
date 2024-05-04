// import React, { ChangeEvent, FormEvent, useState } from 'react';
// import './LoginPage.css';

// // interface AuthFormProps {
// //   isLogin: boolean;
// // }

// const LoginPage = () => {


//   const [{username, password}, setCredentials] = useState({
//     username: '',
//     password: '',
//   });

//   return (
//     <div className="Container">
//       <div className="header">
//       <form > 
           
//         <label htmlFor="username">Username</label>
//         <input placeholder= "Username" value={username} onChange={(event) => setCredentials
//           ({username: event.target.value, password: password})
//         }/>
//         <label htmlFor="password">Password</label>
//         <input placeholder= "Password" type='password' value={password} onChange={(event) => setCredentials({
//           username: username, password: event.target.value 
//         })}/>
//         <button type="submit">Login</button>
//       </form>
//       </div>
//       </div>
//   );
// }

// export default LoginPage;

// // export default function AuthForm({ isLogin } : AuthFormProps) {
// //   const [formData, setFormData] = useState({
// //     username: '',
// //     password: '',
// //     email: '',
// //   });



//   // const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
//   //   setFormData({ ...formData, [e.target.name]: e.target.value });
//   // };

//   // const handleSubmit = (e: FormEvent) => {
//   //   e.preventDefault();
//   //   // Handle form submission here
//   // };

//   // return (
//   //   <React.Fragment>
//   //   <form onSubmit={handleSubmit}>
//   //     {!isLogin && (
//   //       <input
//   //         type="email"
//   //         name="email"
//   //         value={formData.email}
//   //         onChange={handleChange}
//   //         placeholder="Email"
//   //       />
//   //     )}
//   //     <input
//   //       type="text"
//   //       name="username"
//   //       value={formData.username}
//   //       onChange={handleChange}
//   //       placeholder="Username"
//   //     />
//   //     <input
//   //       type="password"
//   //       name="password"
//   //       value={formData.password}
//   //       onChange={handleChange}
//   //       placeholder="Password"
//   //     />
//   //     <button type="submit">{isLogin ? 'Login' : 'Sign Up'}</button>
//   //   </form>
//   //   </React.Fragment>
//   // );
  



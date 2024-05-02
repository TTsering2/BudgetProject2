import React, { useState } from 'react';
import AuthForm from './FormComponent';

function App() {
  const [isLogin, setIsLogin] = useState(true);

  return (
    <div>
      <button onClick={() => setIsLogin(!isLogin)}>
        {isLogin ? 'Sign Up' : 'Login'}
      </button>
      <AuthForm isLogin={isLogin} />
    </div>
      
  )
}

export default App

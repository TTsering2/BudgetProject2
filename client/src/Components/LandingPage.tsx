import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import Header from "./Header";
import Footer from "./Footer";
import { LoginForm } from './LoginSignup/LoginForm';
import { SignUpForm } from './LoginSignup/SignUpForm';
const LandingPage = () => {
    return(
        <Router>
        <div className="bg-[url('/assets/bg.png')] bg-cover bg-center	">  
            <Header></Header>
            <main className="w-10/12 mx-auto">

                <section className="flex flex-row mb-1 mt-5">
                    <div className="w-10/12">
                        <h1 className="text-4xl w-11/12 font-semibold">Empower Your Wallet, Master Your Money</h1>
                        <p className="w-10/12 font-medium mt-6">Introducing SpendWise – your go-to financial management app for effortless budgeting. Easily track income and expenses, set budgets, and gain insights into your spending habits. With SpendWise, smart financial decisions are just a tap away. 
                            Download now and take control of your finances!</p>


                        <div className="mt-10 font-medium">
                            <Link to="/login" className="bg-slate-50 rounded-lg drop-shadow-lg pt-2 pl-6 pr-6 pb-2 mr-3">Log In</Link>
                            <Link to="/signup" className="bg-slate-50 rounded-lg drop-shadow-lg pt-2 pl-6 pr-6 pb-2 ml-3">Sign Up</Link>
                        </div>

                        <Routes>
                            {/* Route for Login */}
                            <Route path="/login" element={<LoginForm />} />
                            {/* Route for SignUp */}
                            <Route path="/signup" element={<SignUpForm />} />
                        </Routes>
                        
                    </div>
                    <div className="w-11/12 border-solid">
                        <img src="./assets/wallet.png" alt="wallet" className="w-96 block m-auto"></img>
                    </div>
                </section>

                <section  className="flex flex-row mb-14 items-center justify-between text-center">
                    <div className="bg-[#2D5872] text-white w-1/4 rounded-lg p-11">
                        <p>500,000+ users worldwide trust SpendWise to manage their finances.</p>
                    </div>
                    <div className="bg-[#2D5872] text-white w-1/4 rounded-lg p-8">
                        <p>99.9% uptime and a robust encryption system ensuring the security and privacy of users' financial data</p>
                    </div>
                    <div className="bg-[#2D5872] text-white  rounded-lg w-1/4 p-8">
                        <p>70% of SpendWise users report staying within their set budgets each month, leading to improved financial health</p>
                    </div>

                </section>

            </main>
                        
            <Footer></Footer>
        </div>
        </Router>
    )
}

export default LandingPage;
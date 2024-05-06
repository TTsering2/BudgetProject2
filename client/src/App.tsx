//Packages
import { FC } from "react";
import {
  Routes,
  useNavigate,
  Route,
} from "react-router-dom";

//Pages
import LandingPage from "@/Pages/LandingPage";
// import ExpensePage from "@Pages/ExpensePage";
// import IncomePage from "@Pages/IncomePage";
// import StockPage from "@Pages/StockPage";
// import BudgetReportPage from "@Pages/BudgetReportPage";
import { AuthenticationPage } from "./Components/LoginSignup/AuthenticationPage";


const App: FC = () => {
  const navigate = useNavigate();
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const setNavigateToLandingPage:() => void = () => {
    navigate("/");
  }

  const setNavigateToUserCredentials:() => void = () => {
    navigate("/userCredentials");
  }


  return (
    <div className = "app bg-gray-20">
      <Routes>
        //Route Landing
        <Route 
          path="/" 
          element= {
            <LandingPage 
              setNavigateToUserCredentials={setNavigateToUserCredentials}
            />
          } 
        />
        //TODO: Route UserCredentials, Expense, Income, Stock, BudgetReport (Proctected Routes, useContext here to save user credentials and keep track of logged in or not)
       <Route
          path="/login"
          element={<AuthenticationPage initialMode="login" />}
        />
        <Route
          path="/signup"
          element={<AuthenticationPage initialMode="signup" />}
        />
      </Routes>
      {/* <AuthenticationPage /> */}
    </div>
  )
}




export default App

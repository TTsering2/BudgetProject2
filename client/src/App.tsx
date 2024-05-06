//Packages
import { FC } from "react";
import {
  Routes,
  useNavigate,
  Route,
} from "react-router-dom";

//Pages
import LandingPage from "@/Pages/LandingPage";
import ExpensePage from "@/Pages/ExpensePage";
import IncomePage from "@/Pages/IncomePage";
import StockPage from "@/Pages/StockPage";
import BudgetReportPage from "@/Pages/BudgetReportPage";


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
        <Route path="/income/:id" element = {<IncomePage/>} ></Route>
        <Route path="/expense/:id" element = {<ExpensePage/>} ></Route>


        //TODO: Route UserCredentials, Expense, Income, Stock, BudgetReport (Proctected Routes, useContext here to save user credentials and keep track of logged in or not)
      </Routes>
    </div>
  )
}




export default App

//Packages
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
import UserCredentialPage from "@/Pages/UserCredentialPage";
import AuthProvider from "@/Components/AuthProvider";
import RequireAuth from "@/Components/RequireAuth";
import { AuthenticationPage } from "./Pages/AuthenticationPage";


const App = () => {
  const navigate = useNavigate();

  // const setNavigateToLandingPage:() => void = () => {
  //   navigate("/");
  // }

  const setNavigateToUserCredentials:() => void = () => {
    navigate("/userCredentials");
  }


  return (
    <div className="App">
    <AuthProvider>
      <Routes>
      {/* Route LandingPage */}
        <Route path = "/" element= {
          <LandingPage 
            setNavigateToUserCredentials={setNavigateToUserCredentials}
          />
        }/>

      {/*Route User Credential page */}
        <Route path = "/userCredentials" element = {
          <UserCredentialPage 
        />
      }/>

      {/* Income Protected Routes */}
        <Route path = "/incomeDashboard" element = {  
          <RequireAuth>
            <IncomePage />
          </RequireAuth>
        }/>

      {/*Expense Protected Routes */}
        <Route path = "/expenseDashboard" element = {
          <RequireAuth>
            <ExpensePage />
          </RequireAuth>
        }/>

      {/* Stock Protected Routes */}
        <Route path = "/stockDashboard" element = {
            <RequireAuth>
              <StockPage />
            </RequireAuth>
        }/>

      {/* Report Dashboard Protected Routes */}
        <Route path = "/reportDashboard" element = {
            <RequireAuth>
              <BudgetReportPage />
            </RequireAuth>
        }/>  
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
    </AuthProvider>
    </div>
  )
}

export default App;
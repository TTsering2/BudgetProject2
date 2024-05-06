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

const App = () => {
  const navigate = useNavigate();
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const setNavigateToLandingPage:() => void = () => {
    navigate("/");
  }

  const setNavigateToUserCredentials:() => void = () => {
    navigate("/userCredentials");
  }

  return (
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
      {/* Stock Protected Routes */}
        <Route path = "/reportDashboard" element = {
            <RequireAuth>
              <BudgetReportPage />
            </RequireAuth>
        }/>  
      </Routes>
    </AuthProvider>
  )
}

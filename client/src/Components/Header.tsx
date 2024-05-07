import useAuth from "@/Hooks/useAuth";
import { Link } from "react-router-dom";

const Header = () => {
  const auth = useAuth();
  async function handleSignOut() {
    try{
      await auth?.signOut();
    } catch (error) {
      console.error(error);
      throw error;
    }
  }
  return (
    <header className="header text-black p-6 w-10/12 mx-auto aling-center flex flex-row justify-between">
      <div>
        <img
          src="./assets/SpendWiseTop.svg"
          alt="logo"
          className="mr-4 w-40"
        ></img>
      </div>
      {auth?.userId !== undefined ? (
        <section className="flex flex-row  items-center justify-between pb-4">
          <ul className="flex flex-row justify-center">
            <li className="mr-5">
              <Link to="/incomeDashboard">Income</Link>
            </li>
            <li className="mr-5">
              <Link to="/expenseDashboard">Expenses</Link>
            </li>
            <li className="mr-5">
              <Link to="/stockDashboard">Stocks</Link>
            </li>
            <li className="mr-5">
              <Link to="/reportDashboard">Reports</Link>
            </li>
          </ul>
          <button
            onClick={handleSignOut}
            className="bg-primary-green-blue text-white rounded-lg h-10 w-40 drop-shadow-lg pt-2 pl-6 pr-6 pb-2 mr-3"
          >
            <Link to="/login">Log Out</Link>
          </button>
        </section>
      ) : (
        <div className="flex flex-row">
          <Link to="/login" className="mr-3">
            <button className="bg-primary-green-blue text-white rounded-lg h-10 w-40 drop-shadow-lg">
              Join us
            </button>
          </Link>
        </div>
      )}
    </header>
  );
};

export default Header;

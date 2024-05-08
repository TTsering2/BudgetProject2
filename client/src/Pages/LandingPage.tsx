import Header from "@/Components/Header";
import Footer from "@/Components/Footer";
import { Link } from "react-router-dom";
// import useAuth from "@/Hooks/useAuth";

// type Props = {
// };
// {  }: Props
const LandingPage = () => {
  return (
    <div className="bg-[url('/assets/bg.png')] bg-cover bg-center">
      <Header></Header>
      <main className="w-[1300px] mx-auto mt-5 mb-10">
        <section className="flex flex-row mb-1  items-center">
          <div className="w-11/12">
            <h1 className="text-4xl w-6/12 font-semibold">
              Empower Your Wallet, Master Your Money
            </h1>
            <p className="w-8/12 font-medium mt-6">
              Introducing SpendWise – your go-to financial management app for
              effortless budgeting. Easily track income and expenses, set
              budgets, and gain insights into your spending habits. With
              SpendWise, smart financial decisions are just a tap away. Download
              now and take control of your finances!
            </p>
            <div className="mt-10 font-medium">
              <Link
                to="/login"
                className="bg-slate-50 rounded-lg drop-shadow-lg pt-2 pl-6 pr-6 pb-2 mr-3"
              >
                Log In
              </Link>
              <Link
                to="/signup"
                className="bg-slate-50 rounded-lg drop-shadow-lg pt-2 pl-6 pr-6 pb-2 ml-3"
              >
                Sign Up
              </Link>
            </div>
          </div>
          <div className="w-7/12 border-solid">
            <img
              src="./assets/wallet.png"
              alt="wallet"
              className="w-[480px] m-auto"
            ></img>
          </div>
        </section>

        <section className="flex flex-row items-center justify-between text-center w-[1300px] m-auto pb-14 ">
          <div className="bg-[#2D5872] text-white w-[300px] rounded-lg h-[190px]">
            <p className="w-[200px] text-left m-auto mt-16">
              <b>500,000+ users</b> worldwide trust SpendWise to manage their
              finances.
            </p>
          </div>
          <div className="bg-[#2D5872] text-white w-[300px] rounded-lg  h-[190px]">
            <p className="w-[200px] text-left m-auto mt-8">
              99.9% uptime and a <b>robust encryption system</b> ensuring the
              security and privacy of users' financial data
            </p>
          </div>
          <div className="bg-[#2D5872] text-white  rounded-lg w-[300px]  h-[170px]">
            <p className="w-[200px] text-left m-auto mt-5">
              <b>70% of SpendWise users</b> report staying within their set
              budgets each month, leading to improved financial health
            </p>
          </div>
        </section>
      </main>
      <Footer></Footer>
    </div>
  );
};

export default LandingPage;

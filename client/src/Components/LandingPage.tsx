import Header from "./Header";
import Footer from "./Footer";
const LandingPage = () => {
    return(
        <>  
            <Header></Header>
            <main className="w-10/12 mx-auto">

                <section className="flex flex-row mb-4">
                    <div>
                        <h1 className="text-4xl w-6/12 font-semibold">Empower Your Wallet, Master Your Money</h1>
                        <p className="w-6/12 font-medium mt-6">Introducing SpendWise – your go-to financial management app for effortless budgeting. Easily track income and expenses, set budgets, and gain insights into your spending habits. With SpendWise, smart financial decisions are just a tap away. 
                            Download now and take control of your finances!</p>
                        <div className="mt-6 font-medium">
                            <a className="bg-slate-50 rounded-lg drop-shadow-lg pt-2 pl-6 pr-6 pb-2 mr-3">Log In</a>
                            <a className="bg-slate-50 rounded-lg drop-shadow-lg pt-2 pl-6 pr-6 pb-2 ml-3">Sign Up</a>
                        </div>
                    </div>
                    <div>
                        <img src="./assets/wallet_img.svg" alt="wallet" className="w-96"></img>
                    </div>
                </section>

                <section  className="flex flex-row mt-4 mb-4 items-center justify-between text-center">
                    <div className="bg-[#0A2430] text-white w-1/4 rounded-lg p-3">
                        <p>500,000+ users worldwide trust SpendWise to manage their finances.</p>
                    </div>
                    <div className="bg-[#0A2430] text-white w-1/4 rounded-lg p-3">
                        <p>99.9% uptime and a robust encryption system ensuring the security and privacy of users' financial data</p>
                    </div>
                    <div className="bg-[#0A2430] text-white  rounded-lg w-1/4 p-3">
                        <p>70% of SpendWise users report staying within their set budgets each month, leading to improved financial health</p>
                    </div>

                </section>

            </main>
            <Footer></Footer>
        </>
    )
}

export default LandingPage;
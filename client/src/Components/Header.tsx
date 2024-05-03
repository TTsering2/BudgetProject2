
const Header = () => {

    //or userState or Context
    return (
        <header className="header text-white p-6">
        
            <section className="flex flex-row  items-center justify-between pb-4 w-10/12 mx-auto">
                <div className="flex flex-row mr-6 items-center	">
                    <img src="./assets/SpendWiseTop.svg" alt="logo" className="mr-4 w-40"></img>
                </div>
                

                <div className="flex flex-row">
                    <a href=""><img src="./assets/JoinUs.svg" className="w-32  mr-2"></img></a>
                </div>

            </section>

        </header>
    )
}

export default Header;
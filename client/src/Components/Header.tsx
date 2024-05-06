import React, { useState } from 'react';
 
 
interface joinUsProps {
    myBoolProp: boolean;
}
 
 
const Header = (props: joinUsProps) => {
 
 
    return (
        <header className="header text-black p-6 w-10/12 mx-auto aling-center flex flex-row justify-between">
            <div>
                <img src="../assets/SpendWiseTop.svg" alt="logo" className="mr-4 w-40"></img>
            </div>
            {props.myBoolProp ?
                <section className="flex flex-row  items-center justify-between pb-4">
                    <ul className="flex flex-row justify-center">
                        <li className="mr-5"><a href="https://www.google.com">Income</a></li>
                        <li className="mr-5"><a href="https://www.bing.com">Expense</a></li>
                        <li className="mr-5"><a href="https://www.cnn.com/">Budget</a></li>
                        <li className="mr-5"><a href="https://www.foxnews.com">Calendar</a></li>
                    </ul>
                    <a href=""><img src="../assets/JoinUs.svg" className="w-32  mr-2 ml-10"></img></a>
                </section>
            :
                <div className="flex flex-row">
                    <a href=""><img src="../assets/JoinUs.svg" className="w-32  mr-2"></img></a>
                </div>
            }
        </header>
    );
}

export default Header;
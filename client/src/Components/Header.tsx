import React, { useState } from 'react';
 
 
interface joinUsProps {
    myBoolProp: boolean;
}
 
 
const Header: React.FC<joinUsProps> = (props: joinUsProps) => {
 
 
    return (
        <React.Fragment>
           
            {props.myBoolProp ?
           
            <header className="header text-black p-6">
            <section className="flex flex-row  items-center justify-between pb-4">
                <div className="flex flex-row mr-6 items-center ">
                    <img src="./assets/SpendWiseTop.svg" alt="logo" className="mr-4 w-40"></img>
                </div>
 
                <div className="flex flex-row">
 
                <ul className="flex flex-row">
                        <li className="mr-32"><a href="https://www.google.com">Income</a></li>
                        <li  className="mr-32"><a href="https://www.bing.com">Expense</a></li>
                        <li  className="mr-32"><a href="https://www.cnn.com/">Budget</a></li>
                        <li  className="mr-32"><a href="https://www.foxnews.com">Calendar</a></li>
                </ul>
 
 
                <a href=""><img src="./assets/JoinUs.svg" className="w-32  mr-2"></img></a>
                </div>
 
            </section>
            </header>
            :
            <header className="header text-white p-6">
            <section className="flex flex-row  items-center justify-between pb-4">
                <div className="flex flex-row mr-6 items-center ">
                    <img src="./assets/SpendWiseTop.svg" alt="logo" className="mr-4 w-40"></img>
                </div>
               
 
                <div className="flex flex-row">
                    <a href=""><img src="./assets/JoinUs.svg" className="w-32  mr-2"></img></a>
                </div>
 
            </section>
            </header>
            }
 
        </React.Fragment>
    );
}

export default Header;
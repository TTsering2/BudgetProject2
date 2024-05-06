import Header from "@/Components/Header";
import Footer from "@/Components/Footer";
import { getFirstAndLastDateOfMonth, formatDate} from '../utils/generateReportDate';
import { useEffect, useState } from "react";

const IncomePage = () => {

    const[userData, setUserData] = useState([]);

    //Get user income
     const getAllUserIncome = async() => {
        try{

            const response = await fetch('http://localhost:5112/api/Income/userId=2');
            if(!response.ok){
                throw new Error(response.statusText);
            }
            else{
                const data = await response.json();
                setUserData(data);
                return data;
            }

        }
        catch(err){
            console.log(err)
        }
    }

    //Get Budget Report
    const getBudgetReport = async() => {

        try{
            const response = await fetch('http://localhost:5112/expenseReport/userId=2/startDate=2024-05-06T20:02:30.703Z/endDate=2024-05-29'
        );
            if(!response.ok){
                throw new Error(response.statusText);
            }
            else{
                const data = await response.json();
                setUserData(data);
                return data;
            }
        }
        catch(err){
            console.log(err)
        }
    }



    useEffect(()=>{
        getAllUserIncome();
    },[])


    return(
        <div className="bg-[url('/assets/bg.png')] bg-cover bg-center">
            <Header myBoolProp={true}></Header>

            {
                userData.length === 0 ?  /*Component with income*/

                (<h1>NO INCOME</h1>)
                :
                /*Component with no income*/
                (
                <section>
                    <div className="bg-primary-white font-bold w-[1300]">
                        <h2>Income Summary</h2>
                        <div>
                            <div></div>
                            <div></div>
                        </div>
                        <div></div>
                    </div>
                    <button>Add a New Income</button>
                    
                    <ul>
                        {
                           /*Iterate userData*/
                           userData.map((element, key) => (

                           <li key={key}>
                            <div>
                                <h3>{element.type}</h3>
                                <h3>{element.amount}</h3>
                            </div>
                            <div>
                                <h5>{element.title}</h5>

                            </div>

                            </li>))
                        }
                    </ul>


                </section>

            )
            }




            <Footer></Footer>
        </div>
    )
}

export default IncomePage;
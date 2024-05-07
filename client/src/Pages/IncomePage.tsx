import Header from "@/Components/Header";
import Footer from "@/Components/Footer";
import { getFirstAndLastDateOfMonth, formatDate} from '../utils/generateReportDate';
import { useEffect, useState } from "react";


interface UserData {
    type: string;
    title: string;
    amount: number;
  }

  interface IncomeByType {
    [key: string]: UserData[]
  }
  
  interface TypeTotalIncome{
    [type:string]:number;
  }
  

const IncomePage = () => {

    const[userData, setUserData] = useState<UserData[]>([]);

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


    //Group UserData by type of income
    const incomeByType: IncomeByType = userData.reduce((dataContainer:IncomeByType, element:UserData) => {
        //If there is no element type then create new type and assign value of empty array
        if(!dataContainer[element.type]){
            dataContainer[element.type] = [];
        }
            dataContainer[element.type].push(element);
            return dataContainer
    }, {})

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
        <div className="bg-[url('/assets/bg.png')] bg-cover bg-center ">
            <Header myBoolProp={true}></Header>

            {
                userData.length === 0 ?  /*Component with income*/

                (<h1>NO INCOME</h1>)
                :
                /*Component with no income*/
                (
                <section className="h-5/6">
                    <div className="bg-primary-white font-bold w-[1350px] m-auto p-6 rounded mt-6">
                        <h2>Income Summary</h2>
                        <div>
                            <div></div>
                            <div></div>
                        </div>
                        <div></div>
                    </div>
                        <div className="w-[1350px] m-auto my-5 " >
                            <button className="bg-primary-green-blue text-white	p-2 px-7 rounded  text-center mx-auto block">Add a New Income</button>
                        </div>
                    
                    <ul className="w-[1350px] m-auto bg-primary-white rounded-xl my-5">
                    {Object.entries(incomeByType).map(([type, data], key) => (
                        <div key={key} className="p-4 border-b-2 border-primary-dark-blue w-[1350px] m-auto ">
                            <div className=" p-4 w-[1350px] m-auto my-3">
                                <h3 className="text-2xl	font-semibold ">{type.charAt(0).toUpperCase() + type.substring(1)}</h3>
                                
                                {/* TOTAL AMOUNT 
                                
                            /*{"paycheck": [{title:, type:"paycheck", amount:100}, {title:, type:"paycheck", amount:100}, {title:, type:"paycheck", amount:100}],
                                "salary": [{title:, type:"salary", amount:100}, {title:, type:"salary", amount:100}, {title:, type:"salary", amount:100}],
                            ""}*/
                                }
                                <div className="m-auto">
                                {data.map((element: UserData, index: number) => (
                                    <div key={index} className="flex flex-row justify-between w-[1000px]">
                                        <h5  className=" p-4">{element.title.charAt(0).toUpperCase() + element.title.substring(1)}</h5>
                                        <h3>{element.amount}</h3>
                                    </div>
                                ))}
                                </div>
                            </div>
                        </div>
                    ))}
                    </ul>


                </section>

            )
            }




            <Footer></Footer>
        </div>
    )
}

export default IncomePage;
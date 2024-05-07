import Header from "@/Components/Header";
import Footer from "@/Components/Footer";
import { getFirstAndLastDateOfMonth, formatDate} from '../utils/generateReportDate';
import useAuth from "@/Hooks/useAuth";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faArrowRight } from '@fortawesome/free-solid-svg-icons';
import { faMoneyBillWave } from '@fortawesome/free-solid-svg-icons';
import { useEffect, useState } from "react";
 
 
interface UserData {
    type: string;
    title: string;
    amount: number;
  }
 
  interface IncomeByType {
    [key: string]: {
        data:UserData[],
        totalIncome:number
    }
}
 
 
const IncomePage = () => {
 
    const[userData, setUserData] = useState<UserData[]>([]);
    const [showData, setShowData] = useState<{ [key: string]: boolean }>({});
    const[reportData, setReportData] = useState([]);
    const { userId, signIn, signOut } = useAuth();
    const userIdValue = userId?.toString();



    const toggleShowData = (type: string) => {
      setShowData(prevState => ({
        ...prevState,
        [type]: !prevState[type]
      }));
    };


 
    //Get user income
     const getAllUserIncome = async() => {
        try{
 
            const response = await fetch(`http://localhost:5112/api/Income/userId=${userIdValue}`);
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
            dataContainer[element.type] = {
                data:[],
                totalIncome:0
            };
 
        }
            dataContainer[element.type].data.push(element);
            dataContainer[element.type].totalIncome += element.amount;
            return dataContainer
    }, {})
 
 
    //Get Budget Report
    const getBudgetReport = async() => {
 
        try{
            const response = await fetch(`http://localhost:5112/expenseReport/userId=${userIdValue}/startDate=2024-05-06T20:02:30.703Z/endDate=2024-05-29`
        );
            if(!response.ok){
                throw new Error(response.statusText);
            }
            else{
                const data = await response.json();
                setReportData(data);
                console.log(data)
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
        <div className="bg-gradient-bluewhite h-screen">
            <Header myBoolProp={true}></Header>
 
            {
                userData.length === 0 ?  /*Component with income*/
 
                (<h1>NO INCOME</h1>)
                :
                /*Component with no income*/
                (
                <section className="h-5/6 roboto">
                    <div className="bg-[#FFFFFF] font-bold w-[1350px] m-auto p-6  px-10 rounded mt-6 ">
                        <h2 className="text-xl">Income Summary</h2>
                        <div className="flex flex-row justify-between mt-9 w-[1300px]">
                            <div>
                              <p className="text-3xl">$6,000</p>
                              <p className="text-lg font-normal	">Total Income</p>
                            </div>
                            <div className="w-2/12">
                              <p className="text-3xl font-semibold" >May 2024</p>
                              <p  className="text-xl font-normal	">17 Days Left</p>
                            </div>
                        </div>
                        <div className="mt-10">
                          <p>Paycheck</p>
                          </div>
                    </div>
                        <div className="w-[1350px] m-auto my-5 " >
                            <button className="bg-primary-green-blue text-white p-2 px-7 rounded  text-center mx-auto block">Add a New Income</button>
                        </div>
                   
                    <div className="w-[1350px] m-auto ">
                       {Object.entries(incomeByType).map(([type, { data, totalIncome }], key) => (
                          <div key={key} className="p-2 bg-[#FFFFFF] m-auto rounded-xl mb-9">
                            <div className="w-[1350px] m-auto shadow-gray-100 py-2">
                              <div className="w-[1250px] m-auto border-b-2 border-primary-green-blue pb-3 flex flex-row gap-2 items-center">
                                <FontAwesomeIcon icon={faMoneyBillWave} className="text-[#2D5872] text-2xl" />
                                <h3 className="text-2xl font-semibold w-11/12">{type.charAt(0).toUpperCase() + type.substring(1)}</h3>
                                <div className="flex flex-row gap-5 items-center">
                                  <h3 className="text-2xl font-semibold">${totalIncome}</h3>
                                  <FontAwesomeIcon
                                    icon={faArrowRight}
                                    className="cursor-pointer text-[#2D5872]"
                                    onClick={() => toggleShowData(type)}
                                  />
                                </div>
                              </div>
                              {/*DISPLAY FIRST ELEMENT*/}
                               <div key={0} className="flex flex-row justify-between w-11/12 m-auto my-5">
                                  <h5 className="p-1 font-semibold">{data[0].title.charAt(0).toUpperCase() + data[0].title.substring(1)}</h5>
                                  <h5 className="text-2x font-semibold">${data[0].amount}</h5>
                              </div>
                             {/*DISPLAY ALL ELEMENTS*/}
                              {showData[type] && (
                                <div className="m-auto">
                                  {data.slice(1).map((element: UserData, index: number) => (
                                    <div key={index+1} className="flex flex-row justify-between w-11/12 m-auto my-5">
                                      <h5 className="p-1 font-semibold">{element.title.charAt(0).toUpperCase() + element.title.substring(1)}</h5>
                                      <h5 className="text-2x font-semibold">${element.amount}</h5>
                                    </div>
                                  ))}
                                </div>
                              )}
                            </div>
                          </div>
                        ))}
                    </div>
 
 
                </section>
 
            )
            }
 
 
 
 
            <Footer></Footer>
        </div>
    )
}
 
export default IncomePage;
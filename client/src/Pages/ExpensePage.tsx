import Header from "@/Components/Header";
import Footer from "@/Components/Footer";
import {
  getFirstAndLastDateOfMonth,
  formatDate,
} from "../utils/generateReportDate";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faMoneyBillWave } from "@fortawesome/free-solid-svg-icons";
import { useEffect, useState } from "react";

interface UserData {
  type: string;
  title: string;
  amount: number;
}

interface ExpenseByType {
  [key: string]: {
    data: UserData[];
    totalExpense: number;
  };
}

const ExpensePage = () => {
  const [userData, setUserData] = useState<UserData[]>([]);

  //Get user expense
  const getAllUserExpense = async () => {
    try {
      const response = await fetch(
        "http://localhost:5112/api/Expense/userId=3",
      );
      if (!response.ok) {
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        setUserData(data);
        return data;
      }
    } catch (err) {
      console.log(err);
    }
  };

  //Group UserData by type of expense
  const expenseByType: ExpenseByType = userData.reduce(
    (dataContainer: ExpenseByType, element: UserData) => {
      //If there is no element type then create new type and assign value of empty array
      if (!dataContainer[element.type]) {
        dataContainer[element.type] = {
          data: [],
          totalExpense: 0,
        };
      }
      dataContainer[element.type].data.push(element);
      dataContainer[element.type].totalExpense += element.amount;
      return dataContainer;
    },
    {},
  );

  //Get Budget Report
  const getBudgetReport = async () => {
    try {
      const response = await fetch(
        "http://localhost:5112/expenseReport/userId=2/startDate=2024-05-06T20:02:30.703Z/endDate=2024-05-29",
      );
      if (!response.ok) {
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        setUserData(data);
        return data;
      }
    } catch (err) {
      console.log(err);
    }
  };

  useEffect(() => {
    getAllUserExpense();
  }, []);

  return (
    <div className="bg-[url('/assets/bg.png')] bg-cover bg-center ">
      <Header myBoolProp={true}></Header>

      {userData.length === 0 /*Component with expense*/ ? (
        <h1>NO EXPENSE</h1>
      ) : (
        /*Component with no expense*/
        <section className="h-5/6">
          <div className="bg-primary-white font-bold w-[1350px] m-auto p-6 rounded mt-6">
            <h2>Expense Summary</h2>
            <div>
              <div></div>
              <div></div>
            </div>
            <div></div>
          </div>
          <div className="w-[1350px] m-auto my-5 ">
            <button className="bg-primary-green-blue text-white p-2 px-7 rounded  text-center mx-auto block">
              Add a New Expense
            </button>
          </div>

          <div className="w-[1350px] m-auto">
            {Object.entries(expenseByType).map(
              ([type, { data, totalExpense }], key) => (
                <div
                  key={key}
                  className="p-2 bg-primary-white w-[1350px] m-auto   rounded-xl mb-9 "
                >
                  <div className="w-[1350px] m-auto shadow-gray-100 py-2  ">
                    <div className="w-[1250px] m-auto border-b-2 border-primary-green-blue pb-3 flex flex-row gap-2  items-center">
                      <FontAwesomeIcon
                        icon={faMoneyBillWave}
                        className="color[primary-green-blue] text-2xl"
                      />
                      <h3 className="text-2xl font-semibold  w-11/12">
                        {type.charAt(0).toUpperCase() + type.substring(1)}
                      </h3>
                      <h3 className="text-2xl font-semibold">
                        ${totalExpense}
                      </h3>
                    </div>

                    <div className="m-auto">
                      {data.map((element: UserData, index: number) => (
                        <div
                          key={index}
                          className="flex flex-row justify-between w-11/12 m-auto my-5 "
                        >
                          <h5 className=" p-1 font-semibold ">
                            {element.title.charAt(0).toUpperCase() +
                              element.title.substring(1)}
                          </h5>
                          <h5 className="text-2x font-semibold ">
                            ${element.amount}
                          </h5>
                        </div>
                      ))}
                    </div>
                  </div>
                </div>
              ),
            )}
          </div>
        </section>
      )}

      <Footer></Footer>
    </div>
  );
};

export default ExpensePage;

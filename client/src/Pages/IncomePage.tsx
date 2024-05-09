import Header from "@/Components/Header";
import Footer from "@/Components/Footer";
import { getFirstAndLastDateOfMonth } from "../utils/generateReportDate";
import useAuth from "@/Hooks/useAuth";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faArrowRight } from "@fortawesome/free-solid-svg-icons";
import { faMoneyBillWave } from "@fortawesome/free-solid-svg-icons";
import { useEffect, useState } from "react";
import { NewIncomeForm } from "@/Components/NewIncomeForm";

interface UserData {
  type: string;
  title: string;
  amount: number;
}

interface IncomeByType {
  [key: string]: {
    data: UserData[];
    totalIncome: number;
  };
}

const IncomePage = () => {
  const [userData, setUserData] = useState<UserData[]>([]);
  const [showData, setShowData] = useState<{ [key: string]: boolean }>({});
  const [reportData, setReportData] = useState([]);
  const [totalIncome, setTotalIncome] = useState(0);
  const [currentDate, setCurrentDate] = useState({
    month: "",
    differenceInDays: 0,
  });

  const [toggleIncomeForm, setToggleIncomeForm] = useState(true);

  const { userId, signIn, signOut } = useAuth();
  const userIdValue = userId?.toString();

  const toggleShowData = (type: string) => {
    setShowData((prevState) => ({
      ...prevState,
      [type]: !prevState[type],
    }));
  };

  const colors: string[] = ["#DD3535", "#F39202", "#FFBE00", "#27CA40"];
  const [barColors, setBarColors] = useState(
    colors[Math.floor(Math.random() * 4)],
  );

  //Get user income
  const getAllUserIncome = async () => {
    try {
      const response = await fetch(`http://localhost:5112/api/Income/userId=2`);
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

  //Get Budget Report
  const getBudgetReport = async () => {
    //Get dates
    const dates = getFirstAndLastDateOfMonth();
    setCurrentDate({
      month: dates.monthName,
      differenceInDays: dates.dateUntilMonthEds,
    });

    try {
      const response = await fetch(
        `http://localhost:5112/incomeReport/userId=2/startDate=${dates.firstDate}/endDate=${dates.lastDate}`,
      );
      if (!response.ok) {
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        setReportData(data.incomeByCategory);

        getTotalIncome(reportData);

        return data;
      }
    } catch (err) {
      console.log(err);
    }
  };

  //Group UserData by type of income
  const incomeByType: IncomeByType = userData.reduce(
    (dataContainer: IncomeByType, element: UserData) => {
      //If there is no element type then create new type and assign value of empty array
      if (!dataContainer[element.type]) {
        dataContainer[element.type] = {
          data: [],
          totalIncome: 0,
        };
      }
      dataContainer[element.type].data.push(element);
      dataContainer[element.type].totalIncome += element.amount;
      return dataContainer;
    },
    {},
  );

  //GET TOTAL INCOME
  // const getTotalIncome = (data: Object) => {
  //   const categories = data;
  //   const total = Object.values(categories).reduce((sum: number, element) => {
  //     return (sum += element);
  //   }, 0);
  //   setTotalIncome(total);
  //   // console.log(total)
  // };

  // useEffect(() => {
  //   getAllUserIncome();
  //   getBudgetReport();
  // }, [userData]);

  //Report width
  const totalWidth = Object.values(reportData).reduce(
    (total, value) => total + value,
    0,
  );

  return (
    <div className="bg-gradient-bluewhite h-screen">
      <Header />

      {userData.length === 0 /*Component with income*/ ? (
        <h1>NO INCOME</h1>
      ) : (
        /*Component with no income*/
        <section className="h-5/6 roboto">
          <div className="bg-[#FFFFFF] font-bold w-[1350px] m-auto p-6 px-10 rounded mt-6 pb-20 ">
            <h2 className="text-xl">Income Summary</h2>
            <div className="flex flex-row justify-between mt-9 w-[1300px]">
              <div>
                <p className="text-3xl">${totalIncome}</p>
                <p className="text-lg font-normal	">Total Income</p>
              </div>
              <div className="w-2/12">
                <p className="text-3xl font-semibold text-right pr-10">
                  {currentDate.month}
                </p>
                <p className="text-xl font-normal	text-right pr-10">
                  {currentDate.differenceInDays} Days Left
                </p>
              </div>
            </div>
            <div className="flex flex-col gap-4">
              <div className="flex items-center"></div>
              <div className="flex items-center">
                <div
                  className="bg-blue-500 h-8"
                  style={{ width: totalWidth + "px" }}
                ></div>
              </div>
              <div className="flex items-center  rounded-xl">
                {Object.entries(reportData).map(([key, value]) => (
                  <div key={key} className="w-32 rounded-xl">
                    {key.charAt(0).toUpperCase() + key.substring(1)}
                  </div>
                ))}
              </div>
            </div>
          </div>
          <div className="w-[1350px] m-auto my-5">
            <button className="bg-primary-green-blue text-white p-2 px-7 rounded  text-center mx-auto block">
              Add a New Income
            </button>
          </div>

          {/*FORM ADD ENTRY */}
          {toggleIncomeForm && <NewIncomeForm />}

          <div className="w-[1350px] m-auto ">
            {Object.entries(incomeByType).map(
              ([type, { data, totalIncome }], key) => (
                <div
                  key={key}
                  className="p-2 bg-[#FFFFFF] m-auto rounded-xl mb-9"
                >
                  <div className="w-[1350px] m-auto shadow-gray-100 py-2">
                    <div className="w-[1250px] m-auto border-b-2 border-primary-green-blue pb-3 flex flex-row gap-2 items-center">
                      <FontAwesomeIcon
                        icon={faMoneyBillWave}
                        className="text-[#2D5872] text-2xl"
                      />
                      <h3 className="text-2xl font-semibold w-11/12">
                        {type.charAt(0).toUpperCase() + type.substring(1)}
                      </h3>
                      <div className="flex flex-row gap-5 items-center">
                        <h3 className="text-2xl font-semibold">
                          ${totalIncome}
                        </h3>
                        <FontAwesomeIcon
                          icon={faArrowRight}
                          className="cursor-pointer text-[#2D5872]"
                          onClick={() => toggleShowData(type)}
                        />
                      </div>
                    </div>
                    {/*DISPLAY FIRST ELEMENT*/}
                    <div
                      key={0}
                      className="flex flex-row justify-between w-11/12 m-auto my-5"
                    >
                      <h5 className="p-1 font-semibold">
                        {data[0].title.charAt(0).toUpperCase() +
                          data[0].title.substring(1)}
                      </h5>
                      <h5 className="text-2x font-semibold">
                        ${data[0].amount}
                      </h5>
                    </div>
                    {/*DISPLAY ALL ELEMENTS*/}
                    {showData[type] && (
                      <div className="m-auto">
                        {data
                          .slice(1)
                          .map((element: UserData, index: number) => (
                            <div
                              key={index + 1}
                              className="flex flex-row justify-between w-11/12 m-auto my-5"
                            >
                              <h5 className="p-1 font-semibold">
                                {element.title.charAt(0).toUpperCase() +
                                  element.title.substring(1)}
                              </h5>
                              <h5 className="text-2x font-semibold">
                                ${element.amount}
                              </h5>
                            </div>
                          ))}
                      </div>
                    )}
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

export default IncomePage;

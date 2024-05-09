import Footer from "@/Components/Footer";
import Header from "@/Components/Header";
import useAuth from "@/Hooks/useAuth";
import { FC, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  FormatDateToCsharp,
  getFirstAndLastDateOfMonth,
  getMonthBounds,
  getYearBounds,
  extractYearAndMonth,
  cleanDate
} from "@/Functions/timeFunctions";
import { calculateRollingSums, RollingSumResult } from "@/Functions/reportFunctions";
import { LineAreaChart } from "@/Components/BudgetReportComponents/LineAreaChart";


const BudgetReportPage: FC = () => {
  const auth = useAuth();
  const navigate = useNavigate();
  const contextUserId = auth?.userId;

  //computing default start and end dates
  const today = new Date().toISOString();
  const { firstDay, lastDay } = getMonthBounds(today);

  //State to hold user time input
  const [startDate, setStartDate] = useState(firstDay);
  const [endDate, setEndDate] = useState(lastDay);
  const [cleanStartDate, setCleanStartDate] = useState(firstDay);
  const [cleanEndDate, setCleanEndDate] = useState(lastDay);

  //State to hold data
  const [incomeReport, setIncomeReport] = useState(null);
  const [expenseReport, setExpenseReport] = useState(null);
  const [summaryReport, setSummaryReport] = useState(null);
  const [incomeData, setIncomeData] = useState<RollingSumResult[] | null>(null);
  const [expenseData, setExpenseData] = useState<RollingSumResult[] | null>(
    null,
  );

  useEffect(() => {
    if (!contextUserId) {
      navigate("/login");
    }
  }, [contextUserId, navigate]);

  const fetchIncomeReport = async () => {
    try {
      const response = await fetch(
        `http://localhost:5112/incomeReport/userId=2/startDate=${startDate}/endDate=${endDate}`,
      );
      if (!response.ok) {
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        console.log({incomeReport: data});
        setIncomeReport(data);
        return data;
      }
    } catch (err) {
      console.log(err);
    }
  };

  const fetchExpenseReport = async () => {
    try {
      const response = await fetch(
        `http://localhost:5112/expenseReport/userId=2/startDate=${startDate}/endDate=${endDate}`,
      );
      if (!response.ok) {
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        console.log({expenseReport: data});
        setExpenseReport(data);
        return data;
      }
    } catch (err) {
      console.log(err);
    }
  };

  const fetchSummaryReport = async () => {
    try {
      const response = await fetch(
        `http://localhost:5112/balanceReport/userId=2/startDate=${startDate}/endDate=${endDate}`,
      );
      if (!response.ok) {
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        console.log({summaryReport: data});
        setSummaryReport(data);
        return data;
      }
    } catch (err) {
      console.log(err);
    }
  };

  const fetchIncome = async () => {
    try {
      const response = await fetch(`http://localhost:5112/api/Income/userId=2/startDate=${startDate}/endDate=${endDate}`);
      if (!response.ok) {
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        const transformData = calculateRollingSums(data);
        console.log({incomeData: transformData});
        setIncomeData(transformData);
        return transformData;
      }
    } catch (err) {
      console.log(err);
    }
  };

  const fetchExpense = async () => {
    try {
      const response = await fetch(
        `http://localhost:5112/api/Expense/userId=2/startDate=${startDate}/endDate=${endDate}`,
      );
      if (!response.ok) {
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        const transformData = calculateRollingSums(data);
        console.log({expenseData:transformData});
        setExpenseData(transformData);
        return transformData;
      }
    } catch (err) {
      console.log(err);
    }
  };

  const cleanStart = () => {
    setCleanStartDate(cleanDate(startDate));
  }

  const cleanEnd = () => {
    setCleanEndDate(cleanDate(endDate));
  }
  //Fetch data
  useEffect(() => {
    fetchIncomeReport();
    fetchExpenseReport();
    fetchSummaryReport();
    fetchExpense();
    fetchIncome();
    cleanStart();
    cleanEnd();
  }, [auth?.userId, startDate, endDate]);

  //Clean up date
 
  return (
    <div className="bg-gradient-bluewhite bg-cover bg-center bg-fixed flex flex-col flex-grow w-full min-h-full ">
      <Header />
      <main className="w-10/12 mx-auto flex-grow bg-primary-white mb-8 rounded-md">
        <div className="flex flex-col h-full">
          {/* Top Row */}
          <div className="grid grid-cols-3 min-h-1/2">
            {/* Column 1 - Adjusting layout to accommodate title and chart */}
            <div className="col-span-2 flex flex-col">
              <h1 className="text-3xl font-bold self-start">Your Financial Report From {cleanStartDate} to {cleanEndDate}</h1>{" "}
              {/* Self-aligned to the start */}
              <div className="flex-grow flex justify-center items-center">
                <LineAreaChart
                  incomeData={incomeData}
                  expenseData={expenseData}
                />
              </div>
            </div>
            {/* Column 2 */}
            <div className="col-span-1 bg-gray-300">
              Summary Results
            </div>
          </div>
          {/* Bottom Row */}
          <div className="grid grid-cols-4 min-h-96">
            {/* Column 1 */}
            <div className="bg-gray-200">Income by Category</div>
            {/* Column 2 */}
            <div className="bg-gray-300">Top 3 Income</div>
            {/* Column 3 */}
            <div className="bg-gray-400">Expense by Category</div>
            {/* Column 4 */}
            <div className="bg-gray-500">Top 3 Expenses</div>
          </div>
        </div>
      </main>
      <Footer />
    </div>
  );
};

export default BudgetReportPage;

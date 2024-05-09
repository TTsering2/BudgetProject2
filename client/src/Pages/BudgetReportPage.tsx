import Footer from "@/Components/Footer";
import Header from "@/Components/Header";
import useAuth from "@/Hooks/useAuth";
import { FC, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  FormatDateToCsharp,
  getMonthBounds,
  cleanDate,
} from "@/Functions/timeFunctions";
import {
  calculateRollingSums,
  RollingSumResult,
} from "@/Functions/reportFunctions";
import { LineAreaChart } from "@/Components/BudgetReportComponents/LineAreaChart";
import {
  IncomeReportType,
  ExpenseReportType,
  SummaryReportType,
} from "@/Types/reportType";
import { CustomPieChart } from "@/Components/BudgetReportComponents/CustomPieChart";
import { SummaryReport } from "@/Components/BudgetReportComponents/SummaryReport";
import Top3Items from "@/Components/BudgetReportComponents/Top3Items";
import DateSelectionPopup from "@/Components/BudgetReportComponents/DateSelectionPopup";

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
  const [incomeReport, setIncomeReport] = useState<IncomeReportType | null>(
    null,
  );
  const [expenseReport, setExpenseReport] = useState<ExpenseReportType | null>(
    null,
  );
  const [summaryReport, setSummaryReport] = useState<SummaryReportType | null>(
    null,
  );
  const [incomeData, setIncomeData] = useState<RollingSumResult[] | null>(null);
  const [expenseData, setExpenseData] = useState<RollingSumResult[] | null>(
    null,
  );

  //State to handle open form modal
  const [showPopup, setShowPopup] = useState(false);
  const handleDateSubmit = (start: string, end: string): void => {
    const sanitizedStartDate = new Date(start);
    sanitizedStartDate.setUTCHours(0, 0, 0, 0);
    const sanitizedStartDateString = sanitizedStartDate.toISOString();
    const sanitizedEndDate = new Date(end);
    sanitizedEndDate.setUTCHours(23, 59, 59, 999);
    const sanitizedEndDateString = sanitizedEndDate.toISOString();

    setStartDate(sanitizedStartDateString);
    setEndDate(sanitizedEndDateString);
    setShowPopup(false);
  };
  //handling no userId
  useEffect(() => {
    if (!contextUserId) {
      navigate("/login");
    }
  }, [contextUserId, navigate]);

  //fetching data
  const fetchIncomeReport = async () => {
    try {
      const response = await fetch(
        `http://localhost:5112/incomeReport/userId=2/startDate=${startDate}/endDate=${endDate}`,
      );
      if (!response.ok) {
        setIncomeReport(null);
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        console.log({ incomeReport: data });
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
        setExpenseReport(null);
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        console.log({ expenseReport: data });
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
        setSummaryReport(null);
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        console.log({ summaryReport: data });
        setSummaryReport(data);
        return data;
      }
    } catch (err) {
      console.log(err);
    }
  };

  const fetchIncome = async () => {
    try {
      const response = await fetch(
        `http://localhost:5112/api/Income/userId=2/startDate=${startDate}/endDate=${endDate}`,
      );
      if (!response.ok) {
        setIncomeData(null);
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        console.log({ preTransformincomeData: data });
        const transformData = calculateRollingSums(data);
        console.log({ incomeData: transformData });
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
        setExpenseReport(null);
        throw new Error(response.statusText);
      } else {
        const data = await response.json();
        console.log({ preTransformexpenseData: data });
        const transformData = calculateRollingSums(data);
        console.log({ expenseData: transformData });
        setExpenseData(transformData);
        return transformData;
      }
    } catch (err) {
      console.log(err);
    }
  };

  const cleanStart = () => {
    setCleanStartDate(cleanDate(startDate));
  };

  const cleanEnd = () => {
    setCleanEndDate(cleanDate(endDate));
  };
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

  return (
    <div className="bg-gradient-bluewhite bg-cover bg-center bg-fixed rounded-lg flex flex-col flex-grow w-full min-h-full">
      <Header />
      <main className="w-10/12 mx-auto flex-grow bg-primary-white mb-8 rounded-md">
        <div className="flex flex-col h-full">
          <div className="flex justify-between items-center">
            <h1 className="text-3xl font-bold self-start pt-4 pl-4">
              Your Financial Report From {cleanStartDate} to {cleanEndDate}
            </h1>
            {/* Button to Open Modal */}
            <button
              onClick={() => setShowPopup(true)}
              className="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600 self-end m-4"
            >
              Select Dates
            </button>
            {/* Date Selection Modal */}
            <DateSelectionPopup
              isOpen={showPopup}
              onClose={() => setShowPopup(false)}
              onSubmit={handleDateSubmit}
            />
          </div>

          {/* Top Row */}
          <div className="grid grid-cols-7 min-h-1/2">
            <div className="col-span-5 flex flex-col">
              <div className="flex-grow flex justify-center items-center">
                <LineAreaChart
                  incomeData={incomeData}
                  expenseData={expenseData}
                />
              </div>
            </div>
            <div className="col-span-2 flex justify-center items-center">
              <SummaryReport summaryReport={summaryReport} />
            </div>
          </div>
          {/* Bottom Row */}
          <div className="grid grid-cols-4 min-h-96">
            {incomeReport && incomeReport.incomeByCategory && (
              <CustomPieChart
                report={incomeReport}
                type="income"
                title="Income By Category"
              />
            )}

            {incomeReport && incomeReport.top3Incomes && (
              <Top3Items
                items={incomeReport.top3Incomes}
                title="Top 3 Incomes"
              />
            )}
            {expenseReport && expenseReport.expensesByCategory && (
              <CustomPieChart
                report={expenseReport}
                type="expense"
                title="Expenses By Category"
              />
            )}

            {expenseReport && expenseReport.top3Expenses && (
              <Top3Items
                items={expenseReport.top3Expenses}
                title="Top 3 Expenses"
                isExpense={true}
              />
            )}
          </div>
        </div>
      </main>
      <Footer />
    </div>
  );
};

export default BudgetReportPage;

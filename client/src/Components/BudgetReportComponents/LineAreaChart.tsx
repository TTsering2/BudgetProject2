import React from "react";
import {
  AreaChart,
  Area,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
} from "recharts";
import {
  RollingSumResult,
  zipIncomeExpenseData,
} from "@/Functions/reportFunctions";
import { NoDataFound } from "./NoDataFound";

interface LineAreaChartProps {
  incomeData: RollingSumResult[] | null;
  expenseData: RollingSumResult[] | null;
}

export const LineAreaChart: React.FC<LineAreaChartProps> = ({
  incomeData,
  expenseData,
}) => {
  if (
    !incomeData ||
    incomeData.length === 0 ||
    !expenseData ||
    expenseData.length === 0
  ) {
    return <NoDataFound />;
  }

  const data = zipIncomeExpenseData(incomeData, expenseData);
  console.log("Zipped data:", data);
  console.log(data);
  return (
    <ResponsiveContainer width="80%" height="80%">
      <AreaChart
        data={data}
        margin={{ top: 20, right: 30, left: 20, bottom: 20 }}
      >
        <CartesianGrid strokeDasharray="2 2" />
        <XAxis
          dataKey="date"
          label={{ value: "Date", position: "insideBottom", offset: 0 }} // Adjusted offset
        />
        <YAxis
          label={{
            value: "Amount ($)",
            angle: -90,
            position: "insideLeft",
            dx: -10,
          }} // Adjusted dx for positioning
        />
        <Tooltip />
        <Area
          type="monotone"
          dataKey="incomeAmount"
          stackId="1"
          stroke="#68c182"
          fill="#68c182"
          name="Income"
        />
        <Area
          type="monotone"
          dataKey="expenseAmount"
          stackId="2"
          stroke="#d86060"
          fill="#d86060"
          name="Expenses"
        />
      </AreaChart>
    </ResponsiveContainer>
  );
};

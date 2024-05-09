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

interface LineAreaChartProps {
  incomeData: RollingSumResult[] | null;
  expenseData: RollingSumResult[] | null;
}

export const LineAreaChart: React.FC<LineAreaChartProps> = ({
  incomeData,
  expenseData,
}) => {
  if (incomeData === null || expenseData === null) {
    return <div>Loading...</div>;
  }

  const data = zipIncomeExpenseData(incomeData, expenseData);
  return (
    <ResponsiveContainer width="80%" height="80%">
      <AreaChart
        data={data}
        margin={{ top: 20, right: 30, left: 20, bottom: 20 }}
      >
        <CartesianGrid strokeDasharray="3 3" />
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
          stackId="1"
          stroke="#d86060"
          fill="#d86060"
          name="Expenses"
        />
      </AreaChart>
    </ResponsiveContainer>
  );
};

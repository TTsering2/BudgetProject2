import React from "react";
import {
  PieChart,
  Pie,
  Cell,
  Tooltip,
  Legend,
  ResponsiveContainer,
} from "recharts";
import { IncomeReportType, ExpenseReportType } from "@/Types/reportType";
import { NoDataFound } from "./NoDataFound";

interface PieChartProps {
  report: IncomeReportType | ExpenseReportType | null;
  type: "income" | "expense";
  title?: string;
}

const COLORS = [
  "#0088FE",
  "#00C49F",
  "#FFBB28",
  "#FF8042",
  "#8884d8",
  "#A83279",
  "#D4E157",
  "#7B1FA2",
  "#D32F2F",
  "#1976D2",
  "#0097A7",
  "#E64A19",
  "#FBC02D",
  "#7C4DFF",
  "#388E3C",
];

export const CustomPieChart: React.FC<PieChartProps> = ({ report, type }) => {
  if (report === null) {
    return (
      <div className="w-full h-full bg-white shadow-lg p-4">
        <h3 className="text-center font-lato font-bold text-lg pt-4">
          {type === "income" ? "Income by Category" : "Expenses by Category"}
        </h3>
        <NoDataFound />
      </div>
    );
  }
  let data;
  if (type === "income") {
    data = (report as IncomeReportType).incomeByCategory;
  } else {
    data = (report as ExpenseReportType).expensesByCategory;
  }
  const transformedData = Object.keys(data).map((key) => ({
    name: key,
    value: data[key],
  }));

  const totalAmount = transformedData.reduce(
    (acc, curr) => acc + curr.value,
    0,
  );

  return (
    <div className="w-full h-full bg-white shadow-lg p-4">
      <h3 className="text-center font-lato font-bold text-lg">
        {type === "income" ? "Income by Category" : "Expenses by Category"}
      </h3>
      <div style={{ width: "80%", height: "80%" }}>
        <ResponsiveContainer>
          <PieChart>
            <Pie
              data={transformedData}
              cx="50%"
              cy="50%"
              label={false}
              outerRadius="70%"
              fill="#8884d8"
              dataKey="value"
            >
              {transformedData.map((entry, index) => (
                <Cell
                  key={`cell-${index}`}
                  fill={COLORS[index % COLORS.length]}
                />
              ))}
            </Pie>
            <Tooltip
              formatter={(value, name, props) => [
                `${value.toLocaleString()} (${((value / totalAmount) * 100).toFixed(2)}%)`,
                name,
              ]}
            />
            <Legend align="center" verticalAlign="top" layout="horizontal" />
          </PieChart>
        </ResponsiveContainer>
      </div>
    </div>
  );
};

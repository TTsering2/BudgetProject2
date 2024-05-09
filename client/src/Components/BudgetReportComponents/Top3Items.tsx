import React from "react";
import { IncomeExpenseEntry } from "@/Types/reportType";
import { NoDataFound } from "./NoDataFound";

interface Top3ItemsProps {
  items: IncomeExpenseEntry[];
  title: string;
  isExpense?: boolean; // Optional prop to differentiate display for expenses
}

const Top3Items: React.FC<Top3ItemsProps> = ({
  items,
  title,
  isExpense = false,
}) => {
  if (items.length === 0) {
    return (
      <div className="w-full h-full bg-white shadow-lg p-4">
        <h3 className="font-bold text-lg text-center mb-4">{title}</h3>
        <NoDataFound />
      </div>
    );
  }
  return (
    <div className="w-full h-full bg-white shadow-lg p-4">
      <h3 className="font-bold text-lg text-center mb-4">{title}</h3>
      <ul className="list-disc space-y-2 pl-6">
        {items.map((item) => (
          <li key={item.title} className="text-gray-700">
            {item.title} :{" "}
            {isExpense
              ? `-$${item.amount.toLocaleString()}`
              : `$${item.amount.toLocaleString()}`}{" "}
            on {new Date(item.date).toLocaleDateString()}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Top3Items;

import React from "react";
import { SummaryReportType } from "@/Types/reportType";
import { NoDataFound } from "./NoDataFound";
interface SummaryReportPagePropType {
  summaryReport: SummaryReportType | null;
}

export const SummaryReport: React.FC<SummaryReportPagePropType> = ({
  summaryReport,
}) => {
  if (!summaryReport || !summaryReport.totalIncome) {
    return (
      <div className="bg-white shadow-xl rounded-lg p-6 w-3/4 mx-auto my-8 font-lato">
        <h2 className="text-2xl font-bold text-center text-blue-600 border-b-2 border-blue-300 pb-4 mb-4">
          Summary Report
        </h2>
        <NoDataFound />
      </div>
    );
  }

  return (
    <div className="bg-white shadow-xl rounded-lg p-6 w-3/4 mx-auto my-8 font-lato">
      <h2 className="text-2xl font-bold text-center text-blue-600 border-b-2 border-blue-300 pb-4 mb-4">
        Summary Report
      </h2>
      <div className="space-y-3">
        <p className="text-gray-800">
          Total Income:{" "}
          <span className="text-green-600 font-semibold">
            $
            {summaryReport
              ? summaryReport.totalIncome.toLocaleString()
              : "Loading..."}
          </span>
        </p>
        <p className="text-gray-800">
          Total Expense:{" "}
          <span className="text-red-600 font-semibold">
            $
            {summaryReport
              ? summaryReport.totalExpense.toLocaleString()
              : "Loading..."}
          </span>
        </p>
        <p className="text-gray-800">
          Net Value:{" "}
          <span className="text-blue-500 font-semibold">
            $
            {summaryReport
              ? summaryReport.netValue.toLocaleString()
              : "Loading..."}
          </span>
        </p>
      </div>
    </div>
  );
};

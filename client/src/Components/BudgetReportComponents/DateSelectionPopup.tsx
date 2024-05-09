import React, { useState } from "react";
import { FormatDateToCsharp } from "@/Functions/timeFunctions";
// Define the props for the component using an interface
interface DateSelectionPopupProps {
  isOpen: boolean;
  onClose: () => void;
  onSubmit: (startDate: string, endDate: string) => void;
}

const DateSelectionPopup: React.FC<DateSelectionPopupProps> = ({
  isOpen,
  onClose,
  onSubmit,
}) => {
  const [startDate, setStartDate] = useState<string>("");
  const [endDate, setEndDate] = useState<string>("");

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>): void => {
    event.preventDefault();
    // Check that dates are entered and start date is before or equal to end date
    if (startDate && endDate && new Date(startDate) <= new Date(endDate)) {
      // Convert string dates to Date objects and then to ISO strings
      const sanitizedStartDate = new Date(startDate).toISOString();
      const sanitizedEndDate = new Date(endDate).toISOString();
      onSubmit(sanitizedStartDate, sanitizedEndDate);
      onClose(); // Close the popup after submitting
    } else {
      alert("Please ensure the start date is before the end date.");
    }
  };

  if (!isOpen) return null;

  return (
    <div className="fixed inset-0 bg-gray-600 bg-opacity-75 flex justify-center items-center z-50">
      <div className="bg-white rounded-lg p-5 shadow-xl">
        <h2 className="text-xl font-semibold text-center mb-4">
          Select Report Dates
        </h2>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label
              htmlFor="startDate"
              className="block text-sm font-medium text-gray-700"
            >
              Start Date
            </label>
            <input
              type="date"
              id="startDate"
              value={startDate}
              onChange={(e) => setStartDate(e.target.value)}
              className="mt-1 block w-full border-gray-300 shadow-sm sm:text-sm rounded-md"
              required
            />
          </div>
          <div>
            <label
              htmlFor="endDate"
              className="block text-sm font-medium text-gray-700"
            >
              End Date
            </label>
            <input
              type="date"
              id="endDate"
              value={endDate}
              onChange={(e) => setEndDate(e.target.value)}
              className="mt-1 block w-full border-gray-300 shadow-sm sm:text-sm rounded-md"
              required
            />
          </div>
          <div className="flex justify-end space-x-4">
            <button
              type="button"
              onClick={onClose}
              className="bg-gray-500 hover:bg-gray-600 text-white font-bold py-2 px-4 rounded"
            >
              Cancel
            </button>
            <button
              type="submit"
              className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 rounded"
            >
              Submit
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default DateSelectionPopup;

export interface IncomeExpenseType {
  amount: number;
  date: string;
  id: number;
  title: string;
  type: string;
}

export interface RollingSumResult {
  date: string;
  amount: number;
}

export function calculateRollingSums(
  data: IncomeExpenseType[],
) : RollingSumResult[] {
  // Sort the data by date in ascending order
  data.sort((a, b) => new Date(a.date).getTime() - new Date(b.date).getTime());

  let rollingSum = 0;
  let result: RollingSumResult[] = [];

  data.forEach((item) => {
    rollingSum += item.amount; // Update rolling sum with current item's amount
    let formattedDate = formatDate(item.date); // Format the date to "month-day-year"
    let entry: RollingSumResult = {
      date: formattedDate,
      amount: rollingSum, // Set the cumulative amount
    };
    result.push(entry); // Add the new object to the result array
  });

  return result;
}

// Helper function to format a date string to "MM-DD-YYYY"
function formatDate(dateStr: string): string {
  const date = new Date(dateStr);
  const month = date.getMonth() + 1; // getMonth() is zero-indexed
  const day = date.getDate();
  const year = date.getFullYear();
  return `${pad(month)}-${pad(day)}-${year}`;
}

// Helper function to add leading zero if necessary
function pad(number: number): string {
  return number < 10 ? `0${number}` : `${number}`;
}

export interface CombinedData {
  date: string;
  incomeAmount: number;
  expenseAmount: number;
}

export function zipIncomeExpenseData(
  incomeData: RollingSumResult[],
  expenseData: RollingSumResult[],
): CombinedData[] {
  // Create a map to hold the combined data
  const combinedMap: Record<string, CombinedData> = {};

  // Initialize variables to track the last known amounts
  let lastIncomeAmount = 0;
  let lastExpenseAmount = 0;

  // Populate the map with expense data and update last known amounts
  for (const expense of expenseData) {
    if (!combinedMap[expense.date]) {
      combinedMap[expense.date] = {
        date: expense.date,
        incomeAmount: lastIncomeAmount,
        expenseAmount: expense.amount,
      };
    } else {
      combinedMap[expense.date].expenseAmount += expense.amount;
    }
    lastExpenseAmount = combinedMap[expense.date].expenseAmount; // Update last known expense amount
  }

  // Add income data to the map and update last known amounts
  for (const income of incomeData) {
    if (!combinedMap[income.date]) {
      combinedMap[income.date] = {
        date: income.date,
        incomeAmount: income.amount,
        expenseAmount: lastExpenseAmount,
      };
    } else {
      combinedMap[income.date].incomeAmount += income.amount;
    }
    lastIncomeAmount = combinedMap[income.date].incomeAmount; // Update last known income amount
  }

  // Convert the map to an array
  const combinedDataArray: CombinedData[] = Object.values(combinedMap);

  // Sort by date if necessary
  combinedDataArray.sort(
    (a, b) => new Date(a.date).getTime() - new Date(b.date).getTime(),
  );

  return combinedDataArray;
}
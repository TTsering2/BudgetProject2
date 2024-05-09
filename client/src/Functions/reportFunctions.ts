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
): RollingSumResult[] {
  // Sort the data by date in ascending order
  data.sort((a, b) => new Date(a.date).getTime() - new Date(b.date).getTime());

  let rollingSum = 0;
  const result: RollingSumResult[] = [];

  data.forEach((item) => {
    rollingSum += item.amount; // Update rolling sum with current item's amount
    const formattedDate = formatDate(item.date); // Format the date to "month-day-year"
    const entry: RollingSumResult = {
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

  // Populate the map with expense data, only updating if the new amount is larger
  for (const expense of expenseData) {
    if (!combinedMap[expense.date]) {
      combinedMap[expense.date] = {
        date: expense.date,
        incomeAmount: 0, // Initialize to 0 until an income entry updates it
        expenseAmount: expense.amount,
      };
    } else if (expense.amount > combinedMap[expense.date].expenseAmount) {
      combinedMap[expense.date].expenseAmount = expense.amount;
    }
  }

  // Add income data to the map, only updating if the new amount is larger
  for (const income of incomeData) {
    if (!combinedMap[income.date]) {
      combinedMap[income.date] = {
        date: income.date,
        incomeAmount: income.amount,
        expenseAmount: 0, // Initialize to 0 if no prior expense data for this date
      };
    } else if (income.amount > combinedMap[income.date].incomeAmount) {
      combinedMap[income.date].incomeAmount = income.amount;
    }
  }
  
  // Convert the map to an array
  const combinedDataArray: CombinedData[] = Object.values(combinedMap);

  // Sort by date
  combinedDataArray.sort(
    (a, b) => new Date(a.date).getTime() - new Date(b.date).getTime(),
  );
    for (let i = 1; i < combinedDataArray.length; i++) {
      if (combinedDataArray[i].incomeAmount === 0) {
        combinedDataArray[i].incomeAmount =
          combinedDataArray[i - 1].incomeAmount;
      }
      if (combinedDataArray[i].expenseAmount === 0) {
        combinedDataArray[i].expenseAmount =
          combinedDataArray[i - 1].expenseAmount;
      }
    }

  return combinedDataArray;
}

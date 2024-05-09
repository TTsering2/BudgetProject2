// Define the type for each item in the data array
export interface IncomeExpenseType {
  amount: number;
  date: string;
  id: number;
  title: string;
  type: string;
}

// Define the type for the return object where the date is the key and the value is the number (rolling amount)
export interface RollingSumResult {
  [date: string]: number;
}

export function calculateRollingSums(data: IncomeExpenseType[]): RollingSumResult[] {
  // Sort the data by date in ascending order
  data.sort((a, b) => new Date(a.date).getTime() - new Date(b.date).getTime());

  let rollingSum = 0;
  let result: RollingSumResult[] = [];

  data.forEach((item) => {
    rollingSum += item.amount; // Update rolling sum with current item's amount
    let entry: RollingSumResult = {}; // Create a new object for each date
    entry[item.date] = rollingSum; // Set the date as key and rolling sum as value
    result.push(entry); // Add the new object to the result array
  });

  return result;
}


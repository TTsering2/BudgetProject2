// Define a type for individual income entries in top incomes
export interface IncomeExpenseEntry {
  id: number;
  title: string;
  type: string;
  amount: number;
  date: string;
}

// Define a type for the income breakdown by category
export interface IncomeExpenseByCategory {
  [category: string]: number; // Key-value pairs of category and amount
}

// Define the main type for the IncomeReport
export interface IncomeReportType {
  endDate: string;
  incomeByCategory: IncomeExpenseByCategory;
  startDate: string;
  top3Incomes: IncomeExpenseEntry[];
}
export interface ExpenseReportType {
  endDate: string;
  expensesByCategory: IncomeExpenseByCategory;
  startDate: string;
  top3Expenses: IncomeExpenseEntry[];
}

export interface SummaryReportType {
  startDate: string;
  endDate: string;
  totalIncome: number;
  totalExpense: number;
  netValue: number;
}

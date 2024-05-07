import useAuth from "@/Hooks/useAuth";
import AuthContext from "@/Hooks/AuthContext";
import { FC, useEffect, useState } from "react";
import { error } from "console";
import Stock from "@/Components/Stock";
import AddStock from "@/Components/HandleAddStock";

export type Stock = {
  id: number;
  companyName: string;
  tickerSymbol: string;
  userId: number;
  price: number;
  quantity: number;
  date: Date;
};

const StockPage: FC = () => {
  const auth = useAuth();
  const [stocks, setStocks] = useState<Stock[]>([]);

  //fetch the stocks when the component mounts
  useEffect(() => {
    fetchStocks();
  }, []);

  async function fetchStocks() {
    if (auth) {
      // Check if auth is not null
      try {
        const response = await fetch(
          `http://localhost:5112/api/Stock/user/${auth.userId}`,
        );

        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data = await response.json();
        setStocks(data);
      } catch (error) {
        console.error("Failed to fetch stocks:", error);
      }
    }
  }

  async function handleAddStock() {}

  function handleDeletetock() {}

  function handleUpdateStock() {}

  return (
    <div>
      <AddStock setStocks={setStocks} />
      {stocks.map((stock, index) => (
        <div key={stock.id}>
          {/* Display the stock information */}

          <Stock
            key={index}
            stock={{ ...stock, date: new Date(stock.date).toISOString() }}
          />
        </div>
      ))}
    </div>
  );
};

export default StockPage;

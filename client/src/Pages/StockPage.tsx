import useAuth from "@/Hooks/useAuth";
import AuthContext from "@/Hooks/AuthContext";
import { FC, useEffect, useState } from "react";
import { error } from "console";
import Stock from "@/Components/Stock";
import AddStock from "@/Components/HandleAddStock";
import Footer from "@/Components/Footer";

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
          `http://localhost:5112/api/Stock/user/${3}`,
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
    <div className="bg-[url('/assets/bg.png')] bg-cover bg-center min-h-screen">
      <div className="mb-4">
        <AddStock
          setStocks={setStocks}
          className="bg-blue-500 text-white px-4 py-2 rounded shadow hover:bg-blue-600"
        />
        <section className="flex flex-col items-center justify-between text-center w-full m-auto pb-14 ">
          {stocks.map((stock, index) => (
            <div
              key={stock.id}
              className="w-70% bg-white shadow p-4 mb-4 rounded-lg max-w-full mx-auto"
            >
              {/* Display the stock information */}

              <Stock
                key={index}
                stock={{ ...stock, date: new Date(stock.date).toISOString() }}
              />
            </div>
          ))}
        </section>
      </div>
      <Footer></Footer>
    </div>
  );
};

export default StockPage;

import useAuth from "@/Hooks/useAuth";
import { FC, useEffect, useState } from "react";
import Stock from "@/Components/Stock";
import AddStock from "@/Components/HandleAddStock";
import Footer from "@/Components/Footer";
import Header from "@/Components/Header";
import Swal from "sweetalert2";

export type Stock = {
  id: number;
  companyName: string;
  tickerSymbol: string;
  userId: number;
  price: number;
  quantity: number;
  date: Date | null;
};

// type StockProps = {
//   stock: Stock;
//   onStockDeleted: (id: number) => void;
// };

const StockPage: FC = () => {
  const auth = useAuth();
  const userId = auth?.userId;
  const [stocks, setStocks] = useState<Stock[]>([]);
  const [stockId, setStockId] = useState("");
  // const [stock, setStock] = useState<Stock | null>(null);

  //fetch the stocks when the component mounts
  useEffect(() => {
    fetchStocks();
  }, []);

  async function fetchStocks() {
    if (auth) {
      // Check if auth is not null
      try {
        const response = await fetch(
          `http://localhost:5112/api/Stock/user/${userId}`,
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

  async function fetchStockById() {
    if (auth && stockId) {
      try {
        const response = await fetch(
          `http://localhost:5112/api/Stock/${stockId}`,
        );

        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data = await response.json();

        setStocks([data]);
      } catch (error) {
        console.error("Failed to fetch stock:", error);
        Swal.fire({
          icon: "error",
          title: "Oops...",
          text: "Invalid ID! No stock found with the provided ID.",
        });
      }
    }
  }

  return (
    <div className="bg-gradient-bluewhite flex flex-col min-h-screen">
      <Header />

      <div className="flex-grow mb-4 font-roboto leading-loose tracking-wide">
        <div className="flex justify-center space-x-4 ">
          <AddStock
            setStocks={setStocks}
            className="bg-blue-500 text-white px-4 py-2 rounded shadow hover:bg-blue-600"
          />
          <input
            type="text"
            value={stockId}
            onChange={(e) => setStockId(e.target.value)}
            placeholder="Enter Stock ID"
            className="text-sm- rounded-lg h-9 w-23 text-center mx-auto mt-6 transform hover:scale-110 transition-all duration-200 drop-shadow-lg"
            onClick={fetchStockById}
          />
        </div>
        <button
          className="flex justify-center mx-auto bg-transparent text-white hover:bg-bg-primary-green-blue text-lg transform hover:scale-110 transition-all duration-200 drop-shadow-lg"
          onClick={fetchStockById}
        >
          Find a Stock
        </button>
        {/* //display the stock requested */}
        <section className="flex flex-col items-center justify-between text-center w-full m-auto pb-14 ">
          {stocks.map((stock, index) => (
            <div
              key={index}
              className="flex flex-row justify-between w-11/12 my-5"
            >
              {/* Display the stock information */}

              <Stock
                key={index}
                stock={{
                  ...stock,
                  ...stock,
                  date:
                    stock.date && !isNaN(new Date(stock.date).getTime())
                      ? new Date(stock.date).toISOString()
                      : new Date().toISOString(),
                }}
              />
            </div>
          ))}
        </section>
      </div>
      <footer className="mt-auto">
        <Footer></Footer>
      </footer>
    </div>
  );
};

export default StockPage;

import { useState } from "react";
import StockPage from "./HandleAddStock";
import { FaCaretDown, FaCaretUp } from "react-icons/fa";
import Swal from "sweetalert2";
import HandleUpdateStock from "./HandleUpdateStock";

type StockProps = {
  stock: {
    id: number;
    companyName: string;
    tickerSymbol: string;
    price: number;
    quantity: number;
    date: string;
    userId: number;
  };
};

const Stock: React.FC<StockProps> = ({ stock }) => {
  const [showDetails, setShowDetails] = useState(false);
  const [stocks, setStocks] = useState<StockProps["stock"][]>([]);
  // const [stock, setStock] = useState<StockProps["stock"] | null>(null);

  const handleDelete = async () => {
    console.log("Deleting stock:", stock.id);
    try {
      const response = await fetch(
        `http://localhost:5112/api/Stock/${stock.id}`,
        {
          method: "DELETE",
        },
      );

      if (!response.ok) {
        throw new Error("Error deleting stock");

        // setStocks((prevStocks) =>
        //   prevStocks.filter((stock) => stock.id !== id),
        // );
      }
      Swal.fire({
        title: "Success!",
        text: "Stock deleted successfully",
        icon: "success",
        confirmButtonText: "OK",
      });

      // Handle successful deletion (e.g., remove the deleted stock from the local state)
    } catch (error) {
      console.error("Failed to delete stock:", error);
    }
  };

  return (
    <div className="w-3/5 bg-white shadow-lg p-10 mb-6 rounded-lg mx-auto">
      <div className="m-auto shadow-gray-100 py-2 border-b-2 border-primary-green-blue">
        <div className="flex justify-between items-center">
          {/* <div onClick={() => setShowDetails(!showDetails)}> */}
          <div className="flex justify-between w-full">
            <p className="p-1 font-semibold">{stock.tickerSymbol}</p>

            <p className="text-2x font-semibold">$ {stock.price} </p>
          </div>
          <button
            onClick={() => setShowDetails(!showDetails)}
            className="focus:outline-none hover:text-blue-500 transition-colors"
            aria-expanded={showDetails}
          >
            {showDetails ? <FaCaretUp /> : <FaCaretDown />}
          </button>
        </div>
      </div>
      {showDetails && (
        <div className="mt-4 font-Lato">
          <h3 className="text-2xl font-semibold w-11/12 pl-4">
            {stock.companyName}
          </h3>
          <div
            className="mt-6 mb-6 flex justify-between w-11/12 pl-4
          bg-white shadow-l rounded-xl opacity-50 ml-4"
          >
            <p>Quantity: {stock.quantity}</p>
            <p>Total: ${stock.price * stock.quantity} </p>
            <p className="mb-4">
              {new Date(stock.date).toLocaleDateString("en-US", {
                year: "numeric",
                month: "2-digit",
                day: "2-digit",
              })}
            </p>
          </div>
          <div className="flex justify-center space-x-4">
            <button
              onClick={handleDelete}
              className="bg-primary-white text-primary-dark-blue border border-primary-green-blue hover:bg-primary-dark-blue hover:text-white rounded-lg h-10 w-40 drop-shadow-lg"
            >
              Delete
            </button>
            <HandleUpdateStock setStocks={setStocks} stock={stock} />
          </div>
        </div>
      )}
    </div>
  );
};
export default Stock;

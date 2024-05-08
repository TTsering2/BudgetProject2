import { useState } from "react";
import StockPage from "./HandleAddStock";
import { FaCaretDown, FaCaretUp } from "react-icons/fa";

type StockProps = {
  stock: {
    id: number;
    companyName: string;
    tickerSymbol: string;
    price: number;
    quantity: number;
    date: string;
    userId: number;
    // onDelete: (id: number) => void;
  };
};

const Stock: React.FC<StockProps> = ({ stock }) => {
  const [showDetails, setShowDetails] = useState(false);
  const [message, setMessage] = useState("");

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
        setMessage("Stock deleted successfully");
      }

      // Handle successful deletion (e.g., remove the deleted stock from the local state)
    } catch (error) {
      console.error("Failed to delete stock:", error);
    }
  };

  const handleUpdate = () => {
    // Update stock
  };

  return (
    <div className="w-3/4 bg-white shadow-lg p-10 mb-6 rounded-lg mx-auto">
      {message && (
        <p className="bg-[#FFFFFF] font-bold w-[1350px] m-auto p-6 px-10 rounded mt-6 pb-20">
          {message}
        </p>
      )}
      <div className="flex justify-between items-center">
        {/* <div onClick={() => setShowDetails(!showDetails)}> */}
        <div className="flex justify-between w-full">
          <p className="p-1 font-semibold">{stock.tickerSymbol}</p>

          <p className="text-2x font-semibold">{stock.price} $ </p>
        </div>
        <button
          onClick={() => setShowDetails(!showDetails)}
          className="focus:outline-none hover:text-blue-500 transition-colors"
          aria-expanded={showDetails}
        >
          {showDetails ? <FaCaretUp /> : <FaCaretDown />}
        </button>
      </div>

      {showDetails && (
        <div className="mt-4 font-lato">
          <h3 className="text-2xl font-semibold w-11/12">
            Company Name: {stock.companyName}
          </h3>

          <p>Quantity: {stock.quantity}</p>
          <p>Total: {stock.price * stock.quantity} $</p>
          <p>Date: {new Date(stock.date).toLocaleDateString()}</p>
          <button
            onClick={handleDelete}
            className="bg-primary-white text-primary-dark-blue border border-primary-green-blue hover:bg-primary-dark-blue hover:text-white px-2 py-1 rounded mr-2"
          >
            Delete
          </button>
          <button
            onClick={handleUpdate}
            className="bg-primary-green-blue text-white px-2 py-1 rounded hover:bg-primary-dark-blue"
          >
            Update
          </button>
        </div>
      )}
    </div>
  );
};
export default Stock;

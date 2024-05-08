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
  };
};

const Stock: React.FC<StockProps> = ({ stock }) => {
  const [showDetails, setShowDetails] = useState(false);

  const handleDelete = () => {
    // Delete stock
  };

  const handleUpdate = () => {
    // Update stock
  };

  return (
    <div className="bg-white shadow p-4 mb-4 rounded relative">
      <div className="flex justify-between items-center">
        {/* <div onClick={() => setShowDetails(!showDetails)}> */}
        <p className="font-bold">{stock.tickerSymbol}</p>
        <button
          onClick={() => setShowDetails(!showDetails)}
          className="focus:outline-none hover:text-blue-500 transition-colors"
          aria-expanded={showDetails}
        >
          {showDetails ? <FaCaretUp /> : <FaCaretDown />}
        </button>
      </div>

      <p>Price: {stock.price}</p>

      {showDetails && (
        <div className="mt-4">
          <p>Company Name: {stock.companyName}</p>
          <p>Date: {new Date(stock.date).toLocaleDateString()}</p>
          <p>Quantity: {stock.quantity}</p>
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

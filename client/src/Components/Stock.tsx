import { useState } from "react";
import StockPage from "./HandleAddStock";

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
    <div onClick={() => setShowDetails(!showDetails)}>
      <p>{stock.tickerSymbol}</p>
      <p>Price: {stock.price}</p>
      {showDetails && (
        <>
          <p>Company Name: {stock.companyName}</p>
          <p>Date: {new Date(stock.date).toLocaleDateString()}</p>
          <p>Quantity: {stock.quantity}</p>
          <button onClick={handleDelete}>Delete</button>
          <button onClick={handleUpdate}>Update</button>
        </>
      )}
    </div>
  );
};
export default Stock;

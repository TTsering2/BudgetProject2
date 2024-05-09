import { useState } from "react";
import Modal from "react-modal";
import { Stock } from "@/Pages/StockPage";

type AddStockProps = {
  setStocks: React.Dispatch<React.SetStateAction<Stock[]>>;
  className?: string;
};

const AddStock: React.FC<AddStockProps> = ({ setStocks }) => {
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [newStock, setNewStock] = useState({
    companyName: "",
    tickerSymbol: "",
    price: 0,
    quantity: 0,
    date: new Date().toISOString(),
    userId: 2,
    // userId: auth ? auth.userId : null, // Check if auth is not null before accessing auth.userId
  });

  const handleAddStock = async () => {
    try {
      const response = await fetch("http://localhost:5112/api/Stock", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(newStock),
      });

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.json();

      setStocks((prevStocks) => [...prevStocks, data]);
      setModalIsOpen(false);
      console.log("Stock added successfully:", data);
    } catch (error) {
      console.error("Failed to add stock:", error);
    }
  };

  // ...

  return (
    <div className="flex justify-center my-6">
      <button
        className="
       bg-primary-green-blue text-white rounded-lg h-10 w-40 drop-shadow-lg hover:bg-primary-dark-blue hover:scale-105 transform transition-all ease-in-out duration-200"
        onClick={() => setModalIsOpen(true)}
      >
        Add Stock
      </button>

      <Modal isOpen={modalIsOpen} onRequestClose={() => setModalIsOpen(false)}>
        <form
          onSubmit={(e) => {
            e.preventDefault();
            handleAddStock();
          }}
        >
          <label>
            Company Name:
            <input
              type="text"
              value={newStock.companyName}
              onChange={(e) =>
                setNewStock((prevStock) => ({
                  ...prevStock,
                  companyName: e.target.value,
                }))
              }
            />
          </label>
          <label>
            Ticker Symbol:
            <input
              type="text"
              value={newStock.tickerSymbol}
              onChange={(e) =>
                setNewStock((prevStock) => ({
                  ...prevStock,
                  tickerSymbol: e.target.value,
                }))
              }
            />
          </label>
          <label>
            Price:
            <input
              type="number"
              value={newStock.price}
              onChange={(e) =>
                setNewStock((prevStock) => ({
                  ...prevStock,
                  price: Number(e.target.value),
                }))
              }
            />
          </label>
          <label>
            Quantity:
            <input
              type="number"
              value={newStock.quantity}
              onChange={(e) =>
                setNewStock((prevStock) => ({
                  ...prevStock,
                  quantity: Number(e.target.value),
                }))
              }
            />
          </label>
          <button type="submit">Add Stock</button>
        </form>
      </Modal>
    </div>
  );
};

export default AddStock;

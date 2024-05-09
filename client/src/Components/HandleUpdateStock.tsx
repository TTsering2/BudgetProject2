import React, { useState } from "react";
import Modal from "react-modal";
import Swal from "sweetalert2";

type UpdateStockProps = {
  setStocks: React.Dispatch<React.SetStateAction<any[]>>;
  stock: any;
};

Modal.setAppElement("#root");

function HandleUpdateStock({ setStocks, stock }: UpdateStockProps) {
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [companyName, setCompanyName] = useState(stock.companyName);
  const [tickerSymbol, setTickerSymbol] = useState(stock.tickerSymbol);
  const [price, setPrice] = useState(stock.price);
  const [quantity, setQuantity] = useState(stock.quantity);
  const [date, setDate] = useState(stock.date);

  const handleOpenModal = () => {
    setModalIsOpen(true);
  };

  const handleCloseModal = () => {
    setModalIsOpen(false);
  };

  const handleUpdateStock = async (
    updatedStock: Partial<{
      companyName: string;
      tickerSymbol: string;
      price: number;
      quantity: number;
      date: string;
    }>,
  ) => {
    try {
      const response = await fetch(
        `http://localhost:5112/api/Stock/${stock.id}`,
        {
          method: "PATCH",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(updatedStock),
        },
      );

      if (!response.ok) {
        throw new Error("Error updating stock");
      }

      Swal.fire({
        title: "Success!",
        text: "Stock updated successfully",
        icon: "success",
        confirmButtonText: "OK",
      });

      // Handle successful update (e.g., update the local state with the updated stock)
      setStocks((prevStocks) =>
        prevStocks.map((s) => (s.id === stock.id ? updatedStock : s)),
      );
      handleCloseModal();
    } catch (error) {
      console.error("Failed to update stock:", error);
    }
  };

  return (
    <div>
      <button
        className="bg-primary-green-blue text-white rounded-lg h-10 w-40 drop-shadow-lg 
              hover:bg-primary-dark-blue"
        onClick={handleOpenModal}
      >
        Update Stock
      </button>
      <Modal
        isOpen={modalIsOpen}
        onRequestClose={handleCloseModal}
        contentLabel="Update Stock"
      >
        <h2 className="Lato flex justify-center text-2xl font-semibold mt-10">
          Updating Stock
        </h2>
        <form
          className="flex-center"
          onSubmit={(e) => {
            e.preventDefault();
            handleUpdateStock({
              companyName,
              tickerSymbol,
              price,
              quantity,
              date,
            });
          }}
          style={{ margin: "40px", padding: "20px" }}
        >
          <div className="flex justify-between">
            <label htmlFor="companyName">Company Name</label>
            <input
              type="text"
              value={companyName}
              onChange={(e) => setCompanyName(e.target.value)}
            />
            <label htmlFor="tickerSymbol">Ticker Symbol</label>
            <input
              type="text"
              value={tickerSymbol}
              onChange={(e) => setTickerSymbol(e.target.value)}
            />
            <label htmlFor="price">Price</label>
            <input
              type="number"
              value={price}
              onChange={(e) => setPrice(Number(e.target.value))}
            />
            <label htmlFor="Qty">Qty</label>
            <input
              type="number"
              value={quantity}
              onChange={(e) => setQuantity(Number(e.target.value))}
            />
            <input
              type="date"
              value={date}
              onChange={(e) => setDate(e.target.value)}
            />
          </div>
          <button
            className="mt-20 flex justify-end mx-auto bg-transparent text-black hover:bg-bg-primary-green-blue text-lg transform hover:scale-110 transition-all duration-200 drop-shadow-lg"
            type="submit"
          >
            Submit
          </button>
        </form>
        <button
          className="mt-20 flex justify-end mx-auto bg-transparent text-black hover:bg-bg-primary-green-blue text-lg transform hover:scale-110 transition-all duration-200 drop-shadow-lg"
          onClick={handleCloseModal}
        >
          Close
        </button>
      </Modal>
    </div>
  );
}

export default HandleUpdateStock;

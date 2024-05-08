import { useState } from "react";
export const NewIncomeForm = ({ display, setDisplay }) => {
  const types = ["Salary", "Amount", "Portfolio", "Gift"];
  const [displayForm, setDisplayForm] = useState(display);
  
    return (
    displayForm && (
        <form className="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 w-4/12 bg-[#EEEEEE] p-8 rounded shadow-md">
        <button className="absolute top-0 right-0 bg-[#DD3535] text-white py-2 px-4 rounded my-2 mx-2 text-center mx-auto block" onClick={() => setDisplay(false)}>X</button>
        <h1 className="text-center font-semibold text-size-18">Add New Income</h1>
        <input
            type="text"
            placeholder="Title"
            required
            className="block w-5/12 m-auto mt-5 rounded px-5 py-1"
        />
        <input
            type="text"
            placeholder="Amount"
            required
            className="block w-5/12 m-auto mt-5 rounded px-5 py-1"
        />
        <select
            id="category"
            name="category"
            required
            className="block w-5/12 m-auto px-3 mt-5 py-1 border rounded-md focus:outline-none focus:border-blue-500"
        >
            {types.map((element, key) => (
            <option key={key}>{element}</option>
            ))}
        </select>
        <input
            type="submit"
            value="Submit"
            className="block mt-5 bg-[#2D5872] text-white cursor-pointer m-auto hover:bg-[#0A2430] font-semibold py-2 px-8 margin-auto rounded-md focus:outline-none"
        />
        </form>
    )
    );

}

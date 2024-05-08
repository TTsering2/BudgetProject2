import { useState } from "react";
import useAuth from "@/Hooks/useAuth";


export const NewIncomeForm = ({ display, setDisplay }) => {

  const types = ["Salary", "Amount", "Portfolio", "Gift"];
  const [displayForm, setDisplayForm] = useState(display);
  const [notification, setNotification] = useState("");
//const { userId, signIn, signOut } = useAuth();

    //Post new income
    const postNewIncome = async(e) => {

        //console.log(userId);
        e.preventDefault();

        const incomeForm = {
            title: e.target.title.value,
            amount: e.target.amount.value,
            type: e.target.type.value,
            date:  new Date().toISOString(),
            userId: 2
        }


        try{
            const response = await fetch(`http://localhost:5112/api/Income`,{
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(incomeForm)
            });
            if(!response.ok){
                throw new Error(response.statusText);
            }
            else{
                const data = await response;
                if(data.status === 200){
                    setNotification("Income added successfully");
                    setDisplay(false);
                }
                else{
                    setNotification("Failed to add income");
                    setDisplay(false);
                }
            }
        }
        catch(error){
            console.log(error);
        }
    }
  
    return (
    displayForm && (
        <form className="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 w-4/12 bg-[#EEEEEE] p-8 rounded shadow-md" onSubmit={postNewIncome}>
            {
                notification != "" ? <p className="text-black">{notification}</p>:""
            }
            <p>{}</p>
        <button className="absolute top-0 right-0 bg-[#DD3535] text-white py-2 px-4 rounded my-2 mx-2 text-center mx-auto block" onClick={() => setDisplay(false)}>X</button>
        <h1 className="text-center font-semibold text-size-18">Add New Income</h1>
        <input
            type="text"
            placeholder="Title"
            name="title"
            required
            className="block w-5/12 m-auto mt-5 rounded px-5 py-1"
        />
        <input
            type="text"
            placeholder="Amount"
            name="amount"
            required
            className="block w-5/12 m-auto mt-5 rounded px-5 py-1"
            //onChange={() => setFormData()}
        />
        <select
            id="category"
            name="type"
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

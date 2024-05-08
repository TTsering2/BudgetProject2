import { useState } from "react";
import useAuth from "@/Hooks/useAuth";

export const NewIncomeForm = ({ display, setDisplay }) => {
  const types = ["Salary", "Amount", "Portfolio", "Gift"];
  const [displayForm, setDisplayForm] = useState(display);
  const [notification, setNotification] = useState("");

  const[formData,setFormData] = useState(
    {
        title: "",
        amount: 0,
        type: "",
        userId: userId,
    }
  )

  const { userId, signIn, signOut } = useAuth();

    //Post new income
    const postNewIncome = async(e) => {

        e.preventDefault();
        console.log(e.target);
        /*
        try{
            const response = await fetch(`http://localhost:5112/api/Income/${userId}`,{
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    title: "Salary",
                    amount: 1000,
                    category: "Salary",
                    userId: userId
                })
            });
            if(!response.ok){
                throw new Error(response.statusText);
            }
            else{
                const data = await response.json();
                console.log(data);
            }
        }
        catch(error){
            console.log(error);
        }*/
    }
  
    return (
    displayForm && (
        <form className="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 w-4/12 bg-[#EEEEEE] p-8 rounded shadow-md" onSubmit={postNewIncome}>
            {
                notification != "" ? <p>{notification}</p>:""
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
            onChange={}
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

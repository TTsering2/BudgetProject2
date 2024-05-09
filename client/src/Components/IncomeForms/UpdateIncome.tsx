import { useState } from "react";
import useAuth from "@/Hooks/useAuth";


export const UpdateIncomeForm = ({ display, setDisplay, updateScreen, initialData  }) => {

  const types = ["Salary", "Amount", "Portfolio", "Gift"];
  const [displayForm, setDisplayForm] = useState(display);
  const [notification, setNotification] = useState("");
  const { userId, signIn, signOut } = useAuth();

//HANDLE EDIING DATA
  const [IncomeEntry, setIncomeEntry] = useState({
    "id": initialData.id,
    "title": initialData.title,
    "type": initialData.type,
    "amount":initialData.amount
  });


  const userIdValue = userId?.toString();


  //DELETE SELECTED ENTRY
  const DeleteIncomeEntry = async(e) => {
    console.log(initialData.id);
        e.preventDefault();
         try{
            const response = await fetch(`http://localhost:5112/api/Income/incomeId=${initialData.id}`,{
                method: 'DELETE',
            });
            if(!response.ok){
                throw new Error(response.statusText);
            }
            else{
                const data = await response;
                if(data.status === 204){
                    setNotification("Income Entry deleted successfully");
                       setTimeout(() => {
                        setDisplay(false);
                        updateScreen(true);

                    }, 5000)
                }
                else{
                    setNotification("Failed to delete income");
                    setTimeout(() => {
                        setDisplay(false);
                        updateScreen(true);
                    }, 5000)
                }
            }
        }
        catch(error){
            console.log(error);
        }

  }


  //EDIT SELECTED ENTRY
  const EditSelectedEntry = async(e) =>{
    e.preventDefault();
       const incomeForm = {
            title: e.target.title.value,
            amount: e.target.amount.value,
            type: e.target.type.value,
            userId: userId
        }

        try{
            const response = await fetch(`http://localhost:5112/api/Income/${IncomeEntry.id}`,{
                method: 'PATCH',
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
                if(data.status === 204){
                    setNotification("Income was updated successfully");
                     setTimeout(() => {
                        setDisplay(false);
                        updateScreen(true);
                    }, 3000)
                }
                else{
                    setNotification("Can't update the income");
                    setTimeout(() => {
                        setDisplay(false);
                        updateScreen(true);
                    }, 3000)
                }
            }
        }
        catch(error){
            console.log(error);
        }

  }

  
    return (
    displayForm && (
        <form className="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 w-4/12 bg-[#EEEEEE] p-8 rounded shadow-md" onSubmit = {EditSelectedEntry} >
            {
                notification != "" ? <p className="text-black text-center text-[#11D3B0]">{notification}</p>:""
            }
        <button className="absolute top-0 right-0 bg-[#DD3535] text-white py-2 px-4 rounded my-2 mx-2 text-center mx-auto block" onClick={() => setDisplay(false)}>X</button>
        <h1 className="text-center font-semibold text-size-18">Update/Delete Income</h1>
        <div className="flex flex-row gap-5">
             <input
            type="text"
            defaultValue={IncomeEntry.title}
            name="title"
            
            className="block w-5/12 m-auto mt-5 rounded px-5 py-1"
        />
        <input
            type="text"
            placeholder="Amount"
            name="amount"
            defaultValue={IncomeEntry.amount}
            className="block w-5/12 m-auto mt-5 rounded px-5 py-1"
            //onChange={() => setFormData()}
        />
        <select
            id="category"
            name="type"
            defaultValue={IncomeEntry.type}
            className="block w-5/12 m-auto px-3 mt-5 py-1 border rounded-md focus:outline-none focus:border-blue-500"
        >
            {types.map((element, key) => (
            <option value={element} key={key}>{element}</option>
            ))}
        </select>
        <input
            type="submit"
            value="Edit"
            className="block mt-5 bg-[#2D5872] text-white cursor-pointer m-auto hover:bg-[#0A2430] font-semibold py-1 px-8 margin-auto rounded-md focus:outline-none"
        />
        <button className="block mt-5 bg-[#E14942] text-white cursor-pointer m-auto hover:bg-[#CE261E] font-semibold py-1 px-8 margin-auto rounded-md focus:outline-none" onClick ={DeleteIncomeEntry}>Delete</button>
        </div>
       
        </form>
    )
    );

}

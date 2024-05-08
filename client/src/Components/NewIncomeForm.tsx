export const NewIncomeForm = () =>{
    return(
            <form className="absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2 w-4/12 bg-[#EEEEEE] p-8 rounded shadow-md">
                <h1 className="text-center font-semibold size-18">Add New Income</h1>
            <input type="text" placeholder="Title" required className="block w-200 m-auto mt-5 rounded px-5" />
            <input type="text" placeholder="Amount" required className="block w-200 m-auto mt-5 rounded px-5 block" />
             <select id="category" name="category" required className="w-full px-3 py-2 border rounded-md focus:outline-none focus:border-blue-500">
                
            </select>
            <input type="submit" value="Submit" className="block mt-5 bg-[#2D5872] text-white cursor-pointer m-auto hover:bg-[#0A2430] font-semibold py-2 px-8 margin-auto rounded-md focus:outline-none " />
            </form>
    )
}
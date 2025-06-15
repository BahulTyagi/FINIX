import axios from "axios"
import type { CompanyNameSearch } from "./company";

interface SearchResponse {
    data: CompanyNameSearch[];
}

export const searchCompanies = async (query: string) => {
    try
    {
        // console.log(`Hitting API https://financialmodelingprep.com/stable/search-name?query=${query}&apikey=${import.meta.env.VITE_API_KEY}`);
        const data=await axios.get<CompanyNameSearch[]>(`https://financialmodelingprep.com/stable/search-name?query=${query}&apikey=54STOwpEKZUdJjRtI9KzVvaB1ithMwHM`);
       
        console.log("API data is :", data);
        return data;
    }
    catch(error)
    {
        if(axios.isAxiosError(error)){
        console.log("Error while calling API :", error.message);
        return error.message}
        else{
        console.log("unexpected error");
        return "Unexpected error is here";
        }
    }
}

import axios from "axios"
import type { CompanyNameSearch, CompanyProfile } from "./company";

interface SearchResponse {
    data: CompanyNameSearch[];
}

export const searchCompanies = async (query: string) => {
    try
    {
        // console.log(`Hitting API https://financialmodelingprep.com/stable/search-name?query=${query}&apikey=${import.meta.env.VITE_API_KEY}`);
    const data=await axios.get<CompanyNameSearch[]>(`https://financialmodelingprep.com/stable/search-name?query=${query}&apikey=54STOwpEKZUdJjRtI9KzVvaB1ithMwHM`);
       //due to api limit of 250 per day i am hardcoding the data , otherwise the above thing will work as usual

//        const data={
//     "data": [
//         {
//             "symbol": "APLY.NE",
//             "name": "Apple (AAPL) Yield Shares Purpose ETF",
//             "currency": "CAD",
//             "exchangeFullName": "CBOE CA",
//             "exchange": "NEO"
//         },
//         {
//             "symbol": "APLY",
//             "name": "YieldMax AAPL Option Income Strategy ETF",
//             "currency": "USD",
//             "exchangeFullName": "New York Stock Exchange Arca",
//             "exchange": "AMEX"
//         },
//         {
//             "symbol": "AAPD",
//             "name": "Direxion Daily AAPL Bear 1X Shares",
//             "currency": "USD",
//             "exchangeFullName": "NASDAQ Global Market",
//             "exchange": "NASDAQ"
//         },
//         {
//             "symbol": "AAPU",
//             "name": "Direxion Daily AAPL Bull 1.5X Shares",
//             "currency": "USD",
//             "exchangeFullName": "NASDAQ Global Market",
//             "exchange": "NASDAQ"
//         },
//         {
//             "symbol": "AAPS.L",
//             "name": "Leverage Shares -3x Short Apple (AAPL) ETP Securities",
//             "currency": "USD",
//             "exchangeFullName": "London Stock Exchange",
//             "exchange": "LSE"
//         },
//         {
//             "symbol": "AAPY",
//             "name": "Kurv Yield Premium Strategy Apple (AAPL) ETF",
//             "currency": "USD",
//             "exchangeFullName": "New York Stock Exchange Arca",
//             "exchange": "AMEX"
//         }
//     ],
//     "status": 200,
//     "statusText": "",
//     "headers": {
//         "content-type": "application/json; charset=utf-8"
//     },
//     "config": {
//         "transitional": {
//             "silentJSONParsing": true,
//             "forcedJSONParsing": true,
//             "clarifyTimeoutError": false
//         },
//         "adapter": [
//             "xhr",
//             "http",
//             "fetch"
//         ],
//         "transformRequest": [
//             null
//         ],
//         "transformResponse": [
//             null
//         ],
//         "timeout": 0,
//         "xsrfCookieName": "XSRF-TOKEN",
//         "xsrfHeaderName": "X-XSRF-TOKEN",
//         "maxContentLength": -1,
//         "maxBodyLength": -1,
//         "env": {},
//         "headers": {
//             "Accept": "application/json, text/plain, */*"
//         },
//         "method": "get",
//         "url": "https://financialmodelingprep.com/stable/search-name?query=aapl&apikey=54STOwpEKZUdJjRtI9KzVvaB1ithMwHM",
//         "allowAbsoluteUrls": true
//     },
//     "request": {}
// }
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


export const getCompanyProfile = async (query: string)=>{
    try{
         const data=await axios.get<CompanyProfile[]>(`https://financialmodelingprep.com/stable/profile?symbol=${query}&apikey=54STOwpEKZUdJjRtI9KzVvaB1ithMwHM`)
        return data;
        }
        catch(error: any)
        {
            console.log("Error occured while calling getcompanyprofile API");
        }

}

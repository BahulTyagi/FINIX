import { useState, type SyntheticEvent } from 'react'
import CardList from './Components/CardList/CardList'
import Search from './Components/Search/Search'
import './App.css'
import type { CompanyNameSearch } from './company';
import { searchCompanies } from './api';

function App() {

  const [search, setSearch]=useState<string>("");
  const [searchResult, setSearchResult]=useState<CompanyNameSearch[]>([]);
  const [serverError, setServerError]=useState<string>("");

    const handleOnChange=(e: any)=>{  // any will skip the type checking , howerver we can hover over e and copy its return type from soource and paste it here
        setSearch(e.target.value);
    }

    const onClick=async (e: SyntheticEvent)=>{ // Synthetic event handles type checking and can work with any event
        console.log(e);

        const result=await searchCompanies(search);
        if(typeof result=== "string")
          setServerError("result");
        else if(Array.isArray(result))
          setSearchResult(result.data);
        console.log(result);
    }

  return (
    <>
    <Search onClick={onClick} search={search} handleOnChange={handleOnChange}/>
     <div className="cardlist">
      <CardList></CardList>
     </div>
    </>
  )
}

export default App

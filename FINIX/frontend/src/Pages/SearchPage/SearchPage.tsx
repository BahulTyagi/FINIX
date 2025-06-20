import React, { useState, type SyntheticEvent } from 'react'
import Search from '../../Components/Search/Search';
import ListPortfolio from '../../Components/Portfolio/ListPortfolio/ListPortfolio';
import CardList from '../../Components/CardList/CardList';
import { searchCompanies } from '../../api';
import type { CompanyNameSearch } from '../../company';

type Props = {}

const SearchPage = (props: Props) => {

    const [search, setSearch]=useState<string>("");
  const [portfolioValues, setPortfolioValues]= useState<string[]>([]);
  const [searchResult, setSearchResult]=useState<CompanyNameSearch[]>([]);
  const [serverError, setServerError]=useState<string>("");

    const handleSearchChange=(e: any)=>{  // any will skip the type checking , howerver we can hover over e and copy its return type from soource and paste it here
        setSearch(e.target.value);
    }

    const onSearchSubmit=async (e: SyntheticEvent)=>{ // Synthetic event handles type checking and can work with any event
        e.preventDefault();

        const result=await searchCompanies(search);
        if(typeof result=== "string")
          setServerError("result");
        else if(Array.isArray(result?.data))
          setSearchResult(result.data);  // update here as per the api resp
        console.log(result);
    }

    const onPortfolioCreate=(e:any)=>{
      e.preventDefault();
       console.log("onPortfolioCreate Triggered : "+e);
       const exists=portfolioValues.find((val)=>val===e.target[0].value);
       if(!exists)
       {
      const updatedPortfolio=[...portfolioValues, e.target[0].value];
      setPortfolioValues(updatedPortfolio);
      }
      console.log(e);
    }

    const onPortfolioDelete=(e:any)=>{
      e.preventDefault();
      console.log("onPortfolioDelete Triggered");
      const removed=portfolioValues.filter((val)=>(val!=e.target[0].value));
      setPortfolioValues(removed);
    }

  return (
    <>
    <Search onSearchSubmit={onSearchSubmit} search={search} handleSearchChange={handleSearchChange}/>
    {serverError && <h2>SOME NETWORK ERROR OCCURED</h2>}
    <ListPortfolio onPortfolioDelete={onPortfolioDelete} portfolioValues={portfolioValues}/>
     <div className="cardlist">
      <CardList onPortfolioCreate={onPortfolioCreate} searchResult={searchResult}></CardList>
     </div>
    </>
  )
}

export default SearchPage
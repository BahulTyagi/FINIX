import React, { type SyntheticEvent } from 'react'
import Card from '../Card/Card'
import './CardList.css'
import type { CompanyNameSearch } from '../../company'
type Props = {
  searchResult: CompanyNameSearch[];
  onPortfolioCreate: (e:SyntheticEvent)=>void;
}



const CardList = ({searchResult, onPortfolioCreate}: Props) => {

  console.log("Final SearchResult goes like :", searchResult);

  return (
    <>
    {searchResult?.length>0 ? (searchResult.map((res, index)=>(
         <Card onPortfolioCreate={onPortfolioCreate} key={index} name={res.name} symbol={res.symbol} currency={res.currency}/>   
    ))) : (
      <h2>No Result found!</h2>
    )};
    </>
  )
}

export default CardList
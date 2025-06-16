import React from 'react'
import CardPortfolio from '../CardPortfolio/CardPortfolio';

type Props = {
    portfolioValues: string[];
    onPortfolioDelete: (e:any)=>void;
}

const ListPortfolio = ({portfolioValues, onPortfolioDelete}: Props) => {
  return (
    <>
        {portfolioValues && portfolioValues.map((portfolio)=><CardPortfolio onPortfolioDelete={onPortfolioDelete} portfolio={portfolio}/>)};
    </>
  )
}

export default ListPortfolio
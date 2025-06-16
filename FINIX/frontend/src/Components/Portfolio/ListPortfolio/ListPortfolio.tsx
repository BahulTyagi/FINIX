import React from 'react'
import CardPortfolio from '../CardPortfolio/CardPortfolio';

type Props = {
    portfolioValues: string[];
}

const ListPortfolio = ({portfolioValues}: Props) => {
  return (
    <>
        {portfolioValues && portfolioValues.map((portfolio)=><CardPortfolio portfolio={portfolio}/>)};
    </>
  )
}

export default ListPortfolio
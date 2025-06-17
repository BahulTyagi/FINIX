import React, { type SyntheticEvent } from 'react'
import DeletePortfolio from '../DeletePortfolio/DeletePortfolio'
import { Link } from 'react-router-dom';
type Props = {
    portfolio: string;
    onPortfolioDelete: (e: SyntheticEvent)=>void;
}

const CardPortfolio = ({portfolio, onPortfolioDelete}: Props) => {
  return (
    <>
    <div>{portfolio}</div>
    <DeletePortfolio portfolioValue={portfolio} onPortfolioDelete={onPortfolioDelete}/>
    </>
  )
}

export default CardPortfolio
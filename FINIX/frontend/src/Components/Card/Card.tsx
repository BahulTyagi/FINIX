import React, { type SyntheticEvent } from 'react'
import './Card.css'
import AddPortfolio from '../Portfolio/AddPortfolio/AddPortfolio'
import { Link } from 'react-router-dom';

type Props = {
  name: string,
  symbol: string,
  currency: string,
  onPortfolioCreate:(e: SyntheticEvent)=>void;
}

const Card = (prop: Props) => {
  return (
    <>
    <Link to={`/company/${prop.symbol}`}>
    <div className='card'>

    {/* <img height={500} width={500} src="https://images.unsplash.com/photo-1584306670957-acf935f5033c?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fGFwcGxlfGVufDB8fDB8fHww" alt="HERE Is THE IMAGE" /> */}
    <div className="details">
        <h2>{prop.name} {prop.symbol}</h2>
        <p>{prop.currency}</p>
    </div>
    <p className='info'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Reprehenderit, a?</p>
    <AddPortfolio onPortfolioCreate={prop.onPortfolioCreate} symbol={prop.symbol}/>
    </div>
    </Link>
    </>
  )
}

export default Card
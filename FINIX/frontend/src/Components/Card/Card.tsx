import React from 'react'
import './Card.css'

type Props = {
  CompanyName: string,
  Ticker: string,
  price: number
}

const Card = (prop: Props) => {
  return (
    <>
    <div className='card'>

    <img height={500} width={500} src="https://images.unsplash.com/photo-1584306670957-acf935f5033c?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fGFwcGxlfGVufDB8fDB8fHww" alt="HERE Is THE IMAGE" />
    <div className="details">
        <h2>{prop.CompanyName} {prop.Ticker}</h2>
        <p>{prop.price}</p>
    </div>
    <p className='info'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Reprehenderit, a?</p>
    </div>
    
    </>
  )
}

export default Card
import React from 'react'
import Card from '../Card/Card'
import './CardList.css'
type Props = {}


const companies=[
    {CompanyName: 'AAPL', Ticker:'no tick tock', Price: 24},
    {CompanyName: 'AAPL', Ticker:'no tick tock', Price: 24},
    {CompanyName: 'AAPL', Ticker:'no tick tock', Price: 24}
];

const CardList = (props: Props) => {
  return (
    <>
    {companies.map((com, index)=>(
         <Card key={index} CompanyName={com.CompanyName} Ticker={com.Ticker} price={com.Price}/>   
    ))};
    </>
  )
}

export default CardList
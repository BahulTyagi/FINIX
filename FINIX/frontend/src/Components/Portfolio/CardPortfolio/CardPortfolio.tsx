import React from 'react'

type Props = {
    portfolio: string;
}

const CardPortfolio = ({portfolio}: Props) => {
  return (
    <div>{portfolio}</div>
  )
}

export default CardPortfolio
import React, { type SyntheticEvent } from 'react'

type Props = {
  onPortfolioDelete : (e:SyntheticEvent)=>void;
  portfolioValue: string;
}

const DeletePortfolio = ({onPortfolioDelete, portfolioValue}: Props) => {
  return (
    <>
      <form onSubmit={onPortfolioDelete}>
        <input readOnly={true} hidden={true} value={portfolioValue} />
        <button>X</button>
      </form>
    </>
  )
}

export default DeletePortfolio
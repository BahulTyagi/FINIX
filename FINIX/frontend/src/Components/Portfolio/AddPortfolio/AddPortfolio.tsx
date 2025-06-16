import React, { type SyntheticEvent } from 'react'

type Props = {
    onPortfolioCreate: (e: SyntheticEvent)=>void;
    symbol: string
}

const AddPortfolio = (props: Props) => {
  return (
    <>
        <form onSubmit={props.onPortfolioCreate}>
            <input readOnly={true} hidden={true} value={props.symbol} />
            <button type="submit">Add</button>
        </form>
    </>
  )
}

export default AddPortfolio
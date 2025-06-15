import React, { useState, type SyntheticEvent } from 'react'
import './Search.css'

type Props = {
  onClick: (e: SyntheticEvent)=>void;
  search: string;
  handleOnChange: (e: SyntheticEvent)=>void;
}

const Search = ({onClick, search, handleOnChange}: Props) => {
  return (
    <div className="search-container">
  <input
    value={search}
    type="text"
    placeholder="Search stocks..."
    className="search-input"
    onChange={handleOnChange}
  />
  <button onClick={onClick}>Search</button>
</div>

  )
}

export default Search
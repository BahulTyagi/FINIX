import React, { useState, type SyntheticEvent } from 'react'
import './Search.css'

type Props = {
  onSearchSubmit: (e: SyntheticEvent)=>void;
  search: string;
  handleSearchChange: (e: SyntheticEvent)=>void;
}

const Search = ({onSearchSubmit, search, handleSearchChange}: Props) => {
  return (
    <>
    <form onSubmit={onSearchSubmit} className='search-container'>
      <input onChange={handleSearchChange} value={search} className='search-input'/>
    </form>
    </>

  )
}

export default Search
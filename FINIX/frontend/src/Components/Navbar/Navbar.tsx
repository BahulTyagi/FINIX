import React from 'react'
import './Navbar.css'
import { Link } from 'react-router-dom'
type Props = {}

const Navbar = (props: Props) => {
  return (
    <div className='navbar'>
      <Link to="/"><div>FINIX</div></Link>
      <div className='buttons'>
          <button className='button'>Login</button>
          <button className='button'>Signup</button>
      </div>
    </div>
  )
}

export default Navbar